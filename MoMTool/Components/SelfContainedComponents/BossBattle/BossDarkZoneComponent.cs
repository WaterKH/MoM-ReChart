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
    public partial class BossDarkZoneComponent : UserControl
    {
        public BossChartComponent ParentChartComponent { get; set; }
        public BossBattleSubChartManager BossBattleSubChartManager { get; set; }

        public BossDarkZoneComponent()
        {
            InitializeComponent();
        }


        private void closeDarkZone_Click(object sender, EventArgs e)
        {
            this.BossBattleSubChartManager.Close();
        }

        private void saveDarkZone_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.darkZoneGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.DarkZones[noteIndex];
            var darkZone = momButton.Note;

            darkZone.HitTime = int.Parse(this.startTimeValue.Text);
            darkZone.EndTime = int.Parse(this.endTimeValue.Text);
            darkZone.EndAttackTime = int.Parse(this.endAttackTimeValue.Text);

            ParentChartComponent.DarkZones[noteIndex].Note = darkZone;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(darkZone.Lane, momButton.Button);

            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, darkZone.HitTime.ToString());
        }

        private void deleteDarkZone_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.darkZoneGroup.Text.Split(' ')[^1]);

            this.ParentChartComponent.RemoveFromLane(this.ParentChartComponent.DarkZones[noteIndex].Note.Lane, this.ParentChartComponent.DarkZones[noteIndex].Button);

            this.ParentChartComponent.DarkZones[noteIndex].Button.Visible = false;
            this.ParentChartComponent.DarkZones[noteIndex].Button = null;
            this.ParentChartComponent.DarkZones.RemoveAt(noteIndex);
        }
    }
}