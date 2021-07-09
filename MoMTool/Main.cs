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
        public FieldBattleChartManager FieldBattleChartManager { get; set; } = null;
        public MemoryDiveChartManager MemoryDiveChartManager { get; set; } = null;
        public BossBattleChartManager BossBattleChartManager { get; set; } = null;

        public Main()
        {
            InitializeComponent();

            this.recompileFieldButton.Visible = false;

            this.noteListView.MouseDown += this.noteItem_MouseDown;
            this.difficultyControl.SelectedTab = this.tabProud;

            this.difficultyControl.Selected += (sender, args) =>
            {
                // Add an additional 49 as Difficulty -> Beginner: 49; Standard: 50; Proud: 51;
                if (this.FieldBattleChartManager != null)
                    this.FieldBattleChartManager.CurrentDifficultyTab = (Difficulty)(args.TabPageIndex + 49);
                else if (this.MemoryDiveChartManager != null)
                    this.MemoryDiveChartManager.CurrentDifficultyTab = (Difficulty)(args.TabPageIndex + 49);
                else if (this.BossBattleChartManager != null)
                    this.BossBattleChartManager.CurrentDifficultyTab = (Difficulty)(args.TabPageIndex + 49);
            };
        }

        private void recompileFieldSongButton_Click(object sender, EventArgs e)
        {
            this.FieldBattleChartManager.RecompileFieldBattleSongs();
        }

        private void recompileMemorySongButton_Click(object sender, EventArgs e)
        {
            this.MemoryDiveChartManager.RecompileMemoryDiveSongs();
        }

        private void recompileBossSongButton_Click(object sender, EventArgs e)
        {
            this.BossBattleChartManager.RecompileBossBattleSongs();
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            //if (this.zoomVariable < 100)
            //{
            //    this.zoomVariable *= 5;
            //}
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            //if (this.zoomVariable > 1)
            //{
            //    this.zoomVariable /= 5;
            //}
        }

        private void noteItem_MouseDown(object sender, MouseEventArgs e)
        {
            // Determines which item was selected.
            ListView lv = ((ListView)sender);
            var item = lv.GetItemAt(e.X, e.Y); // TODO Fix

            // Starts a drag-and-drop operation with that item.
            if (item != null)
            {
                lv.DoDragDrop(item.ToString(), DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void openFileExplorer_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                openFileDialog.Filter = "Music Files (*.decomp)|*.decomp|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            this.fileName.Text = filePath;

            this.Decompile();
        }

        private void clearChartButton_Click(object sender, EventArgs e)
        {
            if (this.FieldBattleChartManager != null)
                this.FieldBattleChartManager.FieldCharts.Values.ToList().ForEach(x => x.ResetChart());
            else if (this.MemoryDiveChartManager != null)
                this.MemoryDiveChartManager.MemoryCharts.Values.ToList().ForEach(x => x.ResetChart());
            else if (this.BossBattleChartManager != null)
                this.BossBattleChartManager.BossCharts.Values.ToList().ForEach(x => x.ResetChart());
        }

        private void deleteChartButton_Click(object sender, EventArgs e)
        {
            //this.MusicFile = null;

            //this.beginnerFieldChartComponent = null;
            //this.standardFieldChartComponent = null;
            //this.proudFieldChartComponent = null;

            this.recompileFieldButton.Visible = false;
            this.recompileMemoryButton.Visible = false;
            this.recompileBossButton.Visible = false;
        }

        #region Helper Methods

        private void Decompile()
        {
            if (string.IsNullOrEmpty(this.fileName.Text))
            {
                MessageBox.Show("Please specify a file name to decompile.", "Invalid File Name");
                return;
            }

            MusicFile musicFile = null;
            try
            {
                musicFile = new SongProcessor().ProcessSong(this.fileName.Text, this.debugCheckbox.Checked);
            }
            catch(Exception e)
            {
                MessageBox.Show("Please use the decompressed file that generates when using the Unity Asset Bundle Extractor (UABE).", "Invalid File Type");
                return;
            }

            var songType = musicFile.SongPositions.FirstOrDefault().Value.SongType;

            if (songType == SongType.FieldBattle)
            {
                this.recompileFieldButton.Visible = true;
                this.recompileMemoryButton.Visible = false;
                this.recompileBossButton.Visible = false;
            }
            else if (songType == SongType.MemoryDive)
            {
                this.recompileFieldButton.Visible = false;
                this.recompileMemoryButton.Visible = true;
                this.recompileBossButton.Visible = false;
            }
            else if (songType == SongType.BossBattle)
            {
                this.recompileFieldButton.Visible = false;
                this.recompileMemoryButton.Visible = false;
                this.recompileBossButton.Visible = true;
            }

            this.GenerateChartManager(songType, musicFile);

            switch (songType)
            {
                case SongType.FieldBattle:
                    this.FieldBattleChartManager.DecompileFieldBattleSongs();

                    this.PlaceCharts(this.FieldBattleChartManager.FieldCharts);

                    break;
                case SongType.MemoryDive:
                    this.MemoryDiveChartManager.DecompileMemoryDiveSongs();

                    this.PlaceCharts(this.MemoryDiveChartManager.MemoryCharts);

                    break;
                case SongType.BossBattle:
                    this.BossBattleChartManager.DecompileBossBattleSongs();

                    this.PlaceCharts(this.BossBattleChartManager.BossCharts);

                    break;
                default:
                    break;
            }
        }

        private void GenerateChartManager(SongType songType, MusicFile musicFile)
        {
            this.RemovePreviousChartManager();

            switch (songType)
            {
                case SongType.FieldBattle:
                    this.FieldBattleChartManager = new FieldBattleChartManager(musicFile);

                    this.noteListView.Items.AddRange(this.LoadFieldPreConfiguredNotes());
                    break;
                case SongType.MemoryDive:
                    this.MemoryDiveChartManager = new MemoryDiveChartManager(musicFile);

                    this.noteListView.Items.AddRange(this.LoadMemoryPreConfiguredNotes());
                    break;
                case SongType.BossBattle:
                    this.BossBattleChartManager = new BossBattleChartManager(musicFile);
                    
                    this.noteListView.Items.AddRange(this.LoadBossPreConfiguredNotes());
                    break;
                default:
                    break;
            }
        }

        private ListViewItem[] LoadFieldPreConfiguredNotes()
        {
            return new ListViewItem[]
            {
                //new ListViewItem { Text = "Field Note", Group = this.noteListView.Groups[0] },
                //new ListViewItem { Text = "Field Asset", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Performer Note", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Time Shift", Group = this.noteListView.Groups[0] },

                new ListViewItem { Text = "Common Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Aerial Common Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Uncommon Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Aerial Uncommon Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Multi Hit Ground Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Multi Hit Aerial Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Enemy Shooter Projectile", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Enemy Shooter", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Aerial Enemy Shooter Projectile", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Aerial Enemy Shooter", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Jumping Ground Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Jumping Aerial Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hidden Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hittable Aerial Uncommon Enemy", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Crystal Enemy Left", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Crystal Enemy Right", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Crystal Enemy Center", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Glide Note Start", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Glide Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Barrel", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Crate", Group = this.noteListView.Groups[1] },

                //new ListViewItem { Text = "Aerial Common Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Aerial Uncommon Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Multi Hit Aerial Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Shooter Projectile Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Aerial Shooter Projectile Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Aerial Shooter Arrow", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Crystal Right", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Crystal Left", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Crystal Center", Group = this.noteListView.Groups[2] },
                //new ListViewItem { Text = "Glide Arrow", Group = this.noteListView.Groups[2] },
            };
        }


        private ListViewItem[] LoadMemoryPreConfiguredNotes()
        {
            return new ListViewItem[]
            {
                //new ListViewItem { Text = "Memory Note", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Performer Note", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Time Shift", Group = this.noteListView.Groups[0] },

                new ListViewItem { Text = "Normal Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Up Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Right Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Down Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Left Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hold Start Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hold End Note", Group = this.noteListView.Groups[1] },
            };
        }

        private ListViewItem[] LoadBossPreConfiguredNotes()
        {
            return new ListViewItem[]
            {
                //new ListViewItem { Text = "Boss Note", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Performer Note", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Time Shift", Group = this.noteListView.Groups[0] },
                new ListViewItem { Text = "Dark Zone", Group = this.noteListView.Groups[0] },

                new ListViewItem { Text = "Normal Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Up Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Right Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Down Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Swipe Left Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hold Start Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Hold End Note", Group = this.noteListView.Groups[1] },
                new ListViewItem { Text = "Crystal Note", Group = this.noteListView.Groups[1] },
            };
        }


        private void RemovePreviousChartManager()
        {
            this.FieldBattleChartManager = null;
            this.BossBattleChartManager = null;
            this.MemoryDiveChartManager = null;

            this.noteListView.Items.Clear();
        }

        private void PlaceCharts<TControl>(Dictionary<Difficulty, TControl> charts) where TControl : UserControl
        {
            this.RemovePreviousCharts();

            this.tabBeginner.Controls.Add(charts[Difficulty.Beginner]);
            this.tabStandard.Controls.Add(charts[Difficulty.Standard]);
            this.tabProud.Controls.Add(charts[Difficulty.Proud]);
        }

        private void RemovePreviousCharts()
        {
            this.tabBeginner.Controls.Clear();
            this.tabStandard.Controls.Clear();
            this.tabProud.Controls.Clear();
        }

        #endregion Helper Methods
    }
}