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
    public partial class FieldAnimationComponent : UserControl
    {
        public FieldAnimationComponent()
        {
            InitializeComponent();
        }

        public void LoadAnimationComponent(MoMButton<FieldAnimation> anim)
        {
            this.fieldEnemyAnimationGroup.Text = $"Field Enemy Animation {anim.Id}";
            this.startTimeValue.Text = anim.Note.AnimationStartTime.ToString();
            this.laneDropdown.SelectedItem = anim.Note.Lane.ToString();
            this.endTimeValue.Text = anim.Note.AnimationEndTime.ToString();
            this.aerialFlag.Checked = anim.Note.AerialFlag;
            this.startNoteValue.Text = anim.Note.Previous.ToString();
            this.endNoteValue.Text = anim.Note.Next.ToString();
        }
    }
}
