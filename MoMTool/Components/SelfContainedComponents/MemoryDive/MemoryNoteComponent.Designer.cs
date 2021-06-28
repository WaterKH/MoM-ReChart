using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class MemoryNoteComponent : UserControl
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
            this.memoryNoteGroup = new System.Windows.Forms.GroupBox();
            this.nextNoteDropdown = new System.Windows.Forms.ComboBox();
            this.previousNoteDropdown = new System.Windows.Forms.ComboBox();
            this.swipeText = new System.Windows.Forms.Label();
            this.swipeDropdown = new System.Windows.Forms.ComboBox();
            this.nextNote = new System.Windows.Forms.Label();
            this.previousNote = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.modelDropdown = new System.Windows.Forms.ComboBox();
            this.laneDropdown = new System.Windows.Forms.ComboBox();
            this.laneLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.memoryNoteGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryNoteGroup
            // 
            this.memoryNoteGroup.Controls.Add(this.nextNoteDropdown);
            this.memoryNoteGroup.Controls.Add(this.previousNoteDropdown);
            this.memoryNoteGroup.Controls.Add(this.swipeText);
            this.memoryNoteGroup.Controls.Add(this.swipeDropdown);
            this.memoryNoteGroup.Controls.Add(this.nextNote);
            this.memoryNoteGroup.Controls.Add(this.previousNote);
            this.memoryNoteGroup.Controls.Add(this.modelLabel);
            this.memoryNoteGroup.Controls.Add(this.modelDropdown);
            this.memoryNoteGroup.Controls.Add(this.laneDropdown);
            this.memoryNoteGroup.Controls.Add(this.laneLabel);
            this.memoryNoteGroup.Controls.Add(this.msLabel);
            this.memoryNoteGroup.Controls.Add(this.timeValue);
            this.memoryNoteGroup.Controls.Add(this.timeLabel);
            this.memoryNoteGroup.Location = new System.Drawing.Point(0, 0);
            this.memoryNoteGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.memoryNoteGroup.Name = "memoryNoteGroup";
            this.memoryNoteGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.memoryNoteGroup.Size = new System.Drawing.Size(286, 291);
            this.memoryNoteGroup.TabIndex = 0;
            this.memoryNoteGroup.TabStop = false;
            this.memoryNoteGroup.Text = "memoryNoteGroup";
            // 
            // nextNoteDropdown
            // 
            this.nextNoteDropdown.DropDownWidth = 300;
            this.nextNoteDropdown.FormattingEnabled = true;
            this.nextNoteDropdown.Items.AddRange(new object[] {
            ""});
            this.nextNoteDropdown.Location = new System.Drawing.Point(22, 188);
            this.nextNoteDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.nextNoteDropdown.Name = "nextNoteDropdown";
            this.nextNoteDropdown.Size = new System.Drawing.Size(260, 28);
            this.nextNoteDropdown.TabIndex = 16;
            // 
            // previousNoteDropdown
            // 
            this.previousNoteDropdown.DropDownWidth = 300;
            this.previousNoteDropdown.FormattingEnabled = true;
            this.previousNoteDropdown.Items.AddRange(new object[] {
            ""});
            this.previousNoteDropdown.Location = new System.Drawing.Point(22, 188);
            this.previousNoteDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.previousNoteDropdown.Name = "previousNoteDropdown";
            this.previousNoteDropdown.Size = new System.Drawing.Size(260, 28);
            this.previousNoteDropdown.TabIndex = 15;
            // 
            // swipeText
            // 
            this.swipeText.AutoSize = true;
            this.swipeText.Location = new System.Drawing.Point(4, 160);
            this.swipeText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.swipeText.Name = "swipeText";
            this.swipeText.Size = new System.Drawing.Size(87, 20);
            this.swipeText.TabIndex = 14;
            this.swipeText.Text = "Swipe Type:";
            // 
            // swipeDropdown
            // 
            this.swipeDropdown.FormattingEnabled = true;
            this.swipeDropdown.Items.AddRange(new object[] {
            "Up",
            "Right",
            "Down",
            "Left"});
            this.swipeDropdown.Location = new System.Drawing.Point(106, 157);
            this.swipeDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.swipeDropdown.Name = "swipeDropdown";
            this.swipeDropdown.Size = new System.Drawing.Size(158, 28);
            this.swipeDropdown.TabIndex = 13;
            // 
            // nextNote
            // 
            this.nextNote.AutoSize = true;
            this.nextNote.Location = new System.Drawing.Point(2, 160);
            this.nextNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nextNote.Name = "nextNote";
            this.nextNote.Size = new System.Drawing.Size(80, 20);
            this.nextNote.TabIndex = 11;
            this.nextNote.Text = "Next Note:";
            // 
            // previousNote
            // 
            this.previousNote.AutoSize = true;
            this.previousNote.Location = new System.Drawing.Point(2, 160);
            this.previousNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previousNote.Name = "previousNote";
            this.previousNote.Size = new System.Drawing.Size(104, 20);
            this.previousNote.TabIndex = 9;
            this.previousNote.Text = "Previous Note:";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(4, 122);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(55, 20);
            this.modelLabel.TabIndex = 6;
            this.modelLabel.Text = "Model:";
            // 
            // modelDropdown
            // 
            this.modelDropdown.DropDownWidth = 201;
            this.modelDropdown.FormattingEnabled = true;
            this.modelDropdown.Items.AddRange(new object[] {
            "Normal",
            "Swipe",
            "HoldStart",
            "HoldEnd"});
            this.modelDropdown.Location = new System.Drawing.Point(63, 120);
            this.modelDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.modelDropdown.Name = "modelDropdown";
            this.modelDropdown.Size = new System.Drawing.Size(201, 28);
            this.modelDropdown.TabIndex = 5;
            // 
            // laneDropdown
            // 
            this.laneDropdown.FormattingEnabled = true;
            this.laneDropdown.Items.AddRange(new object[] {
            "PlayerLeft",
            "PlayerCenter",
            "PlayerRight"});
            this.laneDropdown.Location = new System.Drawing.Point(60, 79);
            this.laneDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.laneDropdown.Name = "laneDropdown";
            this.laneDropdown.Size = new System.Drawing.Size(158, 28);
            this.laneDropdown.TabIndex = 4;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Location = new System.Drawing.Point(4, 80);
            this.laneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(43, 20);
            this.laneLabel.TabIndex = 3;
            this.laneLabel.Text = "Lane:";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(228, 38);
            this.msLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(28, 20);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // timeValue
            // 
            this.timeValue.Location = new System.Drawing.Point(60, 36);
            this.timeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(158, 27);
            this.timeValue.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(4, 38);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(45, 20);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // MemoryNoteComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.memoryNoteGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MemoryNoteComponent";
            this.Size = new System.Drawing.Size(290, 299);
            this.memoryNoteGroup.ResumeLayout(false);
            this.memoryNoteGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;
        
        public System.Windows.Forms.GroupBox memoryNoteGroup;
        public System.Windows.Forms.TextBox timeValue;
        public System.Windows.Forms.ComboBox laneDropdown;
        public System.Windows.Forms.ComboBox modelDropdown;
        public Label nextNote;
        public Label previousNote;
        public Label swipeText;
        public ComboBox swipeDropdown;
        public ComboBox nextNoteDropdown;
        public ComboBox previousNoteDropdown;
    }
}