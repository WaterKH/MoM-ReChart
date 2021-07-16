using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossChartComponent : UserControl
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
            this.panelPlayerBottom = new System.Windows.Forms.Panel();
            this.panelPlayerTop = new System.Windows.Forms.Panel();
            this.panelPlayerCenter = new System.Windows.Forms.Panel();
            this.displayText = new System.Windows.Forms.Label();
            this.notesCheckbox = new System.Windows.Forms.CheckBox();
            this.performerCheckbox = new System.Windows.Forms.CheckBox();
            this.songTypeDropdown = new System.Windows.Forms.ComboBox();
            this.songTypeText = new System.Windows.Forms.Label();
            this.chartLengthText = new System.Windows.Forms.Label();
            this.chartTimeValue = new System.Windows.Forms.TextBox();
            this.holderPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chartNotePanel.SuspendLayout();
            this.holderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartNotePanel
            // 
            this.chartNotePanel.AllowDrop = true;
            this.chartNotePanel.AutoScroll = true;
            this.chartNotePanel.Controls.Add(this.panelPlayerBottom);
            this.chartNotePanel.Controls.Add(this.panelPlayerTop);
            this.chartNotePanel.Controls.Add(this.panelPlayerCenter);
            this.chartNotePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNotePanel.Location = new System.Drawing.Point(0, 0);
            this.chartNotePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartNotePanel.Name = "chartNotePanel";
            this.chartNotePanel.Size = new System.Drawing.Size(807, 464);
            this.chartNotePanel.TabIndex = 0;
            // 
            // panelPlayerBottom
            // 
            this.panelPlayerBottom.AllowDrop = true;
            this.panelPlayerBottom.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerBottom.Location = new System.Drawing.Point(0, 233);
            this.panelPlayerBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerBottom.Name = "panelPlayerBottom";
            this.panelPlayerBottom.Size = new System.Drawing.Size(0, 25);
            this.panelPlayerBottom.TabIndex = 7;
            // 
            // panelPlayerTop
            // 
            this.panelPlayerTop.AllowDrop = true;
            this.panelPlayerTop.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerTop.Location = new System.Drawing.Point(0, 167);
            this.panelPlayerTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerTop.Name = "panelPlayerTop";
            this.panelPlayerTop.Size = new System.Drawing.Size(0, 25);
            this.panelPlayerTop.TabIndex = 5;
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
            // performerCheckbox
            // 
            this.performerCheckbox.AutoSize = true;
            this.performerCheckbox.Checked = true;
            this.performerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performerCheckbox.Location = new System.Drawing.Point(374, 11);
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
            this.songTypeText.Location = new System.Drawing.Point(15, 12);
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
            this.holderPanel.Controls.Add(this.chartNotePanel);
            this.holderPanel.Location = new System.Drawing.Point(0, 48);
            this.holderPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.holderPanel.Name = "holderPanel";
            this.holderPanel.Size = new System.Drawing.Size(807, 464);
            this.holderPanel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Location = new System.Drawing.Point(0, 233);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 25);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Location = new System.Drawing.Point(0, 167);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 25);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.AllowDrop = true;
            this.panel4.BackColor = System.Drawing.Color.Pink;
            this.panel4.Location = new System.Drawing.Point(0, 200);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 25);
            this.panel4.TabIndex = 6;
            // 
            // BossChartComponent
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
            this.Controls.Add(this.notesCheckbox);
            this.Controls.Add(this.displayText);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "BossChartComponent";
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
        public CheckBox performerCheckbox;
        public ComboBox songTypeDropdown;
        private Label songTypeText;
        private Label chartLengthText;
        public TextBox chartTimeValue;
        public Panel panelPlayerBottom;
        public Panel panelPlayerTop;
        public Panel panelPlayerCenter;
        private Panel holderPanel;
        public Panel panel2;
        public Panel panel3;
        public Panel panel4;
    }
}