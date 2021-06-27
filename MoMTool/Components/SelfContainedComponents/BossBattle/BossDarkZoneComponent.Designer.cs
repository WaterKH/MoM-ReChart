using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossDarkZoneComponent : UserControl
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.darkZoneGroup = new System.Windows.Forms.GroupBox();
            this.msLabel = new System.Windows.Forms.Label();
            this.startTimeValue = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.closeDarkZone = new System.Windows.Forms.Button();
            this.deleteDarkZone = new System.Windows.Forms.Button();
            this.saveDarkZone = new System.Windows.Forms.Button();
            this.msLabel1 = new System.Windows.Forms.Label();
            this.endTimeValue = new System.Windows.Forms.TextBox();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.msLabel2 = new System.Windows.Forms.Label();
            this.endAttackTimeValue = new System.Windows.Forms.TextBox();
            this.attackEndLabel = new System.Windows.Forms.Label();
            this.darkZoneGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkZoneGroup
            // 
            this.darkZoneGroup.Controls.Add(this.msLabel2);
            this.darkZoneGroup.Controls.Add(this.endAttackTimeValue);
            this.darkZoneGroup.Controls.Add(this.attackEndLabel);
            this.darkZoneGroup.Controls.Add(this.msLabel1);
            this.darkZoneGroup.Controls.Add(this.endTimeValue);
            this.darkZoneGroup.Controls.Add(this.endTimeLabel);
            this.darkZoneGroup.Controls.Add(this.msLabel);
            this.darkZoneGroup.Controls.Add(this.startTimeValue);
            this.darkZoneGroup.Controls.Add(this.startTimeLabel);
            this.darkZoneGroup.Location = new System.Drawing.Point(12, 36);
            this.darkZoneGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.darkZoneGroup.Name = "darkZoneGroup";
            this.darkZoneGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.darkZoneGroup.Size = new System.Drawing.Size(300, 209);
            this.darkZoneGroup.TabIndex = 0;
            this.darkZoneGroup.TabStop = false;
            this.darkZoneGroup.Text = "darkZoneGroup";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(256, 37);
            this.msLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(28, 20);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // startTimeValue
            // 
            this.startTimeValue.Location = new System.Drawing.Point(88, 35);
            this.startTimeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.startTimeValue.Name = "startTimeValue";
            this.startTimeValue.Size = new System.Drawing.Size(158, 27);
            this.startTimeValue.TabIndex = 1;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(4, 38);
            this.startTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(80, 20);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // closeDarkZone
            // 
            this.closeDarkZone.BackColor = System.Drawing.Color.Crimson;
            this.closeDarkZone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeDarkZone.Location = new System.Drawing.Point(292, 0);
            this.closeDarkZone.Margin = new System.Windows.Forms.Padding(4);
            this.closeDarkZone.Name = "closeDarkZone";
            this.closeDarkZone.Size = new System.Drawing.Size(31, 31);
            this.closeDarkZone.TabIndex = 7;
            this.closeDarkZone.Text = "x";
            this.closeDarkZone.UseVisualStyleBackColor = false;
            this.closeDarkZone.Click += new System.EventHandler(this.closeDarkZone_Click);
            // 
            // deleteDarkZone
            // 
            this.deleteDarkZone.BackColor = System.Drawing.Color.Red;
            this.deleteDarkZone.Location = new System.Drawing.Point(140, 420);
            this.deleteDarkZone.Margin = new System.Windows.Forms.Padding(4);
            this.deleteDarkZone.Name = "deleteDarkZone";
            this.deleteDarkZone.Size = new System.Drawing.Size(121, 33);
            this.deleteDarkZone.TabIndex = 11;
            this.deleteDarkZone.Text = "Delete Zone";
            this.deleteDarkZone.UseVisualStyleBackColor = false;
            this.deleteDarkZone.Click += new System.EventHandler(this.deleteDarkZone_Click);
            // 
            // saveDarkZone
            // 
            this.saveDarkZone.BackColor = System.Drawing.Color.LimeGreen;
            this.saveDarkZone.Location = new System.Drawing.Point(12, 420);
            this.saveDarkZone.Margin = new System.Windows.Forms.Padding(4);
            this.saveDarkZone.Name = "saveDarkZone";
            this.saveDarkZone.Size = new System.Drawing.Size(121, 33);
            this.saveDarkZone.TabIndex = 10;
            this.saveDarkZone.Text = "Save Zone";
            this.saveDarkZone.UseVisualStyleBackColor = false;
            this.saveDarkZone.Click += new System.EventHandler(this.saveDarkZone_Click);
            // 
            // msLabel1
            // 
            this.msLabel1.AutoSize = true;
            this.msLabel1.Location = new System.Drawing.Point(250, 86);
            this.msLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel1.Name = "msLabel1";
            this.msLabel1.Size = new System.Drawing.Size(28, 20);
            this.msLabel1.TabIndex = 5;
            this.msLabel1.Text = "ms";
            // 
            // endTimeValue
            // 
            this.endTimeValue.Location = new System.Drawing.Point(82, 84);
            this.endTimeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.endTimeValue.Name = "endTimeValue";
            this.endTimeValue.Size = new System.Drawing.Size(158, 27);
            this.endTimeValue.TabIndex = 4;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(4, 87);
            this.endTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(74, 20);
            this.endTimeLabel.TabIndex = 3;
            this.endTimeLabel.Text = "End Time:";
            // 
            // msLabel2
            // 
            this.msLabel2.AutoSize = true;
            this.msLabel2.Location = new System.Drawing.Point(250, 170);
            this.msLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel2.Name = "msLabel2";
            this.msLabel2.Size = new System.Drawing.Size(28, 20);
            this.msLabel2.TabIndex = 8;
            this.msLabel2.Text = "ms";
            // 
            // endAttackTimeValue
            // 
            this.endAttackTimeValue.Location = new System.Drawing.Point(82, 168);
            this.endAttackTimeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.endAttackTimeValue.Name = "endAttackTimeValue";
            this.endAttackTimeValue.Size = new System.Drawing.Size(158, 27);
            this.endAttackTimeValue.TabIndex = 7;
            // 
            // attackEndLabel
            // 
            this.attackEndLabel.AutoSize = true;
            this.attackEndLabel.Location = new System.Drawing.Point(4, 142);
            this.attackEndLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.attackEndLabel.Name = "attackEndLabel";
            this.attackEndLabel.Size = new System.Drawing.Size(154, 20);
            this.attackEndLabel.TabIndex = 6;
            this.attackEndLabel.Text = "End Boss Attack Time:";
            // 
            // BossDarkZoneComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.deleteDarkZone);
            this.Controls.Add(this.saveDarkZone);
            this.Controls.Add(this.closeDarkZone);
            this.Controls.Add(this.darkZoneGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "BossDarkZoneComponent";
            this.Size = new System.Drawing.Size(329, 471);
            this.darkZoneGroup.ResumeLayout(false);
            this.darkZoneGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label startTimeLabel;

        public System.Windows.Forms.TextBox startTimeValue;
        public GroupBox darkZoneGroup;
        private Button closeDarkZone;
        private Button deleteDarkZone;
        private Button saveDarkZone;
        private Label msLabel2;
        public TextBox endAttackTimeValue;
        private Label attackEndLabel;
        private Label msLabel1;
        public TextBox endTimeValue;
        private Label endTimeLabel;
    }
}