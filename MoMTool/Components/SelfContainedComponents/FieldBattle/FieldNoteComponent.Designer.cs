using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldNoteComponent : UserControl
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
            this.fieldNoteGroup = new System.Windows.Forms.GroupBox();
            this.shooterDropdown = new System.Windows.Forms.ComboBox();
            this.nextNoteDropdown = new System.Windows.Forms.ComboBox();
            this.previousNoteDropdown = new System.Windows.Forms.ComboBox();
            this.partyFlag = new System.Windows.Forms.CheckBox();
            this.projectileNote = new System.Windows.Forms.Label();
            this.nextNote = new System.Windows.Forms.Label();
            this.previousNote = new System.Windows.Forms.Label();
            this.starFlag = new System.Windows.Forms.CheckBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.modelDropdown = new System.Windows.Forms.ComboBox();
            this.laneDropdown = new System.Windows.Forms.ComboBox();
            this.laneLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.fieldNoteGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldNoteGroup
            // 
            this.fieldNoteGroup.Controls.Add(this.shooterDropdown);
            this.fieldNoteGroup.Controls.Add(this.nextNoteDropdown);
            this.fieldNoteGroup.Controls.Add(this.previousNoteDropdown);
            this.fieldNoteGroup.Controls.Add(this.partyFlag);
            this.fieldNoteGroup.Controls.Add(this.projectileNote);
            this.fieldNoteGroup.Controls.Add(this.nextNote);
            this.fieldNoteGroup.Controls.Add(this.previousNote);
            this.fieldNoteGroup.Controls.Add(this.starFlag);
            this.fieldNoteGroup.Controls.Add(this.modelLabel);
            this.fieldNoteGroup.Controls.Add(this.modelDropdown);
            this.fieldNoteGroup.Controls.Add(this.laneDropdown);
            this.fieldNoteGroup.Controls.Add(this.laneLabel);
            this.fieldNoteGroup.Controls.Add(this.msLabel);
            this.fieldNoteGroup.Controls.Add(this.timeValue);
            this.fieldNoteGroup.Controls.Add(this.timeLabel);
            this.fieldNoteGroup.Location = new System.Drawing.Point(0, 0);
            this.fieldNoteGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldNoteGroup.Name = "fieldNoteGroup";
            this.fieldNoteGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldNoteGroup.Size = new System.Drawing.Size(286, 333);
            this.fieldNoteGroup.TabIndex = 0;
            this.fieldNoteGroup.TabStop = false;
            this.fieldNoteGroup.Text = "fieldNoteGroup";
            // 
            // shooterDropdown
            // 
            this.shooterDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shooterDropdown.DropDownWidth = 300;
            this.shooterDropdown.FormattingEnabled = true;
            this.shooterDropdown.Items.AddRange(new object[] {
            ""});
            this.shooterDropdown.Location = new System.Drawing.Point(19, 198);
            this.shooterDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.shooterDropdown.Name = "shooterDropdown";
            this.shooterDropdown.Size = new System.Drawing.Size(249, 28);
            this.shooterDropdown.TabIndex = 18;
            // 
            // nextNoteDropdown
            // 
            this.nextNoteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nextNoteDropdown.DropDownWidth = 300;
            this.nextNoteDropdown.FormattingEnabled = true;
            this.nextNoteDropdown.Items.AddRange(new object[] {
            ""});
            this.nextNoteDropdown.Location = new System.Drawing.Point(19, 261);
            this.nextNoteDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.nextNoteDropdown.Name = "nextNoteDropdown";
            this.nextNoteDropdown.Size = new System.Drawing.Size(249, 28);
            this.nextNoteDropdown.TabIndex = 17;
            // 
            // previousNoteDropdown
            // 
            this.previousNoteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.previousNoteDropdown.DropDownWidth = 300;
            this.previousNoteDropdown.FormattingEnabled = true;
            this.previousNoteDropdown.Items.AddRange(new object[] {
            ""});
            this.previousNoteDropdown.Location = new System.Drawing.Point(19, 198);
            this.previousNoteDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.previousNoteDropdown.Name = "previousNoteDropdown";
            this.previousNoteDropdown.Size = new System.Drawing.Size(249, 28);
            this.previousNoteDropdown.TabIndex = 16;
            // 
            // partyFlag
            // 
            this.partyFlag.AutoSize = true;
            this.partyFlag.Location = new System.Drawing.Point(128, 302);
            this.partyFlag.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.partyFlag.Name = "partyFlag";
            this.partyFlag.Size = new System.Drawing.Size(107, 24);
            this.partyFlag.TabIndex = 15;
            this.partyFlag.Text = "Party Note?";
            this.partyFlag.UseVisualStyleBackColor = true;
            // 
            // projectileNote
            // 
            this.projectileNote.AutoSize = true;
            this.projectileNote.Location = new System.Drawing.Point(6, 170);
            this.projectileNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.projectileNote.Name = "projectileNote";
            this.projectileNote.Size = new System.Drawing.Size(101, 20);
            this.projectileNote.TabIndex = 13;
            this.projectileNote.Text = "Shooter Note:";
            this.projectileNote.Visible = false;
            // 
            // nextNote
            // 
            this.nextNote.AutoSize = true;
            this.nextNote.Location = new System.Drawing.Point(4, 233);
            this.nextNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nextNote.Name = "nextNote";
            this.nextNote.Size = new System.Drawing.Size(80, 20);
            this.nextNote.TabIndex = 11;
            this.nextNote.Text = "Next Note:";
            // 
            // previousNote
            // 
            this.previousNote.AutoSize = true;
            this.previousNote.Location = new System.Drawing.Point(3, 170);
            this.previousNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previousNote.Name = "previousNote";
            this.previousNote.Size = new System.Drawing.Size(104, 20);
            this.previousNote.TabIndex = 9;
            this.previousNote.Text = "Previous Note:";
            // 
            // starFlag
            // 
            this.starFlag.AutoSize = true;
            this.starFlag.Location = new System.Drawing.Point(5, 302);
            this.starFlag.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.starFlag.Name = "starFlag";
            this.starFlag.Size = new System.Drawing.Size(101, 24);
            this.starFlag.TabIndex = 8;
            this.starFlag.Text = "Star Note?";
            this.starFlag.UseVisualStyleBackColor = true;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(3, 123);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(55, 20);
            this.modelLabel.TabIndex = 6;
            this.modelLabel.Text = "Model:";
            // 
            // modelDropdown
            // 
            this.modelDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelDropdown.DropDownWidth = 250;
            this.modelDropdown.FormattingEnabled = true;
            this.modelDropdown.Items.AddRange(new object[] {
            "CommonEnemy",
            "AerialCommonEnemy",
            "UncommonEnemy",
            "AerialUncommonEnemy",
            "MultiHitGroundEnemy",
            "MultiHitAerialEnemy",
            "EnemyShooterProjectile",
            "EnemyShooter",
            "AerialEnemyShooterProjectile",
            "AerialEnemyShooter",
            "JumpingGroundEnemy",
            "JumpingAerialEnemy",
            "HiddenEnemy",
            "HittableAerialUncommonEnemy",
            "CrystalEnemyLeftRight",
            "CrystalEnemyCenter",
            "GlideNote",
            "Barrel",
            "Crate"});
            this.modelDropdown.Location = new System.Drawing.Point(62, 120);
            this.modelDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.modelDropdown.Name = "modelDropdown";
            this.modelDropdown.Size = new System.Drawing.Size(202, 28);
            this.modelDropdown.TabIndex = 5;
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
            this.laneDropdown.Location = new System.Drawing.Point(61, 79);
            this.laneDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.laneDropdown.Name = "laneDropdown";
            this.laneDropdown.Size = new System.Drawing.Size(158, 28);
            this.laneDropdown.TabIndex = 4;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Location = new System.Drawing.Point(3, 80);
            this.laneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(43, 20);
            this.laneLabel.TabIndex = 3;
            this.laneLabel.Text = "Lane:";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(227, 37);
            this.msLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(28, 20);
            this.msLabel.TabIndex = 2;
            this.msLabel.Text = "ms";
            // 
            // timeValue
            // 
            this.timeValue.Location = new System.Drawing.Point(61, 36);
            this.timeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(158, 27);
            this.timeValue.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(3, 37);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(45, 20);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // FieldNoteComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.fieldNoteGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldNoteComponent";
            this.Size = new System.Drawing.Size(286, 333);
            this.fieldNoteGroup.ResumeLayout(false);
            this.fieldNoteGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label timeLabel;
        
        public System.Windows.Forms.GroupBox fieldNoteGroup;
        public System.Windows.Forms.TextBox timeValue;
        public System.Windows.Forms.ComboBox laneDropdown;
        public System.Windows.Forms.ComboBox modelDropdown;
        public System.Windows.Forms.CheckBox starFlag;
        public Label nextNote;
        public Label previousNote;
        public Label projectileNote;
        public CheckBox partyFlag;
        public ComboBox shooterDropdown;
        public ComboBox nextNoteDropdown;
        public ComboBox previousNoteDropdown;
    }
}