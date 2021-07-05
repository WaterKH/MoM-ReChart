using MoMMusicAnalysis;
using MoMTool.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class BossBattleChartManager
    {
        public MusicFile MusicFile;
        public BossBattleSubChartManager BossBattleSubChartManager; // TODO Maybe make this private?

        public int ZoomVariable = 10;

        public Difficulty CurrentDifficultyTab { get; set; } = Difficulty.Proud;
        public Dictionary<Difficulty, BossChartComponent> BossCharts { get; set; }

        private readonly ToolTip ToolTip = null;

        public BossBattleChartManager(MusicFile musicFile)
        {
            this.MusicFile = musicFile;
            this.ToolTip = new ToolTip();
            this.BossBattleSubChartManager = new BossBattleSubChartManager(this);
        }

        public void DecompileBossBattleSongs() 
        {
            this.BossCharts = new Dictionary<Difficulty, BossChartComponent>();

            foreach (BossBattleSong song in this.MusicFile.SongPositions.Values)
            {
                this.BossCharts.Add(song.Difficulty, this.CreateChart(song));
            }
        }

        #region Recompile Boss Battle

        public void RecompileBossBattleSongs()
        {
            var musicFile = new MusicFile
            {
                FileName = MusicFile.FileName,
                Header = MusicFile.Header,
                SongPositions = new Dictionary<int, ISong>(),
                AssetPositions = new Dictionary<int, List<byte>>()
            };

            // Recompile Sections (Assets + Songs)
            var offset = this.RecompileSections(ref musicFile);

            // Recompile Header
            this.RecompileHeader(ref musicFile, offset);

            // Recompile Into MusicFile
            var fileData = musicFile.RecompileMusicFile();


            // Save To File
            Stream stream;
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    stream.Write(fileData.ToArray());
                    stream.Close();
                }
            }
        }

        private void RecompileHeader(ref MusicFile musicFile, int offset)
        {
            var fileSize = 0x1000 + offset;

            musicFile.Header.FileSizeCount = fileSize < 0x1F400 ? 1 : fileSize < 0x3E800 ? 2 : 3; // Do we need to plan for higher?

            if (musicFile.Header.FileSizeCount == 1)
            {
                musicFile.Header.FileSizes = new List<FileSize> {
                    new FileSize { MainFileSize1 = fileSize, MainFileSize2 = fileSize }
                };
                musicFile.Header.EntireFileSize = fileSize + 0x8C;
            }
            else if (musicFile.Header.FileSizeCount == 2)
            {
                var fileSizes = BitConverter.GetBytes(fileSize);
                var fileSize1 = BitConverter.ToInt32(new byte[4] { 0x0, 0x0, 0x0, fileSizes[2] });
                var fileSize2 = BitConverter.ToInt32(new byte[4] { 0x0, fileSizes[0], fileSizes[1], 0x0 });

                musicFile.Header.FileSizes = new List<FileSize> {
                    new FileSize { MainFileSize1 = fileSize1, MainFileSize2 = fileSize1 },
                    new FileSize { MainFileSize1 = fileSize2, MainFileSize2 = fileSize2 },
                };
                musicFile.Header.EntireFileSize = fileSize + 0x96;
            }
            else if (musicFile.Header.FileSizeCount == 3)
            {
                // TODO Not sure how to handle this
                //var fileSizes = BitConverter.GetBytes(fileSize);
                //var fileSize1 = BitConverter.ToInt32(new byte[4] { 0x0, 0x0, 0x0, fileSizes[3]});
                //var fileSize2 = BitConverter.ToInt32(new byte[4] { 0x0, 0x0, fileSizes[2], 0x0 });
                //var fileSize3 = BitConverter.ToInt32(new byte[4] { fileSizes[0], fileSizes[1], 0x0, 0x0 });

                //musicFile.Header.FileSizes = new List<FileSize> {
                //    new FileSize { MainFileSize1 = fileSize1, MainFileSize2 = fileSize1 },
                //    new FileSize { MainFileSize1 = fileSize2, MainFileSize2 = fileSize2 },
                //    new FileSize { MainFileSize1 = fileSize3, MainFileSize2 = fileSize3 },
                //};
                //musicFile.Header.EntireFileSize = fileSize + 0xA0;
            }

            musicFile.Header.CompleteFileSize = fileSize;
            musicFile.Header.FinalFileSize = fileSize;
        }

        private int RecompileSections(ref MusicFile musicFile)
        {
            int offset = 0;

            for (int i = 0; i < musicFile.Header.Sections.Length; ++i)
            {
                if (this.MusicFile.AssetPositions.ContainsKey(i))
                {
                    musicFile.Header.Sections[i].Offset = offset;

                    musicFile.AssetPositions.Add(i, new List<byte>());
                    musicFile.AssetPositions[i] = MusicFile.AssetPositions[i];
                    musicFile.AssetHasEmptyData = MusicFile.AssetHasEmptyData;

                    // initial length + asset length
                    var assetLength = 4 + musicFile.AssetPositions[i].Count;
                    assetLength += MusicFile.AssetHasEmptyData ? 4 : 0;

                    musicFile.Header.Sections[i].Size = assetLength;
                    offset += assetLength;
                }
                else if (this.MusicFile.SongPositions.ContainsKey(i))
                {
                    musicFile.Header.Sections[i].Offset = offset;

                    var song = this.MusicFile.SongPositions[i];
                    var newSong = new BossBattleSong(song.Difficulty, 0, SongType.BossBattle)
                    {
                        HasEmptyData = ((BossBattleSong)song).HasEmptyData
                    };

                    this.RecompileBossSong(ref newSong, this.BossCharts[song.Difficulty]);

                    musicFile.SongPositions.Add(i, newSong);

                    // method name length + method name + length size + Song length
                    var entireSongLength = (4 + 16 + 4 + newSong.Length);

                    musicFile.Header.Sections[i].Size = entireSongLength;
                    offset += entireSongLength;
                    offset += newSong.HasEmptyData ? 4 : 0;
                }
            }

            return offset;
        }

        private void RecompileBossSong(ref BossBattleSong newSong, BossChartComponent chart)
        {
            newSong.NoteCount = chart.Notes.Count;
            newSong.PerformerCount = chart.Performers.Count;
            newSong.TimeShiftCount = chart.Times.Count;

            newSong.Unk1 = 1;

            var newNotes = new List<Note<BossLane>>();

            foreach (BossNote note in chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                if (note.StartHoldNote != null)
                    note.StartHoldNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.StartHoldNote);

                if (note.EndHoldNote != null)
                    note.EndHoldNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.EndHoldNote);

                newSong.Notes.Add(note);
            }

            foreach (PerformerNote<BossLane> note in chart.Performers.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.PerformerNotes.Add(note);
            }


            foreach (TimeShift<BossLane> time in chart.Times.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.TimeShifts.Add(time);
            }

            // Add Note + Header Lengths
            newSong.Length = (newSong.NoteCount * 0x40) + (newSong.PerformerCount * 0x30) + (newSong.TimeShiftCount * 0x08) + (newSong.DarkZoneCount * 0x10) + 0x28;
        }

        #endregion Recompile Boss Battle Music File


        #region Helper Methods

        private BossChartComponent CreateChart(BossBattleSong bossBattleSong)
        {
            var bossChart = new BossChartComponent
            {
                BossBattleChartManager = this
            };

            bossChart.songTypeDropdown.SelectedItem = "Boss Battle";
            if (bossBattleSong.NoteCount == 0)
                return bossChart;

            var songLength = (bossBattleSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            bossChart.songTypeDropdown.SelectedItem = "Boss Battle";
            bossChart.notesCheckbox.Checked = true;
            bossChart.performerCheckbox.Checked = true;
            bossChart.chartTimeValue.Text = songLength.ToString();


            bossChart.Notes = this.CreateChartButtons(ref bossChart, bossBattleSong.NoteCount, bossBattleSong.Notes, "Note", Color.Red);
            bossChart.Performers = this.CreateChartButtons(ref bossChart, bossBattleSong.PerformerCount, bossBattleSong.PerformerNotes, "Performer", Color.Purple);
            bossChart.Times = this.CreateChartButtons(ref bossChart, bossBattleSong.TimeShiftCount, bossBattleSong.TimeShifts, "Time", Color.Yellow);
            bossChart.DarkZones = this.CreateChartButtons(ref bossChart, bossBattleSong.DarkZoneCount, bossBattleSong.DarkZones, "DarkZone", Color.Black);

            foreach (var bossNote in bossChart.Notes)
            {
                if (bossNote.Note.StartHoldNoteIndex != -1)
                    bossNote.Note.StartHoldNote = bossChart.Notes.ElementAt(bossNote.Note.StartHoldNoteIndex).Note;

                if (bossNote.Note.EndHoldNoteIndex != -1)
                    bossNote.Note.EndHoldNote = bossChart.Notes.ElementAt(bossNote.Note.EndHoldNoteIndex).Note;

                bossNote.Button.Image = this.GetImageForModelType(bossNote.Note.BossNoteType);
            }

            foreach (var performer in bossChart.Performers)
                performer.Button.Image = this.GetImageForModelType(performer.Note.PerformerType);

            foreach (var time in bossChart.Times)
                time.Button.Image = Resources.BossTime;

            foreach (var time in bossChart.DarkZones)
                time.Button.Image = Resources.DarkZone;

            return bossChart;
        }

        private ObservableCollection<MoMButton<TNoteType>> CreateChartButtons<TNoteType>(ref BossChartComponent bossChart, int count, List<TNoteType> components, string type, Color color) where TNoteType : Note<BossLane>
        {
            var bossChartButtons = new ObservableCollection<MoMButton<TNoteType>>();

            for (int i = 0; i < count; ++i)
            {
                bossChartButtons.Add(this.CreateChartButton(ref bossChart, i, components[i], type, color));
            }

            return bossChartButtons;
        }

        private MoMButton<TNoteType> CreateChartButton<TNoteType>(ref BossChartComponent bossChart, int id, TNoteType component, string type, Color color, Image image = null) where TNoteType : Note<BossLane>
        {
            var momButton = new MoMButton<TNoteType>
            {
                Id = id,
                Type = type,
                Note = component,
                Button = new Button
                {
                    Text = "",
                    BackColor = color,
                    Height = 19,
                    Width = 19,
                    Name = $"{type.ToLower()}-{id}",
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    Image = image
                },
            };

            momButton.Button.FlatAppearance.BorderSize = 0;

            momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);
            momButton.Button.Click += (object sender, EventArgs e) => { BossBattleSubChartManager.LoadSubChartComponent(momButton.Id, momButton.Note); };
            momButton.Button.MouseDown += (object sender, MouseEventArgs e) => { this.MouseDown(sender, e); };

            ToolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

            bossChart.AddToLane(momButton.Note.Lane, momButton.Button);

            return momButton;
        }

        public int CalculateChartLength(string text)
        {
            if (int.TryParse(text, out int value))
                return (value + 5000) / this.ZoomVariable; // Add 5 seconds and apply our zoom

            return 0;
        }

        public void MoveChartNote(Panel panel, Point point, string buttonName)
        {
            var buttonType = buttonName.Split('-')[0];
            Point controlRelatedCoords = panel.PointToClient(point);

            var lane = (BossLane)Enum.Parse(typeof(BossLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);

            if (buttonType == "note")
            {
                this.BossCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.BossCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.BossCharts[difficulty].AddToLane(lane, this.BossCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.BossCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "performer")
            {
                this.BossCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.BossCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.BossCharts[difficulty].AddToLane(lane, this.BossCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.BossCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "time")
            {
                this.BossCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.BossCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.BossCharts[difficulty].AddToLane(lane, this.BossCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.BossCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "darkzone")
            {
                this.BossCharts[difficulty].DarkZones.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.BossCharts[difficulty].DarkZones.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.BossCharts[difficulty].AddToLane(lane, this.BossCharts[difficulty].DarkZones.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.BossCharts[difficulty].DarkZones.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            // Determines which item was selected.
            var button = ((Button)sender);

            // Starts a drag-and-drop operation with that item.
            if (button != null && Utilities.IsControlDown())
            {
                button.DoDragDrop(button.Name, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void CreateDroppedNote(Panel panel, Point point, string noteType)
        {
            Point controlRelatedCoords = panel.PointToClient(point);

            var lane = (BossLane)Enum.Parse(typeof(BossLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);

            var bossChart = this.BossCharts[difficulty];

            if (noteType.Equals("Boss Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.NormalNote));
            }
            else if (noteType.Equals("Performer Note"))
            {
                var performer = new PerformerNote<BossLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    PerformerType = PerformerType.L2,
                    DuplicateType = PerformerType.L2
                };

                this.BossCharts[difficulty].Performers.Add(this.CreateChartButton(ref bossChart, bossChart.Performers.Count, performer, "Performer", Color.Purple, Resources.L2));
            }
            else if (noteType.Equals("Time Shift"))
            {
                var time = new TimeShift<BossLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = BossLane.PlayerTop
                };

                this.BossCharts[difficulty].Times.Add(this.CreateChartButton(ref bossChart, bossChart.Times.Count, time, "Time", Color.Yellow, Resources.BossTime));
            }
            else if (noteType.Equals("Dark Zone"))
            {
                var darkZone = new BossDarkZone
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = BossLane.PlayerTop,
                    EndTime = (controlRelatedCoords.X * this.ZoomVariable) + 6000,
                    EndAttackTime = (controlRelatedCoords.X * this.ZoomVariable) + 12000,
                };

                this.BossCharts[difficulty].DarkZones.Add(this.CreateChartButton(ref bossChart, bossChart.DarkZones.Count, darkZone, "DarkZone", Color.Black, Resources.DarkZone));
            }
            // Specific Types
            else if (noteType.Equals("Normal Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Normal
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.NormalNote));
            }
            else if (noteType.Equals("Swipe Up Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Swipe,
                    SwipeDirection = SwipeType.Up
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Right Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Swipe,
                    SwipeDirection = SwipeType.Right
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Down Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Swipe,
                    SwipeDirection = SwipeType.Down
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Left Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Swipe,
                    SwipeDirection = SwipeType.Left
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Hold Start Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.HoldStart
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.HoldNote));
            }
            else if (noteType.Equals("Hold End Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.HoldEnd
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.HoldNote));
            }
            else if (noteType.Equals("Crystal Note"))
            {
                var BossNote = new BossNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    BossNoteType = BossNoteType.Crystal
                };

                this.BossCharts[difficulty].Notes.Add(this.CreateChartButton(ref bossChart, bossChart.Notes.Count, BossNote, "Note", Color.Red, Resources.Crystal_Base));
            }
        }

        public Image GetImageForModelType(BossNoteType type)
        {
            if (type == BossNoteType.Normal)
                return Resources.NormalNote;
            else if (type == BossNoteType.HoldEnd || type == BossNoteType.HoldStart)
                return Resources.HoldNote;
            else if (type == BossNoteType.Swipe)
                return Resources.SwipeNote;
            else if (type == BossNoteType.Crystal)
                return Resources.Crystal_Base;
            else
                return null;
        }

        public Image GetImageForModelType(PerformerType type)
        {
            if (type == PerformerType.L2)
                return Resources.L2;
            else if (type == PerformerType.R2)
                return Resources.R2;
            else if (type == PerformerType.Up)
                return Resources.Up;
            else if (type == PerformerType.Down)
                return Resources.Down;
            else if (type == PerformerType.Left)
                return Resources.Left;
            else if (type == PerformerType.Right)
                return Resources.Right;
            else if (type == PerformerType.Ability)
                return Resources.Ability;
            else if (type == PerformerType.Jump)
                return Resources.Jump;
            else if (type == PerformerType.Action)
                return Resources.Action;
            else
                return null;
        }

        #endregion Helper Methods
    }
}