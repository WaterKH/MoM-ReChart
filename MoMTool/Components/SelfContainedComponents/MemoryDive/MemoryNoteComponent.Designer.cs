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
            this.swipeText = new System.Windows.Forms.Label();
            this.swipeDropdown = new System.Windows.Forms.ComboBox();
            this.nextNoteValue = new System.Windows.Forms.TextBox();
            this.nextNote = new System.Windows.Forms.Label();
            this.previousNoteValue = new System.Windows.Forms.TextBox();
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
            this.memoryNoteGroup.Controls.Add(this.swipeText);
            this.memoryNoteGroup.Controls.Add(this.swipeDropdown);
            this.memoryNoteGroup.Controls.Add(this.nextNoteValue);
            this.memoryNoteGroup.Controls.Add(this.nextNote);
            this.memoryNoteGroup.Controls.Add(this.previousNoteValue);
            this.memoryNoteGroup.Controls.Add(this.previousNote);
            this.memoryNoteGroup.Controls.Add(this.modelLabel);
            this.memoryNoteGroup.Controls.Add(this.modelDropdown);
            this.memoryNoteGroup.Controls.Add(this.laneDropdown);
            this.memoryNoteGroup.Controls.Add(this.laneLabel);
            this.memoryNoteGroup.Controls.Add(this.msLabel);
            this.memoryNoteGroup.Controls.Add(this.timeValue);
            this.memoryNoteGroup.Controls.Add(this.timeLabel);
            this.memoryNoteGroup.Location = new System.Drawing.Point(0, 0);
            this.memoryNoteGroup.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.memoryNoteGroup.Name = "memoryNoteGroup";
            this.memoryNoteGroup.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.memoryNoteGroup.Size = new System.Drawing.Size(464, 373);
            this.memoryNoteGroup.TabIndex = 0;
            this.memoryNoteGroup.TabStop = false;
            this.memoryNoteGroup.Text = "memoryNoteGroup";
            // 
            // swipeText
            // 
            this.swipeText.AutoSize = true;
            this.swipeText.Location = new System.Drawing.Point(8, 304);
            this.swipeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.swipeText.Name = "swipeText";
            this.swipeText.Size = new System.Drawing.Size(140, 32);
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
            this.swipeDropdown.Location = new System.Drawing.Point(175, 300);
            this.swipeDropdown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.swipeDropdown.Name = "swipeDropdown";
            this.swipeDropdown.Size = new System.Drawing.Size(255, 40);
            this.swipeDropdown.TabIndex = 13;
            // 
            // nextNoteValue
            // 
            this.nextNoteValue.Location = new System.Drawing.Point(127, 298);
            this.nextNoteValue.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.nextNoteValue.Name = "nextNoteValue";
            this.nextNoteValue.Size = new System.Drawing.Size(71, 39);
            this.nextNoteValue.TabIndex = 12;
            // 
            // nextNote
            // 
            this.nextNote.AutoSize = true;
            this.nextNote.Location = new System.Drawing.Point(8, 304);
            this.nextNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nextNote.Name = "nextNote";
            this.nextNote.Size = new System.Drawing.Size(129, 32);
            this.nextNote.TabIndex = 11;
            this.nextNote.Text = "Next Note:";
            // 
            // previousNoteValue
            // 
            this.previousNoteValue.Location = new System.Drawing.Point(167, 297);
            this.previousNoteValue.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.previousNoteValue.Name = "previousNoteValue";
            this.previousNoteValue.Size = new System.Drawing.Size(71, 39);
            this.previousNoteValue.TabIndex = 10;
            // 
            // previousNote
            // 
            this.previousNote.AutoSize = true;
            this.previousNote.Location = new System.Drawing.Point(6, 303);
            this.previousNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previousNote.Name = "previousNote";
            this.previousNote.Size = new System.Drawing.Size(169, 32);
            this.previousNote.TabIndex = 9;
            this.previousNote.Text = "Previous Note:";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(6, 196);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(88, 32);
            this.modelLabel.TabIndex = 6;
            this.modelLabel.Text = "Model:";
            // 
            // modelDropdown
            // 
            this.modelDropdown.FormattingEnabled = true;
            this.modelDropdown.Items.AddRange(new object[] {
            "Normal",
            "Swipe",
            "HoldStart",
            "HoldEnd"});
            this.modelDropdown.Location = new System.Drawing.Point(173, 192);
            this.modelDropdown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.modelDropdown.Name = "modelDropdown";
            this.modelDropdown.Size = new System.Drawing.Size(255, 40);
            this.modelDropdown.TabIndex = 5;
            this.modelDropdown.SelectedIndexChanged += new System.EventHandler(this.modelDropdown_SelectedIndexChanged);
            // 
            // laneDropdown
            // 
            this.laneDropdown.FormattingEnabled = true;
            this.laneDropdown.Items.AddRange(new object[] {
            "PlayerLeft",
            "PlayerCenter",
            "PlayerRight"});
            this.laneDropdown.Location = new System.Drawing.Point(98, 126);
            this.laneDropdown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.laneDropdown.Name = "laneDropdown";
            this.laneDropdown.Size = new System.Drawing.Size(255, 40);
            this.laneDropdown.TabIndex = 4;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Location = new System.Drawing.Point(6, 128);
            this.laneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(69, 32);
            this.laneLabel.TabIndex = 3;
            this.laneLabel.Text = "Lane:";
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
            // MemoryNoteComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.memoryNoteGroup);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MemoryNoteComponent";
            this.Size = new System.Drawing.Size(464, 373);
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
        public TextBox nextNoteValue;
        private Label nextNote;
        public TextBox previousNoteValue;
        private Label previousNote;
        private Label swipeText;
        public ComboBox swipeDropdown;
    }
}