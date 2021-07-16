using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossChartComponent : UserControl
    {
        public BossBattleChartManager BossBattleChartManager;

        public ObservableCollection<MoMButton<BossNote>> Notes = new ObservableCollection<MoMButton<BossNote>>();
        public ObservableCollection<MoMButton<PerformerNote<BossLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<BossLane>>>();
        public ObservableCollection<MoMButton<TimeShift<BossLane>>> Times = new ObservableCollection<MoMButton<TimeShift<BossLane>>>();
        public ObservableCollection<MoMButton<BossDarkZone>> DarkZones = new ObservableCollection<MoMButton<BossDarkZone>>();

        public int ZoomVariable = 10;

        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public BossChartComponent()
        {
            InitializeComponent();

            foreach(Panel lane in chartNotePanel.Controls)
            {
                lane.DragEnter += this.chartLane_DragEnter;
                lane.DragDrop += this.chartLane_DragDrop;
            }

            this.Dock = DockStyle.Fill;
        }

        private void chartTimeValue_TextChanged(object sender, EventArgs e)
        {
            var value = this.BossBattleChartManager.CalculateChartLength(((TextBox)sender).Text);

            if (string.IsNullOrEmpty(((TextBox)sender).Text))
                return;

            this.panelPlayerTop.Width = value;
            this.panelPlayerCenter.Width = value;
            this.panelPlayerBottom.Width = value;
        }

        private void notesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;
            
            this.Notes.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void performerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;

            this.Performers.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void chartLane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void chartLane_DragDrop(object sender, DragEventArgs e)
        {
            var panel = ((Panel)sender);
            var point = new Point(e.X, e.Y);
            var data = e.Data.GetData(DataFormats.Text).ToString();
            var noteType = Regex.Match(data, "ListViewItem: {(.*)}").Groups[1].Value;

            if (noteType != "")
            {
                this.BossBattleChartManager.CreateDroppedNote(panel, point, noteType);
            }
            else
            {
                this.BossBattleChartManager.MoveChartNote(panel, point, data);
            }
        }

        public void ResetChart()
        {
            this.songTypeDropdown.SelectedItem = null;
            this.notesCheckbox.Checked = false;
            this.performerCheckbox.Checked = false;
            this.chartLengthText.Text = string.Empty;

            this.Notes.Clear();
            this.Performers.Clear();
            this.Times.Clear();

            this.ClearPanels();
        }

        private void ClearPanels()
        {
            this.panelPlayerTop.Controls.Clear();
            this.panelPlayerCenter.Controls.Clear();
            this.panelPlayerBottom.Controls.Clear();
        }

        public void AddToLane(BossLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case BossLane.PlayerTop:
                    this.panelPlayerTop.Controls.Add(buttonNote);
                    break;
                case BossLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Add(buttonNote);
                    break;
                case BossLane.PlayerBottom:
                    this.panelPlayerBottom.Controls.Add(buttonNote);
                    break;
                default:
                    break;
            }
        }

        public void RemoveFromLane(BossLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case BossLane.PlayerTop:
                    this.panelPlayerTop.Controls.Remove(buttonNote);
                    break;
                case BossLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Remove(buttonNote);
                    break;
                case BossLane.PlayerBottom:
                    this.panelPlayerBottom.Controls.Remove(buttonNote);
                    break;
                default:
                    break;
            }
        }
    }
}
