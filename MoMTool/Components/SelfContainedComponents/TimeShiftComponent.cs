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

            var momButton = ParentChartComponent.Times[noteIndex];
            var timeShift = momButton.Note;

            timeShift.HitTime = int.Parse(this.timeValue.Text);
            timeShift.Speed = int.Parse(this.speedValue.Text);

            ParentChartComponent.Times[noteIndex].Note = timeShift;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(timeShift.Lane, momButton.Button);

            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, timeShift.HitTime.ToString());
        }

        private void deleteTimeShift_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.timeShiftGroup.Text.Split(' ')[^1]);

            this.ParentChartComponent.RemoveFromLane(this.ParentChartComponent.Times[noteIndex].Note.Lane, this.ParentChartComponent.Times[noteIndex].Button);

            this.ParentChartComponent.Times[noteIndex].Button.Visible = false;
            this.ParentChartComponent.Times[noteIndex].Button = null;
            this.ParentChartComponent.Times.RemoveAt(noteIndex);
        }
    }
}