using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class TimeShiftComponent : UserControl
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
            this.fieldTimeShiftGroup = new System.Windows.Forms.GroupBox();
            this.speedValue = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.deleteTimeShift = new System.Windows.Forms.Button();
            this.saveTimeShift = new System.Windows.Forms.Button();
            this.closeTime = new System.Windows.Forms.Button();
            this.fieldTimeShiftGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldTimeShiftGroup
            // 
            this.fieldTimeShiftGroup.Controls.Add(this.speedValue);
            this.fieldTimeShiftGroup.Controls.Add(this.speedLabel);
            this.fieldTimeShiftGroup.Controls.Add(this.msLabel);
            this.fieldTimeShiftGroup.Controls.Add(this.timeValue);
            this.fieldTimeShiftGroup.Controls.Add(this.timeLabel);
            this.fieldTimeShiftGroup.Location = new System.Drawing.Point(10, 27);
            this.fieldTimeShiftGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldTimeShiftGroup.Name = "fieldTimeShiftGroup";
            this.fieldTimeShiftGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldTimeShiftGroup.Size = new System.Drawing.Size(250, 134);
            this.fieldTimeShiftGroup.TabIndex = 0;
            this.fieldTimeShiftGroup.TabStop = false;
            this.fieldTimeShiftGroup.Text = "fieldTimeShiftGroup";
            // 
            // speedValue
            // 
            this.speedValue.Location = new System.Drawing.Point(57, 58);
            this.speedValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.speedValue.Name = "speedValue";
            this.speedValue.Size = new System.Drawing.Size(139, 23);
            this.speedValue.TabIndex = 4;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(3, 60);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(42, 15);
            this.speedLabel.TabIndex = 3;
            this.speedLabel.Text = "Speed:";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(199, 28);
            this.msLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(23, 15);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // timeValue
            // 
            this.timeValue.Location = new System.Drawing.Point(53, 27);
            this.timeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(139, 23);
            this.timeValue.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(3, 28);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(36, 15);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // deleteTimeShift
            // 
            this.deleteTimeShift.BackColor = System.Drawing.Color.Red;
            this.deleteTimeShift.Location = new System.Drawing.Point(122, 315);
            this.deleteTimeShift.Name = "deleteTimeShift";
            this.deleteTimeShift.Size = new System.Drawing.Size(106, 25);
            this.deleteTimeShift.TabIndex = 12;
            this.deleteTimeShift.Text = "Delete Time Shift";
            this.deleteTimeShift.UseVisualStyleBackColor = false;
            // 
            // saveTimeShift
            // 
            this.saveTimeShift.BackColor = System.Drawing.Color.LimeGreen;
            this.saveTimeShift.Location = new System.Drawing.Point(10, 315);
            this.saveTimeShift.Name = "saveTimeShift";
            this.saveTimeShift.Size = new System.Drawing.Size(106, 25);
            this.saveTimeShift.TabIndex = 11;
            this.saveTimeShift.Text = "Save Time Shift";
            this.saveTimeShift.UseVisualStyleBackColor = false;
            // 
            // closeTime
            // 
            this.closeTime.BackColor = System.Drawing.Color.Crimson;
            this.closeTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeTime.Location = new System.Drawing.Point(256, 0);
            this.closeTime.Name = "closeTime";
            this.closeTime.Size = new System.Drawing.Size(27, 23);
            this.closeTime.TabIndex = 10;
            this.closeTime.Text = "x";
            this.closeTime.UseVisualStyleBackColor = false;
            // 
            // TimeShiftComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.deleteTimeShift);
            this.Controls.Add(this.saveTimeShift);
            this.Controls.Add(this.closeTime);
            this.Controls.Add(this.fieldTimeShiftGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "TimeShiftComponent";
            this.Size = new System.Drawing.Size(288, 353);
            this.fieldTimeShiftGroup.ResumeLayout(false);
            this.fieldTimeShiftGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;

        public System.Windows.Forms.GroupBox fieldNoteGroup;
        public System.Windows.Forms.TextBox timeValue;
        public GroupBox fieldTimeShiftGroup;
        public TextBox speedValue;
        private Button deleteTimeShift;
        private Button saveTimeShift;
        private Button closeTime;
    }
}