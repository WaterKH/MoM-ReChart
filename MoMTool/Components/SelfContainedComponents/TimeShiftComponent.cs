using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class TimeShiftComponent : UserControl
    {
        public dynamic ParentChartComponent { get; set; }
        public dynamic SubChartManager { get; set; }

        public TimeShiftComponent()
        {
            InitializeComponent();
        }


        private void closeTime_Click(object sender, EventArgs e)
        {
            this.SubChartManager.Close();
        }

        private void saveTimeShift_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.timeShiftGroup.Text.Split(' ')[^1]);
            dynamic momButton = null;
            foreach (var time in this.ParentChartComponent.Times)
            {
                if (time.Id == noteIndex)
                {
                    momButton = time;
                    break;
                }
            }

            var timeShift = momButton.Note;

            timeShift.HitTime = int.Parse(this.timeValue.Text);
            timeShift.Speed = int.Parse(this.speedValue.Text);

            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(timeShift.Lane, momButton.Button);

            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, timeShift.HitTime.ToString());
        }

        private void deleteTimeShift_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.timeShiftGroup.Text.Split(' ')[^1]);
            dynamic momButton = null;
            foreach (var time in this.ParentChartComponent.Times)
            {
                if (time.Id == noteIndex)
                {
                    momButton = time;
                    break;
                }
            }

            this.ParentChartComponent.RemoveFromLane(momButton.Note.Lane, momButton.Button);

            momButton.Button.Visible = false;
            momButton.Button = null;
            this.ParentChartComponent.Times.Remove(momButton);

            for (int i = 0; i < this.ParentChartComponent.Times.Count; ++i)
                this.ParentChartComponent.Times[i].Id = i;
        }
    }
}