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
    public partial class FieldSubChartAssetComponent : UserControl
    {
        public int ChartOffset { get; set; }
        public int ChartLength { get; set; }
        public FieldChartComponent ParentChartComponent { get; set; }
        public FieldBattleSubChartManager FieldBattleSubChartManager { get; set; }

        public ObservableCollection<MoMButton<FieldAnimation>> Animations = new ObservableCollection<MoMButton<FieldAnimation>>();

        public FieldSubChartAssetComponent()
        {
            InitializeComponent();
        }

        private void closeAsset_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void saveAsset_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void deleteAsset_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
