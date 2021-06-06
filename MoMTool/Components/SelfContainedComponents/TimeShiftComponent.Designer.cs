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
            this.timeShiftGroup = new System.Windows.Forms.GroupBox();
            this.speedValue = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.deleteTimeShift = new System.Windows.Forms.Button();
            this.saveTimeShift = new System.Windows.Forms.Button();
            this.closeTime = new System.Windows.Forms.Button();
            this.timeShiftGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeShiftGroup
            // 
            this.timeShiftGroup.Controls.Add(this.speedValue);
            this.timeShiftGroup.Controls.Add(this.speedLabel);
            this.timeShiftGroup.Controls.Add(this.msLabel);
            this.timeShiftGroup.Controls.Add(this.timeValue);
            this.timeShiftGroup.Controls.Add(this.timeLabel);
            this.timeShiftGroup.Location = new System.Drawing.Point(19, 58);
            this.timeShiftGroup.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.timeShiftGroup.Name = "timeShiftGroup";
            this.timeShiftGroup.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.timeShiftGroup.Size = new System.Drawing.Size(464, 286);
            this.timeShiftGroup.TabIndex = 0;
            this.timeShiftGroup.TabStop = false;
            this.timeShiftGroup.Text = "fieldTimeShiftGroup";
            // 
            // speedValue
            // 
            this.speedValue.Location = new System.Drawing.Point(106, 124);
            this.speedValue.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.speedValue.Name = "speedValue";
            this.speedValue.Size = new System.Drawing.Size(255, 39);
            this.speedValue.TabIndex = 4;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(6, 128);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(86, 32);
            this.speedLabel.TabIndex = 3;
            this.speedLabel.Text = "Speed:";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(370, 60);
            this.msLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(45, 32);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // timeValue
            // 
            this.timeValue.Location = new System.Drawing.Point(98, 58);
            this.timeValue.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(255, 39);
            this.timeValue.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(6, 60);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(72, 32);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // deleteTimeShift
            // 
            this.deleteTimeShift.BackColor = System.Drawing.Color.Red;
            this.deleteTimeShift.Location = new System.Drawing.Point(227, 672);
            this.deleteTimeShift.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.deleteTimeShift.Name = "deleteTimeShift";
            this.deleteTimeShift.Size = new System.Drawing.Size(197, 53);
            this.deleteTimeShift.TabIndex = 12;
            this.deleteTimeShift.Text = "Delete Time Shift";
            this.deleteTimeShift.UseVisualStyleBackColor = false;
            // 
            // saveTimeShift
            // 
            this.saveTimeShift.BackColor = System.Drawing.Color.LimeGreen;
            this.saveTimeShift.Location = new System.Drawing.Point(19, 672);
            this.saveTimeShift.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.saveTimeShift.Name = "saveTimeShift";
            this.saveTimeShift.Size = new System.Drawing.Size(197, 53);
            this.saveTimeShift.TabIndex = 11;
            this.saveTimeShift.Text = "Save Time Shift";
            this.saveTimeShift.UseVisualStyleBackColor = false;
            // 
            // closeTime
            // 
            this.closeTime.BackColor = System.Drawing.Color.Crimson;
            this.closeTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeTime.Location = new System.Drawing.Point(475, 0);
            this.closeTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.closeTime.Name = "closeTime";
            this.closeTime.Size = new System.Drawing.Size(50, 49);
            this.closeTime.TabIndex = 10;
            this.closeTime.Text = "x";
            this.closeTime.UseVisualStyleBackColor = false;
            // 
            // TimeShiftComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.deleteTimeShift);
            this.Controls.Add(this.saveTimeShift);
            this.Controls.Add(this.closeTime);
            this.Controls.Add(this.timeShiftGroup);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "TimeShiftComponent";
            this.Size = new System.Drawing.Size(535, 753);
            this.timeShiftGroup.ResumeLayout(false);
            this.timeShiftGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;

        public System.Windows.Forms.GroupBox fieldNoteGroup;
        public System.Windows.Forms.TextBox timeValue;
        public GroupBox timeShiftGroup;
        public TextBox speedValue;
        private Button deleteTimeShift;
        private Button saveTimeShift;
        private Button closeTime;
    }
}