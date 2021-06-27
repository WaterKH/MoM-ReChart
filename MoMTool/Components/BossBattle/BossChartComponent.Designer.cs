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
            this.chartNotePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartNotePanel
            // 
            this.chartNotePanel.AllowDrop = true;
            this.chartNotePanel.AutoScroll = true;
            this.chartNotePanel.Controls.Add(this.panelPlayerBottom);
            this.chartNotePanel.Controls.Add(this.panelPlayerTop);
            this.chartNotePanel.Controls.Add(this.panelPlayerCenter);
            this.chartNotePanel.Location = new System.Drawing.Point(0, 35);
            this.chartNotePanel.Name = "chartNotePanel";
            this.chartNotePanel.Size = new System.Drawing.Size(706, 348);
            this.chartNotePanel.TabIndex = 0;
            // 
            // panelPlayerBottom
            // 
            this.panelPlayerBottom.AllowDrop = true;
            this.panelPlayerBottom.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerBottom.Location = new System.Drawing.Point(0, 175);
            this.panelPlayerBottom.Name = "panelPlayerBottom";
            this.panelPlayerBottom.Size = new System.Drawing.Size(0, 19);
            this.panelPlayerBottom.TabIndex = 7;
            // 
            // panelPlayerTop
            // 
            this.panelPlayerTop.AllowDrop = true;
            this.panelPlayerTop.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerTop.Location = new System.Drawing.Point(0, 125);
            this.panelPlayerTop.Name = "panelPlayerTop";
            this.panelPlayerTop.Size = new System.Drawing.Size(0, 19);
            this.panelPlayerTop.TabIndex = 5;
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
            // performerCheckbox
            // 
            this.performerCheckbox.AutoSize = true;
            this.performerCheckbox.Checked = true;
            this.performerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performerCheckbox.Location = new System.Drawing.Point(327, 8);
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
            // MemoryChartComponent
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
            this.Controls.Add(this.notesCheckbox);
            this.Controls.Add(this.displayText);
            this.Controls.Add(this.chartNotePanel);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MemoryChartComponent";
            this.Size = new System.Drawing.Size(706, 384);
            this.chartNotePanel.ResumeLayout(false);
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
    }
}