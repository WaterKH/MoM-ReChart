using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldAnimationComponent : UserControl
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
            this.fieldEnemyAnimationGroup = new System.Windows.Forms.GroupBox();
            this.endNoteValue = new System.Windows.Forms.TextBox();
            this.nextNote = new System.Windows.Forms.Label();
            this.startNoteValue = new System.Windows.Forms.TextBox();
            this.previousNote = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endTimeValue = new System.Windows.Forms.TextBox();
            this.endTimeText = new System.Windows.Forms.Label();
            this.aerialFlag = new System.Windows.Forms.CheckBox();
            this.laneDropdown = new System.Windows.Forms.ComboBox();
            this.laneLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.startTimeValue = new System.Windows.Forms.TextBox();
            this.startTimeText = new System.Windows.Forms.Label();
            this.fieldEnemyAnimationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldEnemyAnimationGroup
            // 
            this.fieldEnemyAnimationGroup.Controls.Add(this.endNoteValue);
            this.fieldEnemyAnimationGroup.Controls.Add(this.nextNote);
            this.fieldEnemyAnimationGroup.Controls.Add(this.startNoteValue);
            this.fieldEnemyAnimationGroup.Controls.Add(this.previousNote);
            this.fieldEnemyAnimationGroup.Controls.Add(this.label1);
            this.fieldEnemyAnimationGroup.Controls.Add(this.endTimeValue);
            this.fieldEnemyAnimationGroup.Controls.Add(this.endTimeText);
            this.fieldEnemyAnimationGroup.Controls.Add(this.aerialFlag);
            this.fieldEnemyAnimationGroup.Controls.Add(this.laneDropdown);
            this.fieldEnemyAnimationGroup.Controls.Add(this.laneLabel);
            this.fieldEnemyAnimationGroup.Controls.Add(this.msLabel);
            this.fieldEnemyAnimationGroup.Controls.Add(this.startTimeValue);
            this.fieldEnemyAnimationGroup.Controls.Add(this.startTimeText);
            this.fieldEnemyAnimationGroup.Location = new System.Drawing.Point(0, 0);
            this.fieldEnemyAnimationGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldEnemyAnimationGroup.Name = "fieldEnemyAnimationGroup";
            this.fieldEnemyAnimationGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldEnemyAnimationGroup.Size = new System.Drawing.Size(286, 265);
            this.fieldEnemyAnimationGroup.TabIndex = 0;
            this.fieldEnemyAnimationGroup.TabStop = false;
            this.fieldEnemyAnimationGroup.Text = "fieldEnemyAnimationGroup";
            // 
            // endNoteValue
            // 
            this.endNoteValue.Location = new System.Drawing.Point(222, 171);
            this.endNoteValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.endNoteValue.Name = "endNoteValue";
            this.endNoteValue.Size = new System.Drawing.Size(54, 27);
            this.endNoteValue.TabIndex = 15;
            // 
            // nextNote
            // 
            this.nextNote.AutoSize = true;
            this.nextNote.Location = new System.Drawing.Point(151, 175);
            this.nextNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nextNote.Name = "nextNote";
            this.nextNote.Size = new System.Drawing.Size(80, 20);
            this.nextNote.TabIndex = 14;
            this.nextNote.Text = "Next Note:";
            // 
            // startNoteValue
            // 
            this.startNoteValue.Location = new System.Drawing.Point(79, 169);
            this.startNoteValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.startNoteValue.Name = "startNoteValue";
            this.startNoteValue.Size = new System.Drawing.Size(54, 27);
            this.startNoteValue.TabIndex = 13;
            // 
            // previousNote
            // 
            this.previousNote.AutoSize = true;
            this.previousNote.Location = new System.Drawing.Point(3, 175);
            this.previousNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previousNote.Name = "previousNote";
            this.previousNote.Size = new System.Drawing.Size(77, 20);
            this.previousNote.TabIndex = 12;
            this.previousNote.Text = "Prev Note:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "ms";
            // 
            // endTimeValue
            // 
            this.endTimeValue.Location = new System.Drawing.Point(86, 123);
            this.endTimeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.endTimeValue.Name = "endTimeValue";
            this.endTimeValue.Size = new System.Drawing.Size(158, 27);
            this.endTimeValue.TabIndex = 10;
            // 
            // endTimeText
            // 
            this.endTimeText.AutoSize = true;
            this.endTimeText.Location = new System.Drawing.Point(3, 125);
            this.endTimeText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.endTimeText.Name = "endTimeText";
            this.endTimeText.Size = new System.Drawing.Size(74, 20);
            this.endTimeText.TabIndex = 9;
            this.endTimeText.Text = "End Time:";
            // 
            // aerialFlag
            // 
            this.aerialFlag.AutoSize = true;
            this.aerialFlag.Location = new System.Drawing.Point(3, 227);
            this.aerialFlag.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aerialFlag.Name = "aerialFlag";
            this.aerialFlag.Size = new System.Drawing.Size(114, 24);
            this.aerialFlag.TabIndex = 8;
            this.aerialFlag.Text = "Aerial Note?";
            this.aerialFlag.UseVisualStyleBackColor = true;
            // 
            // laneDropdown
            // 
            this.laneDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.laneDropdown.Location = new System.Drawing.Point(61, 37);
            this.laneDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.laneDropdown.Name = "laneDropdown";
            this.laneDropdown.Size = new System.Drawing.Size(158, 28);
            this.laneDropdown.TabIndex = 4;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Location = new System.Drawing.Point(3, 39);
            this.laneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(43, 20);
            this.laneLabel.TabIndex = 3;
            this.laneLabel.Text = "Lane:";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(251, 84);
            this.msLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(28, 20);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // startTimeValue
            // 
            this.startTimeValue.Location = new System.Drawing.Point(85, 83);
            this.startTimeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.startTimeValue.Name = "startTimeValue";
            this.startTimeValue.Size = new System.Drawing.Size(158, 27);
            this.startTimeValue.TabIndex = 1;
            // 
            // startTimeText
            // 
            this.startTimeText.AutoSize = true;
            this.startTimeText.Location = new System.Drawing.Point(3, 84);
            this.startTimeText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startTimeText.Name = "startTimeText";
            this.startTimeText.Size = new System.Drawing.Size(80, 20);
            this.startTimeText.TabIndex = 0;
            this.startTimeText.Text = "Start Time:";
            // 
            // FieldAnimationComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.fieldEnemyAnimationGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldAnimationComponent";
            this.Size = new System.Drawing.Size(286, 265);
            this.fieldEnemyAnimationGroup.ResumeLayout(false);
            this.fieldEnemyAnimationGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label startTimeText;

        public System.Windows.Forms.GroupBox fieldEnemyAnimationGroup;
        public System.Windows.Forms.TextBox startTimeValue;
        public System.Windows.Forms.ComboBox laneDropdown;
        public System.Windows.Forms.CheckBox aerialFlag;
        private Label label1;
        public TextBox textBox1;
        private Label endTimeText;
        public TextBox endNoteValue;
        private Label nextNote;
        public TextBox startNoteValue;
        private Label previousNote;
        public TextBox endTimeValue;
    }
}