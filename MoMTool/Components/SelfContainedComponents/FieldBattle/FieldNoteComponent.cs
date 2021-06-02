using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldNoteComponent : UserControl
    {
        public FieldNoteComponent()
        {
            InitializeComponent();
        }

        private void modelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem.ToString();

            var visible = item.Contains("Multi") || item.Contains("Glide");
            
            this.nextNote.Visible = visible;
            this.nextNoteValue.Visible = visible;
            this.previousNote.Visible = visible;
            this.previousNoteValue.Visible = visible;

            visible = item.Equals("Projectile") || item.Equals("RareEnemyProjectile");

            this.projectileNote.Visible = visible;
            this.projectileNoteEnemy.Visible = visible;
        }
    }
}
