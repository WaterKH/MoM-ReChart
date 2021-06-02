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
            this.fieldPerformerGroup = new System.Windows.Forms.GroupBox();
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
            this.fieldPerformerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldPerformerGroup
            // 
            this.fieldPerformerGroup.Controls.Add(this.typeLabel);
            this.fieldPerformerGroup.Controls.Add(this.typeDropdown);
            this.fieldPerformerGroup.Controls.Add(this.laneDropdown);
            this.fieldPerformerGroup.Controls.Add(this.laneLabel);
            this.fieldPerformerGroup.Controls.Add(this.msLabel);
            this.fieldPerformerGroup.Controls.Add(this.timeValue);
            this.fieldPerformerGroup.Controls.Add(this.timeLabel);
            this.fieldPerformerGroup.Location = new System.Drawing.Point(10, 27);
            this.fieldPerformerGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldPerformerGroup.Name = "fieldPerformerGroup";
            this.fieldPerformerGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldPerformerGroup.Size = new System.Drawing.Size(250, 135);
            this.fieldPerformerGroup.TabIndex = 0;
            this.fieldPerformerGroup.TabStop = false;
            this.fieldPerformerGroup.Text = "fieldPerformerGroup";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(3, 92);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 15);
            this.typeLabel.TabIndex = 6;
            this.typeLabel.Text = "Type:";
            // 
            // typeDropdown
            // 
            this.typeDropdown.FormattingEnabled = true;
            this.typeDropdown.Items.AddRange(new object[] {
            "L2",
            "R2",
            "Up",
            "Down",
            "Left",
            "Right",
            "Jump",
            "Action"});
            this.typeDropdown.Location = new System.Drawing.Point(93, 90);
            this.typeDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.typeDropdown.Name = "typeDropdown";
            this.typeDropdown.Size = new System.Drawing.Size(139, 23);
            this.typeDropdown.TabIndex = 5;
            // 
            // laneDropdown
            // 
            this.laneDropdown.FormattingEnabled = true;
            this.laneDropdown.Items.AddRange(new object[] {
            "OutOfMapLeft",
            "SomewhereLeft",
            "PartyMember1Left",
            "PartyMember1Center",
            "PartyMember1Right",
            "PlayerLeft",
            "PlayerCenter",
            "PlayerRight",
            "PartyMember2Left",
            "PartyMember2Center",
            "PartyMember2Right",
            "SomewhereRight",
            "OutOfMapRight"});
            this.laneDropdown.Location = new System.Drawing.Point(53, 59);
            this.laneDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.laneDropdown.Name = "laneDropdown";
            this.laneDropdown.Size = new System.Drawing.Size(139, 23);
            this.laneDropdown.TabIndex = 4;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Location = new System.Drawing.Point(3, 60);
            this.laneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(35, 15);
            this.laneLabel.TabIndex = 3;
            this.laneLabel.Text = "Lane:";
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
            // closePerformerNote
            // 
            this.closePerformerNote.BackColor = System.Drawing.Color.Crimson;
            this.closePerformerNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closePerformerNote.Location = new System.Drawing.Point(256, 0);
            this.closePerformerNote.Name = "closePerformerNote";
            this.closePerformerNote.Size = new System.Drawing.Size(27, 23);
            this.closePerformerNote.TabIndex = 7;
            this.closePerformerNote.Text = "x";
            this.closePerformerNote.UseVisualStyleBackColor = false;
            // 
            // deletePerformerNote
            // 
            this.deletePerformerNote.BackColor = System.Drawing.Color.Red;
            this.deletePerformerNote.Location = new System.Drawing.Point(122, 315);
            this.deletePerformerNote.Name = "deletePerformerNote";
            this.deletePerformerNote.Size = new System.Drawing.Size(106, 25);
            this.deletePerformerNote.TabIndex = 11;
            this.deletePerformerNote.Text = "Delete Note";
            this.deletePerformerNote.UseVisualStyleBackColor = false;
            // 
            // savePerformerNote
            // 
            this.savePerformerNote.BackColor = System.Drawing.Color.LimeGreen;
            this.savePerformerNote.Location = new System.Drawing.Point(10, 315);
            this.savePerformerNote.Name = "savePerformerNote";
            this.savePerformerNote.Size = new System.Drawing.Size(106, 25);
            this.savePerformerNote.TabIndex = 10;
            this.savePerformerNote.Text = "Save Note";
            this.savePerformerNote.UseVisualStyleBackColor = false;
            // 
            // PerformerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.deletePerformerNote);
            this.Controls.Add(this.savePerformerNote);
            this.Controls.Add(this.closePerformerNote);
            this.Controls.Add(this.fieldPerformerGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "PerformerComponent";
            this.Size = new System.Drawing.Size(288, 353);
            this.fieldPerformerGroup.ResumeLayout(false);
            this.fieldPerformerGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;

        public System.Windows.Forms.GroupBox fieldNoteGroup;
        public System.Windows.Forms.TextBox timeValue;
        public System.Windows.Forms.ComboBox laneDropdown;
        public System.Windows.Forms.ComboBox typeDropdown;
        public GroupBox fieldPerformerGroup;
        private Button closePerformerNote;
        private Button deletePerformerNote;
        private Button savePerformerNote;
    }
}