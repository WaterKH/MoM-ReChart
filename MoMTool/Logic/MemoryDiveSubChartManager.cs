﻿using MoMMusicAnalysis;
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
        }

        public void LoadSubChartComponent(int id, MemoryNote note)
        {
            this.MemorySubChartComponent = new MemorySubChartNoteComponent { Visible = true };
            this.MemorySubChartComponent.MemoryDiveSubChartManager = this;

            this.MemorySubChartComponent.memoryNoteComponent.memoryNoteGroup.Text = $"Memory Note {id}";
            this.MemorySubChartComponent.memoryNoteComponent.timeValue.Text = note.HitTime.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.laneDropdown.SelectedItem = note.Lane.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.modelDropdown.SelectedItem = note.MemoryNoteType.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.previousNoteValue.Text = note.StartHoldNote.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.nextNoteValue.Text = note.EndHoldNote.ToString();
            this.MemorySubChartComponent.memoryNoteComponent.swipeDropdown.SelectedItem = note.SwipeDirection.ToString();
        }

        public void LoadSubChartComponent(int id, PerformerNote<MemoryLane> performer)
        {
            this.MemorySubChartComponent = new PerformerComponent { Visible = true };
            
            this.MemorySubChartComponent.performerGroup.Text = $"Performer Note {id}";
            this.MemorySubChartComponent.timeValue.Text = performer.HitTime.ToString();
            this.MemorySubChartComponent.laneDropdown.SelectedItem = performer.Lane.ToString();
            this.MemorySubChartComponent.typeDropdown.SelectedItem = performer.PerformerType.ToString();
        }

        public void LoadSubChartComponent(int id, TimeShift<MemoryLane> time)
        {
            this.MemorySubChartComponent = new TimeShiftComponent { Visible = true };
            
            this.MemorySubChartComponent.timeShiftGroup.Text = $"Time Shift {id}";
            this.MemorySubChartComponent.timeValue.Text = time.HitTime.ToString();
            this.MemorySubChartComponent.speedValue.Text = time.Speed.ToString();
        }

        public void SaveNote()
        {

        }

        public void Close()
        {
            this.ParentChartManager.MemoryCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.RemoveByKey(this.MemorySubChartComponent.Name);
            this.MemorySubChartComponent.Visible = false;
            this.MemorySubChartComponent = null;
        }
    }
}