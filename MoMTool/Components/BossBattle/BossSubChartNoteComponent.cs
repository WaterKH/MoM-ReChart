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
        public int ChartOffset { get; set; }
        public int ChartLength { get; set; }
        public BossChartComponent ParentChartComponent;
        public BossBattleSubChartManager BossBattleSubChartManager;

        public BossSubChartNoteComponent()
        {
            InitializeComponent();
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.BossBattleSubChartManager.Close();
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.bossNoteComponent.bossNoteGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Notes[noteIndex];
            var note = momButton.Note;

            note.NoteType = 0; // TODO Is this needed?
            note.HitTime = int.Parse(this.bossNoteComponent.timeValue.Text);
            note.Lane = (BossLane)Enum.Parse(typeof(BossLane), this.bossNoteComponent.laneDropdown.SelectedItem.ToString());
            note.StartHoldNote = int.Parse(this.bossNoteComponent.nextNoteValue.Text);
            note.EndHoldNote = int.Parse(this.bossNoteComponent.previousNoteValue.Text);
            note.BossNoteType = (BossNoteType)Enum.Parse(typeof(BossNoteType), this.bossNoteComponent.modelDropdown.SelectedItem.ToString());

            ParentChartComponent.Notes[noteIndex].Note = note;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(note.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, note.HitTime.ToString());
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.bossNoteComponent.bossNoteGroup.Text.Split(' ')[^1]);

            this.ParentChartComponent.RemoveFromLane(this.ParentChartComponent.Notes[noteIndex].Note.Lane, this.ParentChartComponent.Notes[noteIndex].Button);

            this.ParentChartComponent.Notes[noteIndex].Button.Visible = false;
            this.ParentChartComponent.Notes[noteIndex].Button = null;
            this.ParentChartComponent.Notes.RemoveAt(noteIndex);
        }
    }
}