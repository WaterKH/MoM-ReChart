using MoMMusicAnalysis;
using MoMTool.Components.SelfContainedComponents;
using MoMTool.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class MemoryDiveChartManager
    {
        public MusicFile MusicFile;
        public MemoryDiveSubChartManager MemoryDiveSubChartManager; // TODO Maybe make this private?
        public BeatManager<MemoryLane> BeatManager;

        public int ZoomVariable = 10;

        public Difficulty CurrentDifficultyTab { get; set; } = Difficulty.Proud;
        public Dictionary<Difficulty, MemoryChartComponent> MemoryCharts { get; set; }

        private readonly ToolTip ToolTip = null;

        public MemoryDiveChartManager(MusicFile musicFile)
        {
            this.MusicFile = musicFile;
            this.ToolTip = new ToolTip();
            this.MemoryDiveSubChartManager = new MemoryDiveSubChartManager(this);
            this.BeatManager = new BeatManager<MemoryLane>();
        }

        public void DecompileMemoryDiveSongs()
        {
            this.MemoryCharts = new Dictionary<Difficulty, MemoryChartComponent>();

            foreach (MemoryDiveSong song in this.MusicFile.SongPositions.Values)
            {
                this.MemoryCharts.Add(song.Difficulty, this.CreateChart(song));
            }

            this.BeatManager.CalculateOffset(this.MemoryCharts[this.CurrentDifficultyTab]);
        }


        #region Recompile Memory Dive

        public void RecompileMemoryDiveSongs()
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
                musicFile.Header.NextSize1 = musicFile.Header.NextSize2 = 0x5B;
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

                musicFile.Header.NextSize1 = musicFile.Header.NextSize2 = 0x65;
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
                    var newSong = new MemoryDiveSong(song.Difficulty, 0, SongType.MemoryDive)
                    {
                        HasEmptyData = ((MemoryDiveSong)song).HasEmptyData
                    };

                    this.RecompileMemorySong(ref newSong, this.MemoryCharts[song.Difficulty]);

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

        private void RecompileMemorySong(ref MemoryDiveSong newSong, MemoryChartComponent chart)
        {
            newSong.NoteCount = chart.Notes.Count;
            newSong.PerformerCount = chart.Performers.Count;
            newSong.TimeShiftCount = chart.Times.Count;

            newSong.Unk1 = 1;

            var newNotes = new List<Note<MemoryLane>>();

            foreach (MemoryNote note in chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                if (note.StartHoldNote != null)
                    note.StartHoldNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.StartHoldNote);

                if (note.EndHoldNote != null)
                    note.EndHoldNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.EndHoldNote);

                newSong.Notes.Add(note);
            }

            foreach (PerformerNote<MemoryLane> note in chart.Performers.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.PerformerNotes.Add(note);
            }

            foreach (TimeShift<MemoryLane> time in chart.Times.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.TimeShifts.Add(time);
            }

            // Add Note + Header Lengths
            newSong.Length = (newSong.NoteCount * 0x40) + (newSong.PerformerCount * 0x30) + (newSong.TimeShiftCount * 0x08) + 0x24;
        }

        #endregion Recompile Memory Dive Music File


        #region Helper Methods

        private MemoryChartComponent CreateChart(MemoryDiveSong memoryDiveSong)
        {
            var memoryChart = new MemoryChartComponent
            {
                MemoryDiveChartManager = this
            };

            memoryChart.songTypeDropdown.SelectedItem = "Memory Dive";
            if (memoryDiveSong.NoteCount == 0)
                return memoryChart;

            var songLength = (memoryDiveSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            memoryChart.notesCheckbox.Checked = true;
            memoryChart.performerCheckbox.Checked = true;
            memoryChart.chartTimeValue.Text = songLength.ToString();
            

            memoryChart.Notes = this.CreateChartButtons(ref memoryChart, memoryDiveSong.NoteCount, memoryDiveSong.Notes, "Note", Color.Red);
            memoryChart.Performers = this.CreateChartButtons(ref memoryChart, memoryDiveSong.PerformerCount, memoryDiveSong.PerformerNotes, "Performer", Color.Purple);
            memoryChart.Times = this.CreateChartButtons(ref memoryChart, memoryDiveSong.TimeShiftCount, memoryDiveSong.TimeShifts, "Time", Color.Yellow);

            foreach (var memoryNote in memoryChart.Notes)
            {
                if (memoryNote.Note.StartHoldNoteIndex != -1)
                    memoryNote.Note.StartHoldNote = memoryChart.Notes.ElementAt(memoryNote.Note.StartHoldNoteIndex).Note;

                if (memoryNote.Note.EndHoldNoteIndex != -1)
                    memoryNote.Note.EndHoldNote = memoryChart.Notes.ElementAt(memoryNote.Note.EndHoldNoteIndex).Note;

                memoryNote.Button.Image = this.GetImageForModelType(memoryNote.Note.MemoryNoteType);
            }

            foreach (var performer in memoryChart.Performers)
                performer.Button.Image = this.GetImageForModelType(performer.Note.PerformerType);

            foreach (var time in memoryChart.Times)
                time.Button.Image = Resources.MemoryTime;

            return memoryChart;
        }

        private ObservableCollection<MoMButton<TNoteType>> CreateChartButtons<TNoteType>(ref MemoryChartComponent memoryChart, int count, List<TNoteType> components, string type, Color color) where TNoteType : Note<MemoryLane>
        {
            var fieldChartButtons = new ObservableCollection<MoMButton<TNoteType>>();

            for (int i = 0; i < count; ++i)
            {
                fieldChartButtons.Add(this.CreateChartButton(ref memoryChart, i, components[i], type, color));
            }

            return fieldChartButtons;
        }

        private MoMButton<TNoteType> CreateChartButton<TNoteType>(ref MemoryChartComponent memoryChart, int id, TNoteType component, string type, Color color, Image image = null) where TNoteType : Note<MemoryLane>
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
            momButton.Button.Click += (object sender, EventArgs e) => { MemoryDiveSubChartManager.LoadSubChartComponent(momButton.Id, momButton.Note); };
            momButton.Button.MouseDown += (object sender, MouseEventArgs e) => { this.MouseDown(sender, e); };

            ToolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

            memoryChart.AddToLane(momButton.Note.Lane, momButton.Button);

            return momButton;
        }

        public int CalculateChartLength(string text)
        {
            if (int.TryParse(text, out int value))
                return (value + 5000) / this.ZoomVariable; // Add 5 seconds and apply our zoom

            return 0;
        }

        public void MoveChartNote(Panel panel, Point point, string buttonName, bool convert = false)
        {
            var buttonType = buttonName.Split('-')[0];
            Point controlRelatedCoords = convert ? panel.PointToClient(point) : point;

            var lane = (MemoryLane)Enum.Parse(typeof(MemoryLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);

            if (buttonType == "note")
            {
                this.MemoryCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.MemoryCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.MemoryCharts[difficulty].AddToLane(lane, this.MemoryCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.MemoryCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "performer")
            {
                this.MemoryCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.MemoryCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.MemoryCharts[difficulty].AddToLane(lane, this.MemoryCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.MemoryCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "time")
            {
                this.MemoryCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.MemoryCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.MemoryCharts[difficulty].AddToLane(lane, this.MemoryCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.MemoryCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
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

        public void CreateDroppedNote(Panel panel, string noteType, bool convert, Point point, Line closestTime)
        {
            Point controlRelatedCoords = convert ? panel.PointToClient(point) : point;

            var lane = (MemoryLane)Enum.Parse(typeof(MemoryLane), panel.Name[5..]);
            var hitTime = controlRelatedCoords.X * Settings.ZoomVariable;

            if (closestTime != null)
                hitTime += closestTime.OffsetRemainder;

            var memoryChart = this.MemoryCharts[this.CurrentDifficultyTab];

            if (noteType.Equals("Memory Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.NormalNote));
            }
            else if (noteType.Equals("Performer Note"))
            {
                var performer = new PerformerNote<MemoryLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    PerformerType = PerformerType.L2,
                    DuplicateType = PerformerType.L2
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Performers.Add(this.CreateChartButton(ref memoryChart, memoryChart.Performers.Count, performer, "Performer", Color.Purple, Resources.L2));
            }
            else if (noteType.Equals("Time Shift"))
            {
                var time = new TimeShift<MemoryLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = MemoryLane.PlayerLeft
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Times.Add(this.CreateChartButton(ref memoryChart, memoryChart.Times.Count, time, "Time", Color.Yellow, Resources.MemoryTime));
            }
            else if (noteType.Equals("Normal Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.Normal
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.NormalNote));
            }
            else if (noteType.Equals("Swipe Up Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.Swipe,
                    SwipeDirection = SwipeType.Up
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Right Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.Swipe,
                    SwipeDirection = SwipeType.Right
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Down Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.Swipe,
                    SwipeDirection = SwipeType.Down
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Swipe Left Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.Swipe,
                    SwipeDirection = SwipeType.Left
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.SwipeNote));
            }
            else if (noteType.Equals("Hold Start Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.HoldStart
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.HoldNote));
            }
            else if (noteType.Equals("Hold End Note"))
            {
                var memoryNote = new MemoryNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane,
                    MemoryNoteType = MemoryNoteType.HoldEnd
                };

                this.MemoryCharts[this.CurrentDifficultyTab].Notes.Add(this.CreateChartButton(ref memoryChart, memoryChart.Notes.Count, memoryNote, "Note", Color.Red, Resources.HoldNote));
            }
        }

        public Image GetImageForModelType(MemoryNoteType type)
        {
            if (type == MemoryNoteType.Normal)
                return Resources.NormalNote;
            else if (type == MemoryNoteType.HoldEnd || type == MemoryNoteType.HoldStart)
                return Resources.HoldNote;
            else if (type == MemoryNoteType.Swipe)
                return Resources.SwipeNote;
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