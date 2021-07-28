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
    public partial class OffsetComponent : UserControl
    {
        public dynamic ParentChartComponent { get; set; }
        public dynamic SubChartManager { get; set; }

        public OffsetComponent()
        {
            InitializeComponent();
        }


        private void closeOffset_Click(object sender, EventArgs e)
        {
            this.SubChartManager.Close();
        }

        private void saveOffset_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var offset = int.Parse(this.valueOffset.Text);

            if (this.ParentChartComponent.GetType() == typeof(FieldChartComponent))
            {
                ((FieldChartComponent)this.ParentChartComponent).FieldBattleChartManager.BeatManager.Offset = offset / Settings.ZoomVariable;
                ((FieldChartComponent)this.ParentChartComponent).FieldBattleChartManager.BeatManager.OffsetRemainder = offset % Settings.ZoomVariable;
            }
            else if (this.ParentChartComponent.GetType() == typeof(MemoryChartComponent))
            {
                ((MemoryChartComponent)this.ParentChartComponent).MemoryDiveChartManager.BeatManager.Offset = offset / Settings.ZoomVariable;
                ((MemoryChartComponent)this.ParentChartComponent).MemoryDiveChartManager.BeatManager.OffsetRemainder = offset % Settings.ZoomVariable;
            }
            else if (this.ParentChartComponent.GetType() == typeof(BossChartComponent))
            {
                ((BossChartComponent)this.ParentChartComponent).BossBattleChartManager.BeatManager.Offset = offset / Settings.ZoomVariable;
                ((BossChartComponent)this.ParentChartComponent).BossBattleChartManager.BeatManager.OffsetRemainder = offset % Settings.ZoomVariable;
            }
        }
    }
}