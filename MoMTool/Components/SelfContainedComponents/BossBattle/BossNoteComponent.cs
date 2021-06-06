using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossNoteComponent : UserControl
    {
        public BossNoteComponent()
        {
            InitializeComponent();
        }

        private void modelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem.ToString();

            this.nextNote.Visible = item.Equals("HoldStart");
            this.nextNoteValue.Visible = item.Equals("HoldStart");
            this.previousNote.Visible = item.Equals("HoldEnd");
            this.previousNoteValue.Visible = item.Equals("HoldEnd");
            this.swipeText.Visible = item.Equals("Swipe");
            this.swipeDropdown.Visible = item.Equals("Swipe");
        }
    }
}
