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
    public partial class FieldChartComponent : UserControl
    {
        public FieldBattleChartManager FieldBattleChartManager;

        public ObservableCollection<MoMButton<FieldNote>> Notes = new ObservableCollection<MoMButton<FieldNote>>();
        public ObservableCollection<MoMButton<FieldAsset>> Assets = new ObservableCollection<MoMButton<FieldAsset>>();
        public ObservableCollection<MoMButton<PerformerNote<FieldLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<FieldLane>>>();
        public ObservableCollection<MoMButton<TimeShift<FieldLane>>> Times = new ObservableCollection<MoMButton<TimeShift<FieldLane>>>();

        // TODO Add ability to drag and drop notes ALREADY on the lanes
        // TODO Remove MoMButton from UI after deleting (That's why ObservableCollection?)
        // TODO Add default animations to different note types
        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public FieldChartComponent()
        {
            InitializeComponent();

            foreach(Panel lane in this.chartNotePanel.Controls)
            {
                lane.DragEnter += this.chartLane_DragEnter;
                lane.DragDrop += this.chartLane_DragDrop;
            }
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
                this.FieldBattleChartManager.CreateDroppedNote(panel, point, noteType);
            }
            else
            {
                this.FieldBattleChartManager.MoveChartNote(panel, point, data);
            }
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