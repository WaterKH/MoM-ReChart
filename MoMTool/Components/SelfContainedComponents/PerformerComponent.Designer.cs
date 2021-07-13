using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class PerformerComponent : UserControl
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
            this.performerGroup = new System.Windows.Forms.GroupBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeDropdown = new System.Windows.Forms.ComboBox();
            this.laneDropdown = new System.Windows.Forms.ComboBox();
            this.laneLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.closePerformerNote = new System.Windows.Forms.Button();
            this.deletePerformerNote = new System.Windows.Forms.Button();
            this.savePerformerNote = new System.Windows.Forms.Button();
            this.performerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // performerGroup
            // 
            this.performerGroup.Controls.Add(this.typeLabel);
            this.performerGroup.Controls.Add(this.typeDropdown);
            this.performerGroup.Controls.Add(this.laneDropdown);
            this.performerGroup.Controls.Add(this.laneLabel);
            this.performerGroup.Controls.Add(this.msLabel);
            this.performerGroup.Controls.Add(this.timeValue);
            this.performerGroup.Controls.Add(this.timeLabel);
            this.performerGroup.Location = new System.Drawing.Point(12, 36);
            this.performerGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.performerGroup.Name = "performerGroup";
            this.performerGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.performerGroup.Size = new System.Drawing.Size(286, 180);
            this.performerGroup.TabIndex = 0;
            this.performerGroup.TabStop = false;
            this.performerGroup.Text = "fieldPerformerGroup";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(4, 122);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(43, 20);
            this.typeLabel.TabIndex = 6;
            this.typeLabel.Text = "Type:";
            // 
            // typeDropdown
            // 
            this.typeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDropdown.FormattingEnabled = true;
            this.typeDropdown.Items.AddRange(new object[] {
            "L2",
            "R2",
            "Up",
            "Down",
            "Left",
            "Right",
            "Ability",
            "Jump",
            "Action"});
            this.typeDropdown.Location = new System.Drawing.Point(106, 120);
            this.typeDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.typeDropdown.Name = "typeDropdown";
            this.typeDropdown.Size = new System.Drawing.Size(158, 28);
            this.typeDropdown.TabIndex = 5;
            // 
            // laneDropdown
            // 
            this.laneDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.laneDropdown.FormattingEnabled = true;
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
            // closePerformerNote
            // 
            this.closePerformerNote.BackColor = System.Drawing.Color.Crimson;
            this.closePerformerNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closePerformerNote.Location = new System.Drawing.Point(292, 0);
            this.closePerformerNote.Margin = new System.Windows.Forms.Padding(4);
            this.closePerformerNote.Name = "closePerformerNote";
            this.closePerformerNote.Size = new System.Drawing.Size(31, 31);
            this.closePerformerNote.TabIndex = 7;
            this.closePerformerNote.Text = "x";
            this.closePerformerNote.UseVisualStyleBackColor = false;
            this.closePerformerNote.Click += new System.EventHandler(this.closePerformerNote_Click);
            // 
            // deletePerformerNote
            // 
            this.deletePerformerNote.BackColor = System.Drawing.Color.Red;
            this.deletePerformerNote.Location = new System.Drawing.Point(140, 420);
            this.deletePerformerNote.Margin = new System.Windows.Forms.Padding(4);
            this.deletePerformerNote.Name = "deletePerformerNote";
            this.deletePerformerNote.Size = new System.Drawing.Size(121, 33);
            this.deletePerformerNote.TabIndex = 11;
            this.deletePerformerNote.Text = "Delete Note";
            this.deletePerformerNote.UseVisualStyleBackColor = false;
            this.deletePerformerNote.Click += new System.EventHandler(this.deletePerformerNote_Click);
            // 
            // savePerformerNote
            // 
            this.savePerformerNote.BackColor = System.Drawing.Color.LimeGreen;
            this.savePerformerNote.Location = new System.Drawing.Point(12, 420);
            this.savePerformerNote.Margin = new System.Windows.Forms.Padding(4);
            this.savePerformerNote.Name = "savePerformerNote";
            this.savePerformerNote.Size = new System.Drawing.Size(121, 33);
            this.savePerformerNote.TabIndex = 10;
            this.savePerformerNote.Text = "Save Note";
            this.savePerformerNote.UseVisualStyleBackColor = false;
            this.savePerformerNote.Click += new System.EventHandler(this.savePerformerNote_Click);
            // 
            // PerformerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.deletePerformerNote);
            this.Controls.Add(this.savePerformerNote);
            this.Controls.Add(this.closePerformerNote);
            this.Controls.Add(this.performerGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "PerformerComponent";
            this.Size = new System.Drawing.Size(329, 471);
            this.performerGroup.ResumeLayout(false);
            this.performerGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;

        public System.Windows.Forms.TextBox timeValue;
        public System.Windows.Forms.ComboBox laneDropdown;
        public System.Windows.Forms.ComboBox typeDropdown;
        public GroupBox performerGroup;
        private Button closePerformerNote;
        private Button deletePerformerNote;
        private Button savePerformerNote;
    }
}