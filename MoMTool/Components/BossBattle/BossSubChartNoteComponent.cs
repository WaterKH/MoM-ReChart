using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossSubChartNoteComponent : UserControl
    {
        public BossChartComponent ParentChartComponent { get; set; }
        public BossBattleSubChartManager BossBattleSubChartManager { get; set; }

        public BossSubChartNoteComponent()
        {
            InitializeComponent();

            this.bossNoteComponent.modelDropdown.SelectedIndexChanged += this.modelDropdown_SelectedIndexChanged;

            this.bossNoteComponent.nextNoteDropdown.DropDown += SelectClosestTime_DropDown;
            this.bossNoteComponent.previousNoteDropdown.DropDown += SelectClosestTime_DropDown;
        }

        private void SelectClosestTime_DropDown(object sender, EventArgs e)
        {
            if (this.bossNoteComponent.timeValue.Text != "" && ((ComboBox)sender).Items.Count > 1)
            {
                ((ComboBox)sender).Items.RemoveAt(0);
                ((ComboBox)sender).SelectedItem = ((ComboBox)sender).Items.Cast<BossNote>().Min(x => Math.Abs(int.Parse(this.bossNoteComponent.timeValue.Text) - x.HitTime));
                ((ComboBox)sender).Items.Insert(0, "");
            }
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.BossBattleSubChartManager.Close();
        }

        private void modelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem.ToString();

            var visible = item.Equals("HoldStart");
            var time = int.Parse(this.bossNoteComponent.timeValue.Text);

            this.bossNoteComponent.nextNote.Visible = visible;
            this.bossNoteComponent.nextNoteDropdown.Visible = visible;

            if (visible)
            {
                var nextItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.BossNoteType.ToString() == "HoldEnd" && x.HitTime > time).OrderBy(x => x.HitTime);
                this.bossNoteComponent.nextNoteDropdown.Items.AddRange(nextItems.ToArray());
            }

            visible = item.Equals("HoldEnd");

            this.bossNoteComponent.previousNote.Visible = visible;
            this.bossNoteComponent.previousNoteDropdown.Visible = visible;

            if (visible)
            {
                var prevItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.BossNoteType.ToString() == "HoldStart" && x.HitTime < time).OrderBy(x => x.HitTime);
                this.bossNoteComponent.previousNoteDropdown.Items.AddRange(prevItems.ToArray());
            }

            this.bossNoteComponent.swipeText.Visible = item.Equals("Swipe");
            this.bossNoteComponent.swipeDropdown.Visible = item.Equals("Swipe");
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.bossNoteComponent.bossNoteGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex);
            var note = momButton.Note;

            note.NoteType = 0; // TODO Is this needed?
            note.HitTime = int.Parse(this.bossNoteComponent.timeValue.Text);
            note.Lane = (BossLane)Enum.Parse(typeof(BossLane), this.bossNoteComponent.laneDropdown.SelectedItem.ToString());
            note.BossNoteType = (BossNoteType)Enum.Parse(typeof(BossNoteType), this.bossNoteComponent.modelDropdown.SelectedItem.ToString());

            if (note.BossNoteType == BossNoteType.HoldEnd)
            {
                note.StartHoldNote = this.bossNoteComponent.previousNoteDropdown.SelectedItem == "" ? null : (BossNote)this.bossNoteComponent.previousNoteDropdown.SelectedItem;

                if (note.StartHoldNote != null)
                    note.StartHoldNote.EndHoldNote = note;
            }
            else
                note.StartHoldNoteIndex = -1;

            if (note.BossNoteType == BossNoteType.HoldStart)
            {
                note.EndHoldNote = note.StartHoldNote = this.bossNoteComponent.nextNoteDropdown.SelectedItem == "" ? null : (BossNote)this.bossNoteComponent.nextNoteDropdown.SelectedItem;

                if (note.EndHoldNote != null)
                    note.EndHoldNote.StartHoldNote = note;   
            }
            else
                note.EndHoldNoteIndex = -1;

            if (note.BossNoteType == BossNoteType.Swipe)
                note.SwipeDirection = (SwipeType)Enum.Parse(typeof(SwipeType), this.bossNoteComponent.swipeDropdown.SelectedItem.ToString());
            else
                note.SwipeDirection = SwipeType.Up;

            ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex).Note = note;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(note.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, note.HitTime.ToString());

            momButton.Button.Image = this.BossBattleSubChartManager.ParentChartManager.GetImageForModelType(note.BossNoteType);
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.bossNoteComponent.bossNoteGroup.Text.Split(' ')[^1]);
            var momButton = this.ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex);

            this.ParentChartComponent.RemoveFromLane(momButton.Note.Lane, momButton.Button);

            momButton.Button.Visible = false;
            momButton.Button = null;
            this.ParentChartComponent.Notes.Remove(momButton);

            for (int i = 0; i < this.ParentChartComponent.Notes.Count; ++i)
                this.ParentChartComponent.Notes[i].Id = i;
        }
    }
}