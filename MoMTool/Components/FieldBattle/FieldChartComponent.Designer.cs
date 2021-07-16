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
            this.holderPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.chartNotePanel.SuspendLayout();
            this.holderPanel.SuspendLayout();
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
            this.chartNotePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNotePanel.Location = new System.Drawing.Point(0, 0);
            this.chartNotePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartNotePanel.Name = "chartNotePanel";
            this.chartNotePanel.Size = new System.Drawing.Size(807, 468);
            this.chartNotePanel.TabIndex = 0;
            // 
            // panelOutOfMapRight
            // 
            this.panelOutOfMapRight.AllowDrop = true;
            this.panelOutOfMapRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapRight.Location = new System.Drawing.Point(0, 400);
            this.panelOutOfMapRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutOfMapRight.Name = "panelOutOfMapRight";
            this.panelOutOfMapRight.Size = new System.Drawing.Size(0, 25);
            this.panelOutOfMapRight.TabIndex = 12;
            // 
            // panelSomewhereRight
            // 
            this.panelSomewhereRight.AllowDrop = true;
            this.panelSomewhereRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereRight.Location = new System.Drawing.Point(0, 367);
            this.panelSomewhereRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSomewhereRight.Name = "panelSomewhereRight";
            this.panelSomewhereRight.Size = new System.Drawing.Size(0, 25);
            this.panelSomewhereRight.TabIndex = 11;
            // 
            // panelPlayerRight
            // 
            this.panelPlayerRight.AllowDrop = true;
            this.panelPlayerRight.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerRight.Location = new System.Drawing.Point(0, 233);
            this.panelPlayerRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerRight.Name = "panelPlayerRight";
            this.panelPlayerRight.Size = new System.Drawing.Size(0, 25);
            this.panelPlayerRight.TabIndex = 7;
            // 
            // panelPartyMember2Center
            // 
            this.panelPartyMember2Center.AllowDrop = true;
            this.panelPartyMember2Center.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Center.Location = new System.Drawing.Point(0, 300);
            this.panelPartyMember2Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Center.Name = "panelPartyMember2Center";
            this.panelPartyMember2Center.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember2Center.TabIndex = 9;
            // 
            // panelPartyMember1Center
            // 
            this.panelPartyMember1Center.AllowDrop = true;
            this.panelPartyMember1Center.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Center.Location = new System.Drawing.Point(0, 100);
            this.panelPartyMember1Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Center.Name = "panelPartyMember1Center";
            this.panelPartyMember1Center.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember1Center.TabIndex = 3;
            // 
            // panelPartyMember2Right
            // 
            this.panelPartyMember2Right.AllowDrop = true;
            this.panelPartyMember2Right.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Right.Location = new System.Drawing.Point(0, 333);
            this.panelPartyMember2Right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Right.Name = "panelPartyMember2Right";
            this.panelPartyMember2Right.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember2Right.TabIndex = 10;
            // 
            // panelPlayerLeft
            // 
            this.panelPlayerLeft.AllowDrop = true;
            this.panelPlayerLeft.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerLeft.Location = new System.Drawing.Point(0, 167);
            this.panelPlayerLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerLeft.Name = "panelPlayerLeft";
            this.panelPlayerLeft.Size = new System.Drawing.Size(0, 25);
            this.panelPlayerLeft.TabIndex = 5;
            // 
            // panelPartyMember2Left
            // 
            this.panelPartyMember2Left.AllowDrop = true;
            this.panelPartyMember2Left.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Left.Location = new System.Drawing.Point(0, 267);
            this.panelPartyMember2Left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Left.Name = "panelPartyMember2Left";
            this.panelPartyMember2Left.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember2Left.TabIndex = 8;
            // 
            // panelSomewhereLeft
            // 
            this.panelSomewhereLeft.AllowDrop = true;
            this.panelSomewhereLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereLeft.Location = new System.Drawing.Point(0, 33);
            this.panelSomewhereLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSomewhereLeft.Name = "panelSomewhereLeft";
            this.panelSomewhereLeft.Size = new System.Drawing.Size(0, 25);
            this.panelSomewhereLeft.TabIndex = 1;
            // 
            // panelPlayerCenter
            // 
            this.panelPlayerCenter.AllowDrop = true;
            this.panelPlayerCenter.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerCenter.Location = new System.Drawing.Point(0, 200);
            this.panelPlayerCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerCenter.Name = "panelPlayerCenter";
            this.panelPlayerCenter.Size = new System.Drawing.Size(0, 25);
            this.panelPlayerCenter.TabIndex = 6;
            // 
            // panelPartyMember1Left
            // 
            this.panelPartyMember1Left.AllowDrop = true;
            this.panelPartyMember1Left.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Left.Location = new System.Drawing.Point(0, 67);
            this.panelPartyMember1Left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Left.Name = "panelPartyMember1Left";
            this.panelPartyMember1Left.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember1Left.TabIndex = 2;
            // 
            // panelPartyMember1Right
            // 
            this.panelPartyMember1Right.AllowDrop = true;
            this.panelPartyMember1Right.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Right.Location = new System.Drawing.Point(0, 133);
            this.panelPartyMember1Right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Right.Name = "panelPartyMember1Right";
            this.panelPartyMember1Right.Size = new System.Drawing.Size(0, 25);
            this.panelPartyMember1Right.TabIndex = 4;
            // 
            // panelOutOfMapLeft
            // 
            this.panelOutOfMapLeft.AllowDrop = true;
            this.panelOutOfMapLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapLeft.Location = new System.Drawing.Point(0, 0);
            this.panelOutOfMapLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutOfMapLeft.Name = "panelOutOfMapLeft";
            this.panelOutOfMapLeft.Size = new System.Drawing.Size(0, 25);
            this.panelOutOfMapLeft.TabIndex = 0;
            // 
            // displayText
            // 
            this.displayText.AutoSize = true;
            this.displayText.Location = new System.Drawing.Point(240, 12);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(61, 20);
            this.displayText.TabIndex = 1;
            this.displayText.Text = "Display:";
            // 
            // notesCheckbox
            // 
            this.notesCheckbox.AutoSize = true;
            this.notesCheckbox.Checked = true;
            this.notesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notesCheckbox.Location = new System.Drawing.Point(302, 11);
            this.notesCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.notesCheckbox.Name = "notesCheckbox";
            this.notesCheckbox.Size = new System.Drawing.Size(70, 24);
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
            this.assetsCheckbox.Location = new System.Drawing.Point(374, 11);
            this.assetsCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.assetsCheckbox.Name = "assetsCheckbox";
            this.assetsCheckbox.Size = new System.Drawing.Size(72, 24);
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
            this.performerCheckbox.Location = new System.Drawing.Point(448, 11);
            this.performerCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.performerCheckbox.Name = "performerCheckbox";
            this.performerCheckbox.Size = new System.Drawing.Size(96, 24);
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
            this.songTypeDropdown.Location = new System.Drawing.Point(95, 8);
            this.songTypeDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.songTypeDropdown.Name = "songTypeDropdown";
            this.songTypeDropdown.Size = new System.Drawing.Size(138, 28);
            this.songTypeDropdown.TabIndex = 6;
            // 
            // songTypeText
            // 
            this.songTypeText.AutoSize = true;
            this.songTypeText.Location = new System.Drawing.Point(8, 12);
            this.songTypeText.Name = "songTypeText";
            this.songTypeText.Size = new System.Drawing.Size(81, 20);
            this.songTypeText.TabIndex = 7;
            this.songTypeText.Text = "Song Type:";
            // 
            // chartLengthText
            // 
            this.chartLengthText.AutoSize = true;
            this.chartLengthText.Location = new System.Drawing.Point(545, 12);
            this.chartLengthText.Name = "chartLengthText";
            this.chartLengthText.Size = new System.Drawing.Size(133, 20);
            this.chartLengthText.TabIndex = 8;
            this.chartLengthText.Text = "Chart Time (in ms):";
            // 
            // chartTimeValue
            // 
            this.chartTimeValue.Location = new System.Drawing.Point(675, 8);
            this.chartTimeValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartTimeValue.Name = "chartTimeValue";
            this.chartTimeValue.Size = new System.Drawing.Size(114, 27);
            this.chartTimeValue.TabIndex = 9;
            this.chartTimeValue.TextChanged += new System.EventHandler(this.chartTimeValue_TextChanged);
            // 
            // holderPanel
            // 
            this.holderPanel.AllowDrop = true;
            this.holderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.holderPanel.AutoSize = true;
            this.holderPanel.Controls.Add(this.panel2);
            this.holderPanel.Controls.Add(this.panel3);
            this.holderPanel.Controls.Add(this.panel4);
            this.holderPanel.Controls.Add(this.panel5);
            this.holderPanel.Controls.Add(this.panel6);
            this.holderPanel.Controls.Add(this.panel7);
            this.holderPanel.Controls.Add(this.panel8);
            this.holderPanel.Controls.Add(this.panel9);
            this.holderPanel.Controls.Add(this.panel10);
            this.holderPanel.Controls.Add(this.chartNotePanel);
            this.holderPanel.Controls.Add(this.panel11);
            this.holderPanel.Controls.Add(this.panel12);
            this.holderPanel.Controls.Add(this.panel13);
            this.holderPanel.Controls.Add(this.panel14);
            this.holderPanel.Location = new System.Drawing.Point(0, 44);
            this.holderPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.holderPanel.Name = "holderPanel";
            this.holderPanel.Size = new System.Drawing.Size(807, 468);
            this.holderPanel.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 25);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(0, 367);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 25);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.AllowDrop = true;
            this.panel4.BackColor = System.Drawing.Color.Pink;
            this.panel4.Location = new System.Drawing.Point(0, 233);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 25);
            this.panel4.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.AllowDrop = true;
            this.panel5.BackColor = System.Drawing.Color.PaleGreen;
            this.panel5.Location = new System.Drawing.Point(0, 300);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 25);
            this.panel5.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.AllowDrop = true;
            this.panel6.BackColor = System.Drawing.Color.PowderBlue;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 25);
            this.panel6.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.AllowDrop = true;
            this.panel7.BackColor = System.Drawing.Color.PaleGreen;
            this.panel7.Location = new System.Drawing.Point(0, 333);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 25);
            this.panel7.TabIndex = 10;
            // 
            // panel8
            // 
            this.panel8.AllowDrop = true;
            this.panel8.BackColor = System.Drawing.Color.Pink;
            this.panel8.Location = new System.Drawing.Point(0, 167);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(0, 25);
            this.panel8.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.AllowDrop = true;
            this.panel9.BackColor = System.Drawing.Color.PaleGreen;
            this.panel9.Location = new System.Drawing.Point(0, 267);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(0, 25);
            this.panel9.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.AllowDrop = true;
            this.panel10.BackColor = System.Drawing.SystemColors.Window;
            this.panel10.Location = new System.Drawing.Point(0, 33);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(0, 25);
            this.panel10.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.AllowDrop = true;
            this.panel11.BackColor = System.Drawing.Color.Pink;
            this.panel11.Location = new System.Drawing.Point(0, 200);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(0, 25);
            this.panel11.TabIndex = 6;
            // 
            // panel12
            // 
            this.panel12.AllowDrop = true;
            this.panel12.BackColor = System.Drawing.Color.PowderBlue;
            this.panel12.Location = new System.Drawing.Point(0, 67);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(0, 25);
            this.panel12.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.AllowDrop = true;
            this.panel13.BackColor = System.Drawing.Color.PowderBlue;
            this.panel13.Location = new System.Drawing.Point(0, 133);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(0, 25);
            this.panel13.TabIndex = 4;
            // 
            // panel14
            // 
            this.panel14.AllowDrop = true;
            this.panel14.BackColor = System.Drawing.SystemColors.Window;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(0, 25);
            this.panel14.TabIndex = 0;
            // 
            // FieldChartComponent
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.holderPanel);
            this.Controls.Add(this.chartTimeValue);
            this.Controls.Add(this.chartLengthText);
            this.Controls.Add(this.songTypeText);
            this.Controls.Add(this.songTypeDropdown);
            this.Controls.Add(this.performerCheckbox);
            this.Controls.Add(this.assetsCheckbox);
            this.Controls.Add(this.notesCheckbox);
            this.Controls.Add(this.displayText);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldChartComponent";
            this.Size = new System.Drawing.Size(807, 512);
            this.chartNotePanel.ResumeLayout(false);
            this.holderPanel.ResumeLayout(false);
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
        public FieldSubChartNoteComponent subChartComponent;
        private Panel holderPanel;
        public Panel panel2;
        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Panel panel6;
        public Panel panel7;
        public Panel panel8;
        public Panel panel9;
        public Panel panel10;
        public Panel panel11;
        public Panel panel12;
        public Panel panel13;
        public Panel panel14;
    }
}