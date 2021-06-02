using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldChartComponent : UserControl
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
            this.chartNotePanel = new System.Windows.Forms.Panel();
            this.panelOutOfMapRight = new System.Windows.Forms.Panel();
            this.panelSomewhereRight = new System.Windows.Forms.Panel();
            this.panelPlayerRight = new System.Windows.Forms.Panel();
            this.panelPartyMember2Center = new System.Windows.Forms.Panel();
            this.panelPartyMember1Center = new System.Windows.Forms.Panel();
            this.panelPartyMember2Right = new System.Windows.Forms.Panel();
            this.panelPlayerLeft = new System.Windows.Forms.Panel();
            this.panelPartyMember2Left = new System.Windows.Forms.Panel();
            this.panelSomewhereLeft = new System.Windows.Forms.Panel();
            this.panelPlayerCenter = new System.Windows.Forms.Panel();
            this.panelPartyMember1Left = new System.Windows.Forms.Panel();
            this.panelPartyMember1Right = new System.Windows.Forms.Panel();
            this.panelOutOfMapLeft = new System.Windows.Forms.Panel();
            this.displayText = new System.Windows.Forms.Label();
            this.notesCheckbox = new System.Windows.Forms.CheckBox();
            this.assetsCheckbox = new System.Windows.Forms.CheckBox();
            this.performerCheckbox = new System.Windows.Forms.CheckBox();
            this.songTypeDropdown = new System.Windows.Forms.ComboBox();
            this.songTypeText = new System.Windows.Forms.Label();
            this.chartLengthText = new System.Windows.Forms.Label();
            this.chartTimeValue = new System.Windows.Forms.TextBox();
            this.chartNotePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartNotePanel
            // 
            this.chartNotePanel.AllowDrop = true;
            this.chartNotePanel.AutoScroll = true;
            this.chartNotePanel.Controls.Add(this.panelOutOfMapRight);
            this.chartNotePanel.Controls.Add(this.panelSomewhereRight);
            this.chartNotePanel.Controls.Add(this.panelPlayerRight);
            this.chartNotePanel.Controls.Add(this.panelPartyMember2Center);
            this.chartNotePanel.Controls.Add(this.panelPartyMember1Center);
            this.chartNotePanel.Controls.Add(this.panelPartyMember2Right);
            this.chartNotePanel.Controls.Add(this.panelPlayerLeft);
            this.chartNotePanel.Controls.Add(this.panelPartyMember2Left);
            this.chartNotePanel.Controls.Add(this.panelSomewhereLeft);
            this.chartNotePanel.Controls.Add(this.panelPlayerCenter);
            this.chartNotePanel.Controls.Add(this.panelPartyMember1Left);
            this.chartNotePanel.Controls.Add(this.panelPartyMember1Right);
            this.chartNotePanel.Controls.Add(this.panelOutOfMapLeft);
            this.chartNotePanel.Location = new System.Drawing.Point(0, 35);
            this.chartNotePanel.Name = "chartNotePanel";
            this.chartNotePanel.Size = new System.Drawing.Size(706, 348);
            this.chartNotePanel.TabIndex = 0;
            // 
            // panelOutOfMapRight
            // 
            this.panelOutOfMapRight.AllowDrop = true;
            this.panelOutOfMapRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapRight.Location = new System.Drawing.Point(0, 300);
            this.panelOutOfMapRight.Name = "panelOutOfMapRight";
            this.panelOutOfMapRight.Size = new System.Drawing.Size(0, 19);
            this.panelOutOfMapRight.TabIndex = 12;
            // 
            // panelSomewhereRight
            // 
            this.panelSomewhereRight.AllowDrop = true;
            this.panelSomewhereRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereRight.Location = new System.Drawing.Point(0, 275);
            this.panelSomewhereRight.Name = "panelSomewhereRight";
            this.panelSomewhereRight.Size = new System.Drawing.Size(0, 19);
            this.panelSomewhereRight.TabIndex = 11;
            // 
            // panelPlayerRight
            // 
            this.panelPlayerRight.AllowDrop = true;
            this.panelPlayerRight.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerRight.Location = new System.Drawing.Point(0, 175);
            this.panelPlayerRight.Name = "panelPlayerRight";
            this.panelPlayerRight.Size = new System.Drawing.Size(0, 19);
            this.panelPlayerRight.TabIndex = 7;
            // 
            // panelPartyMember2Center
            // 
            this.panelPartyMember2Center.AllowDrop = true;
            this.panelPartyMember2Center.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Center.Location = new System.Drawing.Point(0, 225);
            this.panelPartyMember2Center.Name = "panelPartyMember2Center";
            this.panelPartyMember2Center.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember2Center.TabIndex = 9;
            // 
            // panelPartyMember1Center
            // 
            this.panelPartyMember1Center.AllowDrop = true;
            this.panelPartyMember1Center.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Center.Location = new System.Drawing.Point(0, 75);
            this.panelPartyMember1Center.Name = "panelPartyMember1Center";
            this.panelPartyMember1Center.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember1Center.TabIndex = 3;
            // 
            // panelPartyMember2Right
            // 
            this.panelPartyMember2Right.AllowDrop = true;
            this.panelPartyMember2Right.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Right.Location = new System.Drawing.Point(0, 250);
            this.panelPartyMember2Right.Name = "panelPartyMember2Right";
            this.panelPartyMember2Right.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember2Right.TabIndex = 10;
            // 
            // panelPlayerLeft
            // 
            this.panelPlayerLeft.AllowDrop = true;
            this.panelPlayerLeft.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerLeft.Location = new System.Drawing.Point(0, 125);
            this.panelPlayerLeft.Name = "panelPlayerLeft";
            this.panelPlayerLeft.Size = new System.Drawing.Size(0, 19);
            this.panelPlayerLeft.TabIndex = 5;
            // 
            // panelPartyMember2Left
            // 
            this.panelPartyMember2Left.AllowDrop = true;
            this.panelPartyMember2Left.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Left.Location = new System.Drawing.Point(0, 200);
            this.panelPartyMember2Left.Name = "panelPartyMember2Left";
            this.panelPartyMember2Left.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember2Left.TabIndex = 8;
            // 
            // panelSomewhereLeft
            // 
            this.panelSomewhereLeft.AllowDrop = true;
            this.panelSomewhereLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereLeft.Location = new System.Drawing.Point(0, 25);
            this.panelSomewhereLeft.Name = "panelSomewhereLeft";
            this.panelSomewhereLeft.Size = new System.Drawing.Size(0, 19);
            this.panelSomewhereLeft.TabIndex = 1;
            // 
            // panelPlayerCenter
            // 
            this.panelPlayerCenter.AllowDrop = true;
            this.panelPlayerCenter.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerCenter.Location = new System.Drawing.Point(0, 150);
            this.panelPlayerCenter.Name = "panelPlayerCenter";
            this.panelPlayerCenter.Size = new System.Drawing.Size(0, 19);
            this.panelPlayerCenter.TabIndex = 6;
            // 
            // panelPartyMember1Left
            // 
            this.panelPartyMember1Left.AllowDrop = true;
            this.panelPartyMember1Left.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Left.Location = new System.Drawing.Point(0, 50);
            this.panelPartyMember1Left.Name = "panelPartyMember1Left";
            this.panelPartyMember1Left.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember1Left.TabIndex = 2;
            // 
            // panelPartyMember1Right
            // 
            this.panelPartyMember1Right.AllowDrop = true;
            this.panelPartyMember1Right.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Right.Location = new System.Drawing.Point(0, 100);
            this.panelPartyMember1Right.Name = "panelPartyMember1Right";
            this.panelPartyMember1Right.Size = new System.Drawing.Size(0, 19);
            this.panelPartyMember1Right.TabIndex = 4;
            // 
            // panelOutOfMapLeft
            // 
            this.panelOutOfMapLeft.AllowDrop = true;
            this.panelOutOfMapLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapLeft.Location = new System.Drawing.Point(0, 0);
            this.panelOutOfMapLeft.Name = "panelOutOfMapLeft";
            this.panelOutOfMapLeft.Size = new System.Drawing.Size(0, 19);
            this.panelOutOfMapLeft.TabIndex = 0;
            // 
            // displayText
            // 
            this.displayText.AutoSize = true;
            this.displayText.Location = new System.Drawing.Point(210, 9);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(48, 15);
            this.displayText.TabIndex = 1;
            this.displayText.Text = "Display:";
            // 
            // notesCheckbox
            // 
            this.notesCheckbox.AutoSize = true;
            this.notesCheckbox.Checked = true;
            this.notesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notesCheckbox.Location = new System.Drawing.Point(264, 8);
            this.notesCheckbox.Name = "notesCheckbox";
            this.notesCheckbox.Size = new System.Drawing.Size(57, 19);
            this.notesCheckbox.TabIndex = 3;
            this.notesCheckbox.Text = "Notes";
            this.notesCheckbox.UseVisualStyleBackColor = true;
            this.notesCheckbox.CheckedChanged += new System.EventHandler(this.notesCheckbox_CheckedChanged);
            // 
            // assetsCheckbox
            // 
            this.assetsCheckbox.AutoSize = true;
            this.assetsCheckbox.Checked = true;
            this.assetsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.assetsCheckbox.Location = new System.Drawing.Point(327, 8);
            this.assetsCheckbox.Name = "assetsCheckbox";
            this.assetsCheckbox.Size = new System.Drawing.Size(59, 19);
            this.assetsCheckbox.TabIndex = 4;
            this.assetsCheckbox.Text = "Assets";
            this.assetsCheckbox.UseVisualStyleBackColor = true;
            this.assetsCheckbox.CheckedChanged += new System.EventHandler(this.assetsCheckbox_CheckedChanged);
            // 
            // performerCheckbox
            // 
            this.performerCheckbox.AutoSize = true;
            this.performerCheckbox.Checked = true;
            this.performerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performerCheckbox.Location = new System.Drawing.Point(392, 8);
            this.performerCheckbox.Name = "performerCheckbox";
            this.performerCheckbox.Size = new System.Drawing.Size(79, 19);
            this.performerCheckbox.TabIndex = 5;
            this.performerCheckbox.Text = "Performer";
            this.performerCheckbox.UseVisualStyleBackColor = true;
            this.performerCheckbox.CheckedChanged += new System.EventHandler(this.performerCheckbox_CheckedChanged);
            // 
            // songTypeDropdown
            // 
            this.songTypeDropdown.Enabled = false;
            this.songTypeDropdown.FormattingEnabled = true;
            this.songTypeDropdown.Items.AddRange(new object[] {
            "Field Battle",
            "Boss Battle",
            "Memory Dive"});
            this.songTypeDropdown.Location = new System.Drawing.Point(83, 6);
            this.songTypeDropdown.Name = "songTypeDropdown";
            this.songTypeDropdown.Size = new System.Drawing.Size(121, 23);
            this.songTypeDropdown.TabIndex = 6;
            // 
            // songTypeText
            // 
            this.songTypeText.AutoSize = true;
            this.songTypeText.Location = new System.Drawing.Point(13, 9);
            this.songTypeText.Name = "songTypeText";
            this.songTypeText.Size = new System.Drawing.Size(64, 15);
            this.songTypeText.TabIndex = 7;
            this.songTypeText.Text = "Song Type:";
            // 
            // chartLengthText
            // 
            this.chartLengthText.AutoSize = true;
            this.chartLengthText.Location = new System.Drawing.Point(477, 9);
            this.chartLengthText.Name = "chartLengthText";
            this.chartLengthText.Size = new System.Drawing.Size(108, 15);
            this.chartLengthText.TabIndex = 8;
            this.chartLengthText.Text = "Chart Time (in ms):";
            // 
            // chartTimeValue
            // 
            this.chartTimeValue.Location = new System.Drawing.Point(591, 6);
            this.chartTimeValue.Name = "chartTimeValue";
            this.chartTimeValue.Size = new System.Drawing.Size(100, 23);
            this.chartTimeValue.TabIndex = 9;
            this.chartTimeValue.TextChanged += new System.EventHandler(this.chartTimeValue_TextChanged);
            // 
            // FieldChartComponent
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.chartTimeValue);
            this.Controls.Add(this.chartLengthText);
            this.Controls.Add(this.songTypeText);
            this.Controls.Add(this.songTypeDropdown);
            this.Controls.Add(this.performerCheckbox);
            this.Controls.Add(this.assetsCheckbox);
            this.Controls.Add(this.notesCheckbox);
            this.Controls.Add(this.displayText);
            this.Controls.Add(this.chartNotePanel);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldChartComponent";
            this.Size = new System.Drawing.Size(706, 384);
            this.chartNotePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel chartNotePanel;
        private Label displayText;
        public CheckBox notesCheckbox;
        public CheckBox assetsCheckbox;
        public CheckBox performerCheckbox;
        public ComboBox songTypeDropdown;
        private Label songTypeText;
        private Label chartLengthText;
        public TextBox chartTimeValue;
        public Panel panelOutOfMapRight;
        public Panel panelSomewhereRight;
        public Panel panelPlayerRight;
        public Panel panelPartyMember2Center;
        public Panel panelPartyMember1Center;
        public Panel panelPartyMember2Right;
        public Panel panelPlayerLeft;
        public Panel panelPartyMember2Left;
        public Panel panelSomewhereLeft;
        public Panel panelPlayerCenter;
        public Panel panelPartyMember1Left;
        public Panel panelPartyMember1Right;
        public Panel panelOutOfMapLeft;
        private FieldSubChartNoteComponent subChartComponent;
    }
}