using MoMMusicAnalysis;
using MoMTool.Components.SelfContainedComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldChartComponent : UserControl
    {
        public FieldBattleChartManager FieldBattleChartManager;

        public ObservableCollection<MoMButton<FieldNote>> Notes = new ObservableCollection<MoMButton<FieldNote>>();
        public ObservableCollection<MoMButton<FieldAsset>> Assets = new ObservableCollection<MoMButton<FieldAsset>>();
        public ObservableCollection<MoMButton<PerformerNote<FieldLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<FieldLane>>>();
        public ObservableCollection<MoMButton<TimeShift<FieldLane>>> Times = new ObservableCollection<MoMButton<TimeShift<FieldLane>>>();
        
        private Line closestTime;
        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public FieldChartComponent()
        {
            InitializeComponent();

            foreach (var lane in this.chartNotePanel.Controls)
            {
                if (lane.GetType() != typeof(Panel))
                    continue;

                ((Panel)lane).DragEnter += this.chartLane_DragEnter;
                ((Panel)lane).DragDrop += this.chartLane_DragDrop;
                ((Panel)lane).DragOver += this.chartLane_DragOver;
            }

            this.Dock = DockStyle.Fill;
        }

        private void chartTimeValue_TextChanged(object sender, EventArgs e)
        {
            var value = this.FieldBattleChartManager.CalculateChartLength(((TextBox)sender).Text);

            if (value == 0) 
                return;

            this.panelOutOfMapLeft.Width = value;
            this.panelSomewhereLeft.Width = value;
            this.panelPartyMember1Left.Width = value;
            this.panelPartyMember1Center.Width = value;
            this.panelPartyMember1Right.Width = value;
            this.panelPlayerLeft.Width = value;
            this.panelPlayerCenter.Width = value;
            this.panelPlayerRight.Width = value;
            this.panelPartyMember2Left.Width = value;
            this.panelPartyMember2Center.Width = value;
            this.panelPartyMember2Right.Width = value;
            this.panelSomewhereRight.Width = value;
            this.panelOutOfMapRight.Width = value;

            this.panelBeat.BringToFront();
            this.panelBeat.Width = value;
        }

        private void notesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;
            
            this.Notes.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void assetsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;

            this.Assets.ToList().ForEach(x => x.Button.Visible = value);
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
            {
                e.Effect = DragDropEffects.Copy;

                this.panelBeat.Visible = true;

                //this.panelBeat.Controls.Add(new Button { Location = new Point(e.X, e.Y) });
                this.panelBeat.Refresh();
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void chartLane_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                var positionX = this.panelBeat.PointToClient(Cursor.Position).X - this.FieldBattleChartManager.BeatManager.Offset;

                var updated = this.FieldBattleChartManager.BeatManager.DisplayChartBeats(this.Times.ToList(), this.panelBeat, positionX);

                if (updated)
                {
                    this.FieldBattleChartManager.BeatManager.WholeBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                    this.FieldBattleChartManager.BeatManager.HalfBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                    this.FieldBattleChartManager.BeatManager.QuarterBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                    this.FieldBattleChartManager.BeatManager.EighthBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                    this.FieldBattleChartManager.BeatManager.SixteenthBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                    this.FieldBattleChartManager.BeatManager.ThirtySecondBeats.ForEach(x => this.panelBeat.Controls.Add(x));
                }

                this.closestTime = Settings.CurrentBeat != Beat.None ? this.FieldBattleChartManager.BeatManager.SnapToBeat(positionX + this.FieldBattleChartManager.BeatManager.Offset) : null;

                this.panelBeat.Refresh();
            }
        }

        private void chartLane_DragDrop(object sender, DragEventArgs e)
        {
            this.panelBeat.Visible = false;
            this.panelBeat.Refresh();

            var panel = ((Panel)sender);
            Point point;
            var convert = false;

            if (this.closestTime == null)
            {
                point = new Point(e.X, e.Y);
                convert = true;
            }
            else
                point = new Point(this.closestTime.Location.X, 0);

            Debug.WriteLine($"{this.closestTime} {e.X}");
            var data = e.Data.GetData(DataFormats.Text).ToString();
            var noteType = Regex.Match(data, "ListViewItem: {(.*)}").Groups[1].Value;

            if (noteType != "")
            {
                this.FieldBattleChartManager.CreateDroppedNote(panel, noteType, convert, point, this.closestTime);
            }
            else
            {
                this.FieldBattleChartManager.MoveChartNote(panel, point, data, convert);
            }

            this.FieldBattleChartManager.BeatManager.ClearChartBeats(this.panelBeat);
        }

        public void ResetChart()
        {
            this.Notes.Clear();
            this.Assets.Clear();
            this.Performers.Clear();
            this.Times.Clear();

            this.ClearPanels();
        }

        private void ClearPanels()
        {
            this.panelOutOfMapLeft.Controls.Clear();
            this.panelSomewhereLeft.Controls.Clear();
            this.panelPartyMember1Left.Controls.Clear();
            this.panelPartyMember1Center.Controls.Clear();
            this.panelPartyMember1Right.Controls.Clear();
            this.panelPlayerLeft.Controls.Clear();
            this.panelPlayerCenter.Controls.Clear();
            this.panelPlayerRight.Controls.Clear();
            this.panelPartyMember2Left.Controls.Clear();
            this.panelPartyMember2Center.Controls.Clear();
            this.panelPartyMember2Right.Controls.Clear();
            this.panelSomewhereRight.Controls.Clear();
            this.panelOutOfMapRight.Controls.Clear();
        }

        public void AddToLane(FieldLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case FieldLane.OutOfMapLeft:
                    this.panelOutOfMapLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.SomewhereLeft:
                    this.panelSomewhereLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Left:
                    this.panelPartyMember1Left.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Center:
                    this.panelPartyMember1Center.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Right:
                    this.panelPartyMember1Right.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerRight:
                    this.panelPlayerRight.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Left:
                    this.panelPartyMember2Left.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Center:
                    this.panelPartyMember2Center.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Right:
                    this.panelPartyMember2Right.Controls.Add(buttonNote);
                    break;
                case FieldLane.SomewhereRight:
                    this.panelSomewhereRight.Controls.Add(buttonNote);
                    break;
                case FieldLane.OutOfMapRight:
                    this.panelOutOfMapRight.Controls.Add(buttonNote);
                    break;
                default:
                    break;
            }
        }

        public void RemoveFromLane(FieldLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case FieldLane.OutOfMapLeft:
                    this.panelOutOfMapLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.SomewhereLeft:
                    this.panelSomewhereLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Left:
                    this.panelPartyMember1Left.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Center:
                    this.panelPartyMember1Center.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Right:
                    this.panelPartyMember1Right.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerRight:
                    this.panelPlayerRight.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Left:
                    this.panelPartyMember2Left.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Center:
                    this.panelPartyMember2Center.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Right:
                    this.panelPartyMember2Right.Controls.Remove(buttonNote);
                    break;
                case FieldLane.SomewhereRight:
                    this.panelSomewhereRight.Controls.Remove(buttonNote);
                    break;
                case FieldLane.OutOfMapRight:
                    this.panelOutOfMapRight.Controls.Remove(buttonNote);
                    break;
                default:
                    break;
            }
        }
    }
}