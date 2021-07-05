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
            var offset = this. RecompileSections(ref musicFile);

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
                var fileSize1 = BitConverter.ToInt32(new byte[4] { 0x0, 0x0, fileSizes[2], 0x0 });
                var fileSize2 = BitConverter.ToInt32(new byte[4] { fileSizes[0], fileSizes[1], 0x0, 0x0 });

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
            var animations = chart.Notes.SelectMany(x => x.Note.Animations).Concat(chart.Assets.OrderBy(x => x.Note.HitTime).SelectMany(x => x.Note.Animations)).OrderBy(x => x.AnimationEndTime).ThenBy(x => x.AnimationStartTime).ToList();

            newSong.NoteCount = chart.Notes.Count;
            newSong.AnimationCount = animations.Count;
            newSong.AssetCount = chart.Assets.Count;
            newSong.PerformerCount = chart.Performers.Count;
            newSong.TimeShiftCount = chart.Times.Count;

            newSong.Unk1 = 1; // TODO Why? Is this the Identifier for FieldBattle?

            //var newNotes = new List<Note<FieldLane>>();
            //int count = 0;
            int aerialCrystalCount = 0;

            //foreach (var anim in animations.OrderBy(x => x.AnimationEndTime).ThenBy(x => x.AnimationStartTime))
            //{
            //    anim.Id = count++;
            //}

            foreach (FieldNote note in chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                var modelString = "";
                if (note.ModelType == FieldModelType.EnemyShooterProjectile && note.NoteType == 0)
                {
                    note.ModelType = FieldModelType.EnemyShooter;
                    modelString = "EnemyShooter";
                }
                else if (note.ModelType == FieldModelType.AerialEnemyShooterProjectile && note.NoteType == 0)
                {
                    note.ModelType = FieldModelType.AerialEnemyShooter;
                    modelString = "AerialEnemyShooter";
                }
                else if (note.ModelType == FieldModelType.Barrel && note.Unk3 == 1)
                {
                    note.ModelType = FieldModelType.Crate;
                    modelString = "Crate";
                }
                else
                    modelString = note.ModelType.ToString();
                
                var aerialFlag = (modelString.Contains("Aerial") && (modelString != "AerialEnemyShooterProjectile" || modelString != "HittableAerialUncommonEnemy")) ||
                    (modelString == "GlideNote" && note.PreviousEnemyNote == null);

                if (aerialFlag || (note.ModelType == FieldModelType.CrystalEnemyCenter || note.ModelType == FieldModelType.CrystalEnemyLeftRight))
                    note.AerialAndCrystalCounter = aerialCrystalCount++;
                else
                    note.AerialAndCrystalCounter = -1;

                if (!(note.ModelType == FieldModelType.MultiHitAerialEnemy || note.ModelType == FieldModelType.MultiHitGroundEnemy || note.ModelType == FieldModelType.GlideNote))
                {
                    note.PreviousEnemyNote = null;
                    note.NextEnemyNote = null;
                }

                if (!(note.ModelType == FieldModelType.AerialEnemyShooterProjectile || note.ModelType == FieldModelType.EnemyShooterProjectile))
                    note.ProjectileOriginNote = null;

                if (note.PreviousEnemyNote != null)
                    note.PreviousEnemyNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.PreviousEnemyNote);
                else
                    note.PreviousEnemyNoteIndex = -1;
                
                if (note.NextEnemyNote != null)
                    note.NextEnemyNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.NextEnemyNote);
                else
                    note.NextEnemyNoteIndex = -1;

                if (note.ProjectileOriginNote != null)
                    note.ProjectileOriginNoteIndex = chart.Notes.Select(x => x.Note).OrderBy(x => x.HitTime).ToList().IndexOf(note.ProjectileOriginNote);
                else
                    note.ProjectileOriginNoteIndex = -1;

                for (int i = 0; i < note.Animations.Count; ++i)
                {
                    var anim = note.Animations[i];

                    if (i > 0)
                    {
                        animations.ElementAt(animations.IndexOf(anim)).Previous = animations.IndexOf(note.Animations[i - 1]);
                    }

                    if (i < note.Animations.Count - 1)
                    {
                        animations.ElementAt(animations.IndexOf(anim)).Next = animations.IndexOf(note.Animations[i + 1]);
                    }
                }

                try
                {
                    note.AnimationReference = animations.IndexOf(note.Animations[0]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show($"Every Note needs an animation. Note Error at Time: {note.HitTime}");

                    return;
                }

                newSong.Notes.Add(note);
            }

            foreach (FieldAsset asset in chart.Assets.Select(x => x.Note).OrderBy(x => x.HitTime))
            {
                for (int i = 0; i < asset.Animations.Count; ++i)
                {
                    var anim = asset.Animations[i];

                    if (i > 0)
                    {
                        animations.ElementAt(animations.IndexOf(anim)).Previous = animations.IndexOf(asset.Animations[i - 1]);
                    }

                    if (i < asset.Animations.Count - 1)
                    {
                        animations.ElementAt(animations.IndexOf(anim)).Next = animations.IndexOf(asset.Animations[i + 1]);
                    }
                }

                try
                {
                    asset.AnimationReference = animations.IndexOf(asset.Animations[0]);
                }
                catch(ArgumentOutOfRangeException)
                {
                    MessageBox.Show($"Every Asset needs an animation. Asset Error at Time: {asset.HitTime}");

                    return;
                }

                newSong.FieldAssets.Add(asset);
            }

            foreach (var anim in animations.OrderBy(x => x.AnimationEndTime).ThenBy(x => x.AnimationStartTime))
            {
                newSong.FieldAnimations.Add(anim);
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

            foreach (var fieldNote in fieldChart.Notes.Select(x => x.Note))
            {
                if (fieldNote.PreviousEnemyNoteIndex != -1)
                    fieldNote.PreviousEnemyNote = fieldChart.Notes.OrderBy(x => x.Note.HitTime).ElementAt(fieldNote.PreviousEnemyNoteIndex).Note;

                if (fieldNote.NextEnemyNoteIndex != -1)
                    fieldNote.NextEnemyNote = fieldChart.Notes.OrderBy(x => x.Note.HitTime).ElementAt(fieldNote.NextEnemyNoteIndex).Note;

                if (fieldNote.ProjectileOriginNoteIndex != -1)
                    fieldNote.ProjectileOriginNote = fieldChart.Notes.OrderBy(x => x.Note.HitTime).ElementAt(fieldNote.ProjectileOriginNoteIndex).Note;
            }

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
            momButton.Button.MouseDown += (object sender, MouseEventArgs e) => { this.MouseDown(sender, e); };

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

        public void MoveChartNote(Panel panel, Point point, string buttonName)
        {
            var buttonType = buttonName.Split('-')[0];
            Point controlRelatedCoords = panel.PointToClient(point);

            var lane = (FieldLane)Enum.Parse(typeof(FieldLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);

            if (buttonType == "note")
            {
                var diff = this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime - (controlRelatedCoords.X * this.ZoomVariable);

                this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.FieldCharts[difficulty].AddToLane(lane, this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Note.Animations.ForEach(x =>
                {
                    x.AnimationEndTime -= diff;
                    x.AnimationStartTime -= diff;

                    if (x.AnimationStartTime <= 0)
                    {
                        x.AnimationStartTime = 0;
                    }
                });

                this.FieldCharts[difficulty].Notes.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "asset")
            {
                var diff = this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime - (controlRelatedCoords.X * this.ZoomVariable);

                this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.FieldCharts[difficulty].AddToLane(lane, this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Note.Animations.ForEach(x =>
                {
                    x.AnimationEndTime += diff;
                    x.AnimationStartTime += diff;

                    if (x.AnimationStartTime <= 0)
                    {
                        x.AnimationStartTime = 0;
                    }
                });

                this.FieldCharts[difficulty].Assets.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "performer")
            {
                this.FieldCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.FieldCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.FieldCharts[difficulty].AddToLane(lane, this.FieldCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.FieldCharts[difficulty].Performers.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
            }
            else if (buttonType == "time")
            {
                this.FieldCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Note.HitTime = controlRelatedCoords.X * this.ZoomVariable;
                this.FieldCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Location = new Point(controlRelatedCoords.X, 0);
                this.FieldCharts[difficulty].AddToLane(lane, this.FieldCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button);

                this.FieldCharts[difficulty].Times.FirstOrDefault(x => x.Button.Name == buttonName).Button.Focus();
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

            var lane = (FieldLane)Enum.Parse(typeof(FieldLane), panel.Name[5..]);
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), panel.Parent.Parent.Parent.Name[3..]);
            var hitTime = controlRelatedCoords.X * this.ZoomVariable;

            var fieldChart = this.FieldCharts[difficulty];

            if (noteType.Equals("Field Note"))
            {
                var fieldNote = this.CreateFieldNote(hitTime, lane);

                this.FieldCharts[difficulty].Notes.Add(this.CreateChartButton(ref fieldChart, fieldChart.Notes.Count, fieldNote, "Note", Color.Red));
            }
            //else if (noteType.Equals("Field Asset"))
            //{
            //    var fieldAsset = this.CreateFieldAsset(hitTime, lane);

            //    this.FieldCharts[difficulty].Assets.Add(this.CreateChartButton(ref fieldChart, fieldChart.Assets.Count, fieldAsset, "Asset", Color.Blue));
            //}
            else if (noteType.Equals("Performer Note"))
            {
                var performer = new PerformerNote<FieldLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = lane
                };

                this.FieldCharts[difficulty].Performers.Add(this.CreateChartButton(ref fieldChart, fieldChart.Performers.Count, performer, "Performer", Color.Purple));
            }
            else if (noteType.Equals("Time Shift"))
            {
                var time = new TimeShift<FieldLane>
                {
                    HitTime = controlRelatedCoords.X * this.ZoomVariable,
                    Lane = FieldLane.OutOfMapLeft
                };

                this.FieldCharts[difficulty].Times.Add(this.CreateChartButton(ref fieldChart, fieldChart.Times.Count, time, "Time", Color.Yellow));
            }
            else
            {
                if (this.CreateFieldNote(hitTime, lane, noteType, hitTime - 3000, hitTime) is var fieldNote && fieldNote != null)
                {
                    this.FieldCharts[difficulty].Notes.Add(this.CreateChartButton(ref fieldChart, fieldChart.Notes.Count, fieldNote, "Note", Color.Red));

                    var assetType = FieldAssetType.None;
                    var assetTime = 0;
                    // Create Asset For FieldNote
                    switch (noteType)
                    {
                        case "Aerial Common Enemy":
                            assetType = FieldAssetType.AerialCommonArrow;
                            break;
                        case "Aerial Uncommon Enemy":
                            assetType = FieldAssetType.AerialUncommonArrow;
                            break;
                        case "Multi Hit Aerial Enemy":
                            assetType = FieldAssetType.MultiHitAerialArrow;
                            break;
                        case "Enemy Shooter Projectile":
                            assetType = FieldAssetType.ShooterProjectileArrow;
                            assetTime = hitTime;
                            break;
                        case "Aerial Enemy Shooter Projectile":
                            assetType = FieldAssetType.AerialShooterProjectileArrow;
                            assetTime = hitTime;
                            break;
                        case "Aerial Enemy Shooter":
                            assetType = FieldAssetType.AerialShooterArrow;
                            break;
                        case "Jumping Aerial Enemy":
                            assetType = FieldAssetType.JumpingAerialArrow;
                            break;
                        case "Crystal Enemy Left":
                            assetType = FieldAssetType.CrystalRightLeft;
                            assetTime = hitTime + 1650;
                            lane = FieldLane.OutOfMapLeft;
                            break;
                        case "Crystal Enemy Right":
                            assetType = FieldAssetType.CrystalRightLeft;
                            assetTime = hitTime + 1650;
                            lane = FieldLane.OutOfMapRight;
                            break;
                        case "Crystal Enemy Center":
                            assetType = FieldAssetType.CrystalCenter;
                            assetTime = hitTime + 1800;
                            lane = FieldLane.PlayerCenter;
                            break;
                        case "Glide Note Start":
                            assetType = FieldAssetType.GlideArrow;
                            break;
                        default:
                            break;
                    }
                    if (assetType != FieldAssetType.None)
                    {
                        if (assetTime == 0)
                        {
                            assetTime = hitTime - 500;
                        }

                        if (this.CreateFieldAsset(assetTime, lane, assetType, assetTime - 3000, assetTime) is var fieldAsset && fieldAsset != null)
                        {
                            this.FieldCharts[difficulty].Assets.Add(this.CreateChartButton(ref fieldChart, fieldChart.Assets.Count, fieldAsset, "Asset", Color.Blue));
                        }
                    }
                }
                //else if (this.CreateFieldAsset(hitTime, lane, noteType, hitTime, hitTime - 3000) is var fieldAsset && fieldAsset != null)
                //{
                    //this.FieldCharts[difficulty].Assets.Add(this.CreateChartButton(ref fieldChart, fieldChart.Assets.Count, fieldAsset, "Asset", Color.Blue));
                //}
            }
        }

        public FieldNote CreateFieldNote(int time, FieldLane lane, string modelString = "", int animationStart = -1, int animationEnd = -1)
        {
            var model = FieldModelType.None;
            var noteType = 0;
            var unk3 = 0;
            if (modelString == "Enemy Shooter Projectile")
            {
                model = FieldModelType.EnemyShooterProjectile;
                noteType = 2;
                animationStart = time - 1200;
                animationEnd = time + 1200;
            }
            else if (modelString == "Aerial Enemy Shooter Projectile")
            {
                model = FieldModelType.AerialEnemyShooterProjectile;
                noteType = 2;
                animationStart = time - 2850;
                animationEnd = time + 2850;
            }
            else if (modelString == "Crate")
            {
                model = FieldModelType.Crate;
                noteType = 4;
                unk3 = 1;
            }
            if (modelString == "Barrel")
            {
                model = FieldModelType.Barrel;
                noteType = 4;
            }
            else if (modelString == "Crystal Enemy Right")
            {
                model = FieldModelType.CrystalEnemyLeftRight;
                noteType = 1;
                lane = FieldLane.PlayerLeft;
                animationStart = time - 4050;
                animationEnd = time;
            }
            else if (modelString == "Crystal Enemy Left")
            {
                model = FieldModelType.CrystalEnemyLeftRight;
                noteType = 1;
                lane = FieldLane.PlayerRight;
                animationStart = time - 4050;
                animationEnd = time;
            }
            else if (modelString == "Crystal Enemy Center")
            {
                model = FieldModelType.CrystalEnemyCenter;
                noteType = 1;
                lane = FieldLane.PlayerCenter;
                animationStart = time - 3200;
                animationEnd = time;
            }
            else if (modelString == "Glide Note Start" || modelString == "Glide Note")
            {
                model = FieldModelType.GlideNote;
                noteType = 3;
            }
            else
            {
                model = (FieldModelType)Enum.Parse(typeof(FieldModelType), modelString.Replace(" ", ""));
            }

            var aerialFlag = modelString.Contains("Aerial") && (modelString != "Hittable Aerial UncommonEnemy" && modelString != "Aerial Enemy Shooter Projectile") || 
                modelString.Contains("Glide");

            var fieldNote = new FieldNote
            {
                NoteType = noteType,
                HitTime = time,
                Lane = lane,
                AerialFlag = aerialFlag,
                ModelType = model,
                Unk3 = unk3
            };
            
            if (animationStart != -1 || animationEnd != -1)
            {
                fieldNote.Animations = new List<FieldAnimation> {
                    new FieldAnimation {
                        AnimationEndTime = animationEnd,
                        AnimationStartTime = animationStart,
                        Lane = lane,
                        AerialFlag = aerialFlag
                    }
                };


                if (fieldNote.Animations[0].AnimationStartTime < 0)
                    fieldNote.Animations[0].AnimationStartTime = 0;
            }

            return fieldNote;
        }

        public FieldAsset CreateFieldAsset(int time, FieldLane lane, FieldAssetType model, int animationStart = -1, int animationEnd = -1)
        {
            var jumpFlag = !(model == FieldAssetType.CrystalRightLeft || model == FieldAssetType.CrystalCenter);

            if (model == FieldAssetType.CrystalRightLeft)
            {
                animationStart = time - 2400;
                animationEnd = time;
            }
            else if (model == FieldAssetType.CrystalCenter)
            {
                animationStart = time - 2400;
                animationEnd = time;
            }

            var fieldAsset = new FieldAsset
            {
                JumpFlag = jumpFlag,
                Unk1 = model == FieldAssetType.CrystalRightLeft ? 1 : 0,
                HitTime = time,
                Lane = lane,
                ModelType = model
            };

            if (animationStart != -1 || animationEnd != -1)
            {
                fieldAsset.Animations = new List<FieldAnimation> {
                    new FieldAnimation {
                        AnimationEndTime = animationEnd,
                        AnimationStartTime = animationStart,
                        Lane = lane
                    }
                };


                if (fieldAsset.Animations[0].AnimationStartTime < 0)
                    fieldAsset.Animations[0].AnimationStartTime = 0;
            }

            return fieldAsset;
        }

        #endregion Helper Methods
    }
}