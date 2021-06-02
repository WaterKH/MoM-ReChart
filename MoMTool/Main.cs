using MoMMusicAnalysis;
using MoMTool.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoMTool
{
    public partial class Main : Form
    {
        public MusicFile MusicFile;
        private int zoomVariable = 10;

        public Main()
        {
            InitializeComponent();

            this.ResetAllCharts();
            this.decompileButton.Visible = false;
            this.debugCheckbox.Visible = false;
            this.recompileButton.Visible = false;

            this.noteListBox.MouseDown += this.noteItem_MouseDown;
            this.difficultyControl.SelectedTab = this.proudTab;
        }

        private void decompileButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.fileName.Text))
            {
                MessageBox.Show("Please specify a file name to decompile");
                return;
            }
            
            this.recompileButton.Visible = true;

            this.MusicFile = new SongProcessor().ProcessSong(this.fileName.Text, this.debugCheckbox.Checked);

            foreach (var song in this.MusicFile.SongPositions.Values)
            {
                switch (song.SongType)
                {
                    case SongType.FieldBattle:

                        this.DecompileFieldBattleSong((FieldBattleSong)song);

                        break;
                    case SongType.BossBattle:
                        BossBattleSong bossBattleSong = (BossBattleSong)song;

                        break;
                    case SongType.MemoryDive:
                        MemoryDiveSong memoryDiveSong = (MemoryDiveSong)song;

                        break;
                    default:
                        break;
                }
            }
        }

        // TODO Add control + click/ drag slider to text to move time up and down (Reference PhotoShop or Kimpchuu)
        private void DecompileFieldBattleSong(FieldBattleSong song)
        {
            switch (song.Difficulty)
            {
                case Difficulty.Beginner:
                    this.beginnerFieldChartComponent.LoadChart(song);

                    break;
                case Difficulty.Standard:
                    this.standardFieldChartComponent.LoadChart(song);

                    break;
                case Difficulty.Proud:
                    this.proudFieldChartComponent.LoadChart(song);

                    break;
                default:
                    break;
            }
        }

        // Refactor to get away from processing too much in the button click event
        private void recompileFieldSongButton_Click(object sender, EventArgs e)
        {
            var musicFile = new MusicFile
            {
                FileName = MusicFile.FileName,
                Header = MusicFile.Header,
                SongPositions = new Dictionary<int, ISong>(),
                AssetPositions = new Dictionary<int, List<byte>>()
            };

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

                    switch (song.Difficulty)
                    {  
                        case Difficulty.Beginner:
                            
                            this.RecompileFieldSong(ref newSong, this.beginnerFieldChartComponent);

                            break;
                        case Difficulty.Standard:

                            this.RecompileFieldSong(ref newSong, this.standardFieldChartComponent);

                            break;

                        case Difficulty.Proud:

                            this.RecompileFieldSong(ref newSong, this.proudFieldChartComponent);

                            break;
                        default:
                            break;
                    }

                    musicFile.SongPositions.Add(i, newSong);

                    // method name length + method name + length size + Song length
                    var entireSongLength = (4 + 16 + 4 + newSong.Length);

                    musicFile.Header.Sections[i].Size = entireSongLength;
                    offset += entireSongLength;
                    offset += newSong.HasEmptyData ? 4 : 0;
                }
            }

            var fileSize = 0x1000 + offset;

            // Assign Header Information
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

            var fileData = musicFile.RecompileMusicFile();

            // Get File Name to Save to
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Write(fileData.ToArray());
                    myStream.Close();
                }
            }
        }

        private void RecompileFieldSong(ref FieldBattleSong newSong, FieldChartComponent chart)
        {
            var animations = chart.Notes.SelectMany(x => x.Note.Animations).Concat(chart.Assets.SelectMany(x => x.Note.Animations)).ToList();

            newSong.NoteCount = chart.Notes.Count;
            newSong.AnimationCount = animations.Count;
            newSong.AssetCount = chart.Assets.Count;
            newSong.PerformerCount = chart.Performers.Count;
            newSong.TimeShiftCount = chart.Times.Count;
            
            newSong.Unk1 = 1; // TODO Why?

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
                if (note.AerialFlag || (note.ModelType == FieldModelType.CrystalEnemyCenter || note.ModelType == FieldModelType.CrystalEnemyLeftRight))
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


            foreach (TimeShift time in chart.Times.Select(x => x.Note).OrderBy(x => x.ChangeTime))
            {
                newSong.TimeShifts.Add(time);
            }

            // Add Note + Header Lengths
            newSong.Length = (newSong.NoteCount * 0x48) + (newSong.AnimationCount * 0x3C) + (newSong.AssetCount * 0x44) + (newSong.PerformerCount * 0x30) + (newSong.TimeShiftCount * 0x08) + 0x28;
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (this.zoomVariable < 100)
            {
                this.zoomVariable *= 5;
            }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (this.zoomVariable > 1)
            {
                this.zoomVariable /= 5;
            }
        }

        private void noteItem_MouseDown(object sender, MouseEventArgs e)
        {
            // Determines which item was selected.
            ListBox lb = ((ListBox)sender);
            Point pt = new Point(e.X, e.Y);
            int index = lb.IndexFromPoint(pt);

            // Starts a drag-and-drop operation with that item.
            if (index >= 0)
            {
                lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void clearChartButton_Click(object sender, EventArgs e)
        {
            this.recompileButton.Enabled = false;

            this.ResetAllCharts();
        }

        private void ResetAllCharts()
        {
            this.beginnerFieldChartComponent.ResetChart();
            this.standardFieldChartComponent.ResetChart();
            this.proudFieldChartComponent.ResetChart();
        }

        private void openFileExplorer_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            this.fileName.Text = filePath;
        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {
            this.decompileButton.Visible = !string.IsNullOrEmpty(((TextBox)sender).Text);
            this.debugCheckbox.Visible = !string.IsNullOrEmpty(((TextBox)sender).Text);
        }
    }
}