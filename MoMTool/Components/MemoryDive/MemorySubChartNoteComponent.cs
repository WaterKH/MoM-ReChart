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
    public partial class MemorySubChartNoteComponent : UserControl
    {
        public MemoryChartComponent ParentChartComponent { get; set; }
        public MemoryDiveSubChartManager MemoryDiveSubChartManager { get; set; }

        public MemorySubChartNoteComponent()
        {
            InitializeComponent();

            this.memoryNoteComponent.modelDropdown.SelectedIndexChanged += this.modelDropdown_SelectedIndexChanged;
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.MemoryDiveSubChartManager.Close();
        }

        private void modelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem.ToString();

            var visible = item.Equals("HoldStart");
            var time = int.Parse(this.memoryNoteComponent.timeValue.Text);

            this.memoryNoteComponent.nextNote.Visible = visible;
            this.memoryNoteComponent.nextNoteDropdown.Visible = visible;

            if (visible)
            {
                var nextItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.MemoryNoteType.ToString() == "HoldEnd" && x.HitTime > time);
                this.memoryNoteComponent.nextNoteDropdown.Items.AddRange(nextItems.ToArray());
            }

            visible = item.Equals("HoldEnd");

            this.memoryNoteComponent.previousNote.Visible = visible;
            this.memoryNoteComponent.previousNoteDropdown.Visible = visible;

            if (visible)
            {
                var prevItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.MemoryNoteType.ToString() == "HoldStart" && x.HitTime < time);
                this.memoryNoteComponent.previousNoteDropdown.Items.AddRange(prevItems.ToArray());
            }

            this.memoryNoteComponent.swipeText.Visible = item.Equals("Swipe");
            this.memoryNoteComponent.swipeDropdown.Visible = item.Equals("Swipe");
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.memoryNoteComponent.memoryNoteGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex);
            var note = momButton.Note;

            note.NoteType = 0; // TODO Is this needed?
            note.HitTime = int.Parse(this.memoryNoteComponent.timeValue.Text);
            note.Lane = (MemoryLane)Enum.Parse(typeof(MemoryLane), this.memoryNoteComponent.laneDropdown.SelectedItem.ToString()); 
            note.MemoryNoteType = (MemoryNoteType)Enum.Parse(typeof(MemoryNoteType), this.memoryNoteComponent.modelDropdown.SelectedItem.ToString());

            if (note.MemoryNoteType == MemoryNoteType.HoldEnd)
                note.StartHoldNote = (MemoryNote)this.memoryNoteComponent.previousNoteDropdown.SelectedItem;
            else
                note.StartHoldNoteIndex = -1;

            if (note.MemoryNoteType == MemoryNoteType.HoldStart)
                note.EndHoldNote = (MemoryNote)this.memoryNoteComponent.nextNoteDropdown.SelectedItem;
            else
                note.EndHoldNoteIndex = -1;

            if (note.MemoryNoteType == MemoryNoteType.Swipe)
                note.SwipeDirection = (SwipeType)Enum.Parse(typeof(SwipeType), this.memoryNoteComponent.swipeDropdown.SelectedItem.ToString());
            else
                note.SwipeDirection = SwipeType.Up;

            ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex).Note = note;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(note.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, note.HitTime.ToString());

            momButton.Button.Image = this.MemoryDiveSubChartManager.ParentChartManager.GetImageForModelType(note.MemoryNoteType);
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.memoryNoteComponent.memoryNoteGroup.Text.Split(' ')[^1]);
            var note = this.ParentChartComponent.Notes.FirstOrDefault(x => x.Id == noteIndex);

            this.ParentChartComponent.RemoveFromLane(note.Note.Lane, note.Button);

            note.Button.Visible = false;
            note.Button = null;
            this.ParentChartComponent.Notes.Remove(note);

            for (int i = 0; i < this.ParentChartComponent.Notes.Count; ++i)
                this.ParentChartComponent.Notes[i].Id = i;
        }
    }
}