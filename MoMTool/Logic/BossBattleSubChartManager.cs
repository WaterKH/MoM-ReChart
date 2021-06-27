using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class BossBattleSubChartManager
    {
        public BossBattleChartManager ParentChartManager { get; set; }

        public dynamic BossSubChartComponent { get; set; }
        //public PerformerComponent PerformerComponent { get; set; }
        //public TimeShiftComponent TimeShiftComponent { get; set; }

        private readonly ToolTip toolTip;

        public BossBattleSubChartManager(BossBattleChartManager parentChartManager)
        {
            this.ParentChartManager = parentChartManager;
            this.toolTip = new ToolTip();
        }

        public void LoadSubChartComponent<TNoteType>(int id, TNoteType note) where TNoteType : Note<BossLane>
        {
            if (this.BossSubChartComponent != null)
            {
                this.Close();
            }

            // Switch on the type and load the correct subchart
            if (typeof(TNoteType) == typeof(BossNote))
                this.LoadSubChartComponent(id, (BossNote)(Note<BossLane>)note);
            else if (typeof(TNoteType) == typeof(PerformerNote<BossLane>))
                this.LoadSubChartComponent(id, (PerformerNote<BossLane>)(Note<BossLane>)note);
            else if (typeof(TNoteType) == typeof(TimeShift<BossLane>))
                this.LoadSubChartComponent(id, (TimeShift<BossLane>)(Note<BossLane>)note);
            else if (typeof(TNoteType) == typeof(BossDarkZone))
                this.LoadSubChartComponent(id, (BossDarkZone)(Note<BossLane>)note);

            this.ParentChartManager.BossCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.Add(this.BossSubChartComponent);
            this.ParentChartManager.BossCharts[this.ParentChartManager.CurrentDifficultyTab].Controls[^1].BringToFront();

            this.BossSubChartComponent.ParentChartComponent = this.ParentChartManager.BossCharts[this.ParentChartManager.CurrentDifficultyTab];
        }

        public void LoadSubChartComponent(int id, BossNote note)
        {
            this.BossSubChartComponent = new BossSubChartNoteComponent { Visible = true };
            this.BossSubChartComponent.BossBattleSubChartManager = this;
            
            this.BossSubChartComponent.bossNoteComponent.bossNoteGroup.Text = $"Boss Battle {id}";
            this.BossSubChartComponent.bossNoteComponent.timeValue.Text = note.HitTime.ToString();
            this.BossSubChartComponent.bossNoteComponent.laneDropdown.SelectedItem = note.Lane.ToString();
            this.BossSubChartComponent.bossNoteComponent.modelDropdown.SelectedItem = note.BossNoteType.ToString();
            this.BossSubChartComponent.bossNoteComponent.previousNoteValue.Text = note.StartHoldNote.ToString();
            this.BossSubChartComponent.bossNoteComponent.nextNoteValue.Text = note.EndHoldNote.ToString();
            this.BossSubChartComponent.bossNoteComponent.swipeDropdown.SelectedItem = note.SwipeDirection.ToString();
        }

        public void LoadSubChartComponent(int id, PerformerNote<BossLane> performer)
        {
            this.BossSubChartComponent = new PerformerComponent { Visible = true };
            this.BossSubChartComponent.SubChartManager = this;
            this.BossSubChartComponent.UpdateLane(typeof(BossLane));

            this.BossSubChartComponent.performerGroup.Text = $"Performer Note {id}";
            this.BossSubChartComponent.timeValue.Text = performer.HitTime.ToString();
            this.BossSubChartComponent.laneDropdown.SelectedItem = performer.Lane.ToString();
            this.BossSubChartComponent.typeDropdown.SelectedItem = performer.PerformerType.ToString();
        }

        public void LoadSubChartComponent(int id, TimeShift<BossLane> time)
        {
            this.BossSubChartComponent = new TimeShiftComponent { Visible = true };
            this.BossSubChartComponent.SubChartManager = this;

            this.BossSubChartComponent.timeShiftGroup.Text = $"Time Shift {id}";
            this.BossSubChartComponent.timeValue.Text = time.HitTime.ToString();
            this.BossSubChartComponent.speedValue.Text = time.Speed.ToString();
        }

        public void LoadSubChartComponent(int id, BossDarkZone darkZone)
        {
            this.BossSubChartComponent = new BossDarkZoneComponent { Visible = true };
            this.BossSubChartComponent.BossBattleSubChartManager = this;

            this.BossSubChartComponent.darkZoneGroup.Text = $"Dark Zone {id}";
            this.BossSubChartComponent.startTimeValue.Text = darkZone.HitTime.ToString();
            this.BossSubChartComponent.endTimeValue.Text = darkZone.EndTime.ToString();
            this.BossSubChartComponent.endAttackTimeValue.Text = darkZone.EndAttackTime.ToString();
        }

        public void SaveNote()
        {

        }

        public void Close()
        {
            this.ParentChartManager.BossCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.RemoveByKey(this.BossSubChartComponent.Name);
            this.BossSubChartComponent.Visible = false;
            this.BossSubChartComponent = null;
        }
    }
}