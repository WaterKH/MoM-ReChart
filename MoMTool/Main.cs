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
        public FieldBattleChartManager FieldBattleChartManager = null;
        public MemoryDiveChartManager MemoryDiveChartManager = null;
        public BossBattleChartManager BossBattleChartManager = null;

        public Main()
        {
            InitializeComponent();

            this.recompileButton.Visible = false;

            this.noteListBox.MouseDown += this.noteItem_MouseDown;
            this.difficultyControl.SelectedTab = this.tabProud;

            this.difficultyControl.Selected += (sender, args) =>
            {
                this.FieldBattleChartManager.CurrentDifficultyTab = (Difficulty)(args.TabPageIndex + 1);
            };
        }

        private void recompileFieldSongButton_Click(object sender, EventArgs e)
        {
            this.FieldBattleChartManager.RecompileFieldBattleSongs();
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
            ListBox lb = ((ListBox)sender);
            Point pt = new Point(e.X, e.Y);
            int index = lb.IndexFromPoint(pt);

            // Starts a drag-and-drop operation with that item.
            if (index >= 0)
            {
                lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Copy | DragDropEffects.Move);
            }
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

            this.Decompile();
        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {
            //this.decompileButton.Visible = !string.IsNullOrEmpty(((TextBox)sender).Text);
            //this.debugCheckbox.Visible = !string.IsNullOrEmpty(((TextBox)sender).Text);
        }

        private void clearChartButton_Click(object sender, EventArgs e)
        {
            if (this.FieldBattleChartManager != null)
                this.FieldBattleChartManager.FieldCharts.Values.ToList().ForEach(x => x.ResetChart());

            // TODO Memory and Boss
        }

        private void deleteChartButton_Click(object sender, EventArgs e)
        {
            //this.MusicFile = null;

            //this.beginnerFieldChartComponent = null;
            //this.standardFieldChartComponent = null;
            //this.proudFieldChartComponent = null;

            this.recompileButton.Visible = false;
        }

        #region Helper Methods

        private void Decompile()
        {
            if (string.IsNullOrEmpty(this.fileName.Text))
            {
                MessageBox.Show("Please specify a file name to decompile");
                return;
            }

            this.recompileButton.Visible = true;

            var musicFile = new SongProcessor().ProcessSong(this.fileName.Text, this.debugCheckbox.Checked);
            var songType = musicFile.SongPositions.FirstOrDefault().Value.SongType;

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

                    this.noteListBox.Items.AddRange(new object[] {
                    "Field Note",
                    "Asset",
                    "Performer Note"});
                    break;
                case SongType.MemoryDive:
                    this.MemoryDiveChartManager = new MemoryDiveChartManager(musicFile);

                    this.noteListBox.Items.AddRange(new object[] {
                    "Memory Note",
                    "Performer Note"});
                    break;
                case SongType.BossBattle:
                    this.BossBattleChartManager = new BossBattleChartManager(musicFile);
                    
                    this.noteListBox.Items.AddRange(new object[] {
                    "Boss Note",
                    "Performer Note"});
                    break;
                default:
                    break;
            }
        }

        private void RemovePreviousChartManager()
        {
            this.FieldBattleChartManager = null;
            this.BossBattleChartManager = null;
            this.MemoryDiveChartManager = null;

            this.noteListBox.Items.Clear();
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