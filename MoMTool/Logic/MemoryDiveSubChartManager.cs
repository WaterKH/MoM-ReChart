using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class MemoryDiveSubChartManager
    {
        public MemoryDiveChartManager ParentChartManager { get; set; }
        public bool DisplayingSubChart { get; set; } = false;
        public dynamic MemorySubChartComponent { get; set; }
        //public PerformerComponent PerformerComponent { get; set; }
        //public TimeShiftComponent TimeShiftComponent { get; set; }

        private readonly ToolTip toolTip;

        public MemoryDiveSubChartManager(MemoryDiveChartManager parentChartManager)
        {
            this.ParentChartManager = parentChartManager;
            this.toolTip = new ToolTip();
        }

        public void LoadSubChartComponent<TNoteType>(int id, TNoteType note) where TNoteType : Note<MemoryLane>
        {
            if (this.MemorySubChartComponent != null)
            {
                this.Close();
            }

            // Switch on the type and load the correct subchart
            if (typeof(TNoteType) == typeof(MemoryNote))
                this.LoadSubChartComponent(id, (MemoryNote)(Note<MemoryLane>)note);
            else if (typeof(TNoteType) == typeof(PerformerNote<MemoryLane>))
                this.LoadSubChartComponent(id, (PerformerNote<MemoryLane>)(Note<MemoryLane>)note);
            else if (typeof(TNoteType) == typeof(TimeShift<MemoryLane>))
                this.LoadSubChartComponent(id, (TimeShift<MemoryLane>)(Note<MemoryLane>)note);

            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.Add(this.MemorySubChartComponent);
            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls[^1].BringToFront();
            
            this.DisplayingSubChart = true;
        }

        public void LoadSubChartComponent(int id, MemoryNote note)
        {
            this.MemorySubChartComponent = new MemorySubChartNoteComponent { Visible = true };
            this.MemorySubChartComponent.MemoryDiveSubChartManager = this;
            this.MemorySubChartComponent.ParentChartComponent = this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.MemorySubChartComponent.memoryNoteComponent.memoryNoteGroup.Text = $"Memory Note {id}";
            this.MemorySubChartComponent.memoryNoteComponent.timeValue.Text = note.HitTime.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.laneDropdown.SelectedItem = note.Lane.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.modelDropdown.SelectedItem = note.MemoryNoteType.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.previousNoteDropdown.SelectedItem = note.StartHoldNote;
            this.MemorySubChartComponent.memoryNoteComponent.nextNoteDropdown.SelectedItem = note.EndHoldNote;
            this.MemorySubChartComponent.memoryNoteComponent.swipeDropdown.SelectedItem = note.SwipeDirection.ToString();
        }

        public void LoadSubChartComponent(int id, PerformerNote<MemoryLane> performer)
        {
            this.MemorySubChartComponent = new PerformerComponent { Visible = true };
            this.MemorySubChartComponent.SubChartManager = this;
            this.MemorySubChartComponent.UpdateLane(typeof(MemoryLane));
            this.MemorySubChartComponent.ParentChartComponent = this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.MemorySubChartComponent.performerGroup.Text = $"Performer Note {id}";
            this.MemorySubChartComponent.timeValue.Text = performer.HitTime.ToString();
            this.MemorySubChartComponent.laneDropdown.SelectedItem = performer.Lane.ToString();
            this.MemorySubChartComponent.typeDropdown.SelectedItem = performer.PerformerType.ToString();
        }

        public void LoadSubChartComponent(int id, TimeShift<MemoryLane> time)
        {
            this.MemorySubChartComponent = new TimeShiftComponent { Visible = true };
            this.MemorySubChartComponent.SubChartManager = this;
            this.MemorySubChartComponent.ParentChartComponent = this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.MemorySubChartComponent.timeShiftGroup.Text = $"Time Shift {id}";
            this.MemorySubChartComponent.timeValue.Text = time.HitTime.ToString();
            this.MemorySubChartComponent.speedValue.Text = time.Speed.ToString();
        }

        public void LoadSubChartOffsetComponent()
        {
            if (this.MemorySubChartComponent != null)
            {
                this.Close();
            }

            this.MemorySubChartComponent = new OffsetComponent { Visible = true };
            this.MemorySubChartComponent.SubChartManager = this;
            this.MemorySubChartComponent.ParentChartComponent = this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.Add(this.MemorySubChartComponent);
            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls[^1].BringToFront();

            this.MemorySubChartComponent.valueOffset.Text = ((this.ParentChartManager.BeatManager.Offset * Settings.ZoomVariable) + this.ParentChartManager.BeatManager.OffsetRemainder).ToString();

            this.DisplayingSubChart = true;
        }

        public void Close()
        {
            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.RemoveByKey(this.MemorySubChartComponent.Name);
            this.MemorySubChartComponent.Visible = false;
            this.MemorySubChartComponent = null;

            this.DisplayingSubChart = false;
        }
    }
}