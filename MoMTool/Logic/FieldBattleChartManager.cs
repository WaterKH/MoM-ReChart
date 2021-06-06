using MoMMusicAnalysis;
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
    public class FieldBattleChartManager
    {
        public MusicFile MusicFile;
        public FieldBattleSubChartManager FieldBattleSubChartManager; // TODO Maybe make this private?

        public int ZoomVariable = 10;

        public Difficulty CurrentDifficultyTab { get; set; } = Difficulty.Proud;
        public Dictionary<Difficulty, FieldChartComponent> FieldCharts { get; set; }

        private readonly ToolTip ToolTip = null;

        public FieldBattleChartManager(MusicFile musicFile)
        {
            this.MusicFile = musicFile; 
            this.ToolTip = new ToolTip();
            this.FieldBattleSubChartManager = new FieldBattleSubChartManager(this);
        }

        public void DecompileFieldBattleSongs()
        {
            this.FieldCharts = new Dictionary<Difficulty, FieldChartComponent>();

            foreach (FieldBattleSong song in this.MusicFile.SongPositions.Values)
            {
                this.FieldCharts.Add(song.Difficulty, this.CreateChart(song));
            }
        }


        #region Recompile Field Battle

        public void RecompileFieldBattleSongs()
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
                    var newSong = new FieldBattleSong(song.Difficulty, 0, SongType.FieldBattle)
                    {
                        HasEmptyData = ((FieldBattleSong)song).HasEmptyData
                    };

                    this.RecompileFieldSong(ref newSong, this.FieldCharts[song.Difficulty]);

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

        private void RecompileFieldSong(ref FieldBattleSong newSong, FieldChartComponent chart)
        {
            var animations = chart.Notes.SelectMany(x => x.Note.Animations).Concat(chart.Assets.SelectMany(x => x.Note.Animations)).ToList();

            newSong.NoteCount = chart.Notes.Count;
            newSong.AnimationCount = animations.Count;
            newSong.AssetCount = chart.Assets.Count;
            newSong.PerformerCount = chart.Performers.Count;
            newSong.TimeShiftCount = chart.Times.Count;

            newSong.Unk1 = 1; // TODO Why? Is this the Identifier for FieldBattle?

            var newNotes = new List<Note<FieldLane>>();
            int count = 0;
            int aerialCrystalCount = -1;

            foreach (var anim in animations.OrderBy(x => x.AnimationEndTime))
            {
                anim.Id = count++;
            }

            foreach (var anim in animations)
            {
                newSong.FieldAnimations.Add(anim);
            }

            foreach (FieldNote note in chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                var modelString = note.ModelType.ToString();
                var aerialFlag = modelString.Contains("Aerial") || (modelString == "GlideNote" && note.PreviousEnemyNote == -1) || modelString == "Projectile";

                if (note.AerialFlag || aerialFlag || (note.ModelType == FieldModelType.CrystalEnemyCenter || note.ModelType == FieldModelType.CrystalEnemyLeftRight))
                {
                    note.AerialAndCrystalCounter = aerialCrystalCount++;
                }

                note.AnimationReference = note.Animations[0].Id;

                newSong.Notes.Add(note);
            }

            foreach (FieldAsset asset in chart.Assets.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                asset.AnimationReference = asset.Animations[0].Id;

                newSong.FieldAssets.Add(asset);
            }

            foreach (PerformerNote<FieldLane> note in chart.Performers.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.PerformerNotes.Add(note);
            }


            foreach (TimeShift<FieldLane> time in chart.Times.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                newSong.TimeShifts.Add(time);
            }

            // Add Note + Header Lengths
            newSong.Length = (newSong.NoteCount * 0x48) + (newSong.AnimationCount * 0x3C) + (newSong.AssetCount * 0x44) + (newSong.PerformerCount * 0x30) + (newSong.TimeShiftCount * 0x08) + 0x28;
        }

        #endregion Recompile Field Battle Music File


        #region Helper Methods

        private FieldChartComponent CreateChart(FieldBattleSong fieldBattleSong)
        {
            var fieldChart = new FieldChartComponent
            {
                FieldBattleChartManager = this
            };

            var songLength = (fieldBattleSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            fieldChart.songTypeDropdown.SelectedItem = "Field Battle";
            fieldChart.notesCheckbox.Checked = true;
            fieldChart.assetsCheckbox.Checked = true;
            fieldChart.performerCheckbox.Checked = true;
            fieldChart.chartTimeValue.Text = songLength.ToString();


            fieldChart.Notes = this.CreateChartButtons(ref fieldChart, fieldBattleSong.NoteCount, fieldBattleSong.Notes, "Note", Color.Red);
            fieldChart.Assets = this.CreateChartButtons(ref fieldChart, fieldBattleSong.AssetCount, fieldBattleSong.FieldAssets, "Asset", Color.Blue);
            fieldChart.Performers = this.CreateChartButtons(ref fieldChart, fieldBattleSong.PerformerCount, fieldBattleSong.PerformerNotes, "Performer", Color.Purple);
            fieldChart.Times = this.CreateChartButtons(ref fieldChart, fieldBattleSong.TimeShiftCount, fieldBattleSong.TimeShifts, "Time", Color.Yellow);

            return fieldChart;
        }

        private ObservableCollection<MoMButton<TNoteType>> CreateChartButtons<TNoteType>(ref FieldChartComponent fieldChart, int count, List<TNoteType> components, string type, Color color) where TNoteType : Note<FieldLane>
        {
            var fieldChartButtons = new ObservableCollection<MoMButton<TNoteType>>();

            for (int i = 0; i < count; ++i)
            {
                fieldChartButtons.Add(this.CreateChartButton(ref fieldChart, i, components[i], type, color));
            }

            return fieldChartButtons;
        }

        private MoMButton<TNoteType> CreateChartButton<TNoteType>(ref FieldChartComponent fieldChart, int id, TNoteType component, string type, Color color) where TNoteType : Note<FieldLane>
        {
            var momButton = new MoMButton<TNoteType>
            {
                Id = id,
                Type = type,
                Note = component,
                Button = new Button
                {
                    Text = "",
                    //Image = Image.FromFile("Resources/note_shadow.png"),
                    BackColor = color,
                    Height = 19,
                    Width = 19,
                    Name = $"{type.ToLower()}-{id}",
                    TabStop = false
                },
            };

            momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);
            momButton.Button.Click += (object sender, EventArgs e) => { FieldBattleSubChartManager.LoadSubChartComponent(momButton.Id, momButton.Note); };

            ToolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

            fieldChart.AddToLane(momButton.Note.Lane, momButton.Button);

            return momButton;
        }

        public int CalculateChartLength(string text)
        {
            if (int.TryParse(text, out int value))
                return (value + 5000) / this.ZoomVariable; // Add 5 seconds and apply our zoom

            return 0;
        }

        public void DragDrop(Panel panel, Point point, string noteType)
        {
            Point controlRelatedCoords = panel.PointToClient(point);

            var lane = (FieldLane)Enum.Parse(typeof(FieldLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);

            if (noteType.Equals("Enemy Note"))
            {
                var fieldChart = this.FieldCharts[difficulty];
                var fieldNote = new FieldNote
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.FieldCharts[difficulty].Notes.Add(this.CreateChartButton(ref fieldChart, fieldChart.Notes.Count, fieldNote, "Note", Color.Red));
            }
            else if (noteType.Equals("Asset"))
            {
                var fieldChart = this.FieldCharts[difficulty];
                var fieldAsset = new FieldAsset
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.FieldCharts[difficulty].Assets.Add(this.CreateChartButton(ref fieldChart, fieldChart.Assets.Count, fieldAsset, "Asset", Color.Blue));
            }
            else if (noteType.Equals("Performer Note"))
            {
                var fieldChart = this.FieldCharts[difficulty];
                var performer = new PerformerNote<FieldLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.FieldCharts[difficulty].Performers.Add(this.CreateChartButton(ref fieldChart, fieldChart.Performers.Count, performer, "Performer", Color.Purple));
            }
        }

        #endregion Helper Methods
    }
}