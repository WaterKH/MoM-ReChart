using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace MoMTool.Logic
{
    public partial class PerformerComponent : UserControl
    {
        public dynamic ParentChartComponent { get; set; }
        public dynamic SubChartManager { get; set; }
        public Type Lane { get; set; }

        public PerformerComponent()
        {
            InitializeComponent();
        }


        private void closePerformerNote_Click(object sender, EventArgs e)
        {
            this.SubChartManager.Close();
        }

        private void savePerformerNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.performerGroup.Text.Split(' ')[^1]);
            dynamic momButton = null;
            foreach (var perf in this.ParentChartComponent.Performers)
            {
                if (perf.Id == noteIndex)
                {
                    momButton = perf;
                    break;
                }
            }
            
            var performer = momButton.Note;

            performer.HitTime = int.Parse(this.timeValue.Text);
            if (Lane == typeof(FieldLane))
            {
                performer.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.laneDropdown.SelectedItem.ToString());
            }
            else if (Lane == typeof(MemoryLane))
            {
                performer.Lane = (MemoryLane)Enum.Parse(typeof(MemoryLane), this.laneDropdown.SelectedItem.ToString());
            }
            else if (Lane == typeof(BossLane))
            {
                performer.Lane = (BossLane)Enum.Parse(typeof(BossLane), this.laneDropdown.SelectedItem.ToString());
            }
            performer.PerformerType = (PerformerType)Enum.Parse(typeof(PerformerType), this.typeDropdown.SelectedItem.ToString());
            performer.DuplicateType = performer.PerformerType;

            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(performer.Lane, momButton.Button);

            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, performer.HitTime.ToString());

            momButton.Button.Image = this.SubChartManager.ParentChartManager.GetImageForModelType(performer.PerformerType);
        }

        private void deletePerformerNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.performerGroup.Text.Split(' ')[^1]);
            dynamic momButton = null;
            foreach (var perf in this.ParentChartComponent.Performers)
            {
                if (perf.Id == noteIndex)
                {
                    momButton = perf;
                    break;
                }
            }

            this.ParentChartComponent.RemoveFromLane(momButton.Note.Lane, momButton.Button);

            momButton.Button.Visible = false;
            momButton.Button = null;
            this.ParentChartComponent.Performers.Remove(momButton);
        }

        public void UpdateLane(Type laneType)
        {
            this.Lane = laneType;

            if (Lane == typeof(FieldLane))
            {
                this.laneDropdown.Items.AddRange(new object[] {
                    "OutOfMapLeft",
                    "SomewhereLeft",
                    "PartyMember1Left",
                    "PartyMember1Center",
                    "PartyMember1Right",
                    "PlayerLeft",
                    "PlayerCenter",
                    "PlayerRight",
                    "PartyMember2Left",
                    "PartyMember2Center",
                    "PartyMember2Right",
                    "SomewhereRight",
                    "OutOfMapRight"
                });
            }
            else if (Lane == typeof(MemoryLane))
            {
                this.laneDropdown.Items.AddRange(new object[] {
                    "PlayerLeft",
                    "PlayerCenter",
                    "PlayerRight"
                });
            }
            else if (Lane == typeof(BossLane))
            {
                this.laneDropdown.Items.AddRange(new object[] {
                    "PlayerTop",
                    "PlayerCenter",
                    "PlayerBottom"
                });
            }
        }
    }
}