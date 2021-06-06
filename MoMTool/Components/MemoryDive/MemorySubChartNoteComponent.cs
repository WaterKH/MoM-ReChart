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
        public int ChartOffset { get; set; }
        public int ChartLength { get; set; }
        public MemoryChartComponent ParentChartComponent;
        public MemoryDiveSubChartManager MemoryDiveSubChartManager;

        public MemorySubChartNoteComponent()
        {
            InitializeComponent();
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.MemoryDiveSubChartManager.Close();
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.memoryNoteComponent.memoryNoteGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Notes[noteIndex];
            var note = momButton.Note;

            note.NoteType = 0; // TODO Is this needed?
            note.HitTime = int.Parse(this.memoryNoteComponent.timeValue.Text);
            note.Lane = (MemoryLane)Enum.Parse(typeof(MemoryLane), this.memoryNoteComponent.laneDropdown.SelectedItem.ToString());
            note.StartHoldNote = int.Parse(this.memoryNoteComponent.nextNoteValue.Text);
            note.EndHoldNote = int.Parse(this.memoryNoteComponent.previousNoteValue.Text);
            note.MemoryNoteType = (MemoryNoteType)Enum.Parse(typeof(MemoryNoteType), this.memoryNoteComponent.modelDropdown.SelectedItem.ToString());

            ParentChartComponent.Notes[noteIndex].Note = note;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(note.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, note.HitTime.ToString());
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.memoryNoteComponent.memoryNoteGroup.Text.Split(' ')[^1]);

            this.ParentChartComponent.RemoveFromLane(this.ParentChartComponent.Notes[noteIndex].Note.Lane, this.ParentChartComponent.Notes[noteIndex].Button);

            this.ParentChartComponent.Notes[noteIndex].Button.Visible = false;
            this.ParentChartComponent.Notes[noteIndex].Button = null;
            this.ParentChartComponent.Notes.RemoveAt(noteIndex);
        }
    }
}