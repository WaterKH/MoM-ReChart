using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldAssetComponent : UserControl
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
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.msLabel = new System.Windows.Forms.Label();
            this.laneLabel = new System.Windows.Forms.Label();
            this.laneDropdown = new System.Windows.Forms.ComboBox();
            this.modelDropdown = new System.Windows.Forms.ComboBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.fieldAssetGroup = new System.Windows.Forms.GroupBox();
            this.fieldAssetGroup.SuspendLayout();
            this.SuspendLayout();
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
            // timeValue
            // 
            this.timeValue.Location = new System.Drawing.Point(53, 27);
            this.timeValue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(139, 23);
            this.timeValue.TabIndex = 1;
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
            // modelDropdown
            // 
            this.modelDropdown.FormattingEnabled = true;
            this.modelDropdown.Items.AddRange(new object[] {
            "AerialCommonArrow",
            "AerialUncommonArrow",
            "MultiHitAerialArrow",
            "RareEnemyProjectileArrow",
            "ProjectileArrow",
            "CrystalRightLeft",
            "CrystalCenter",
            "GlideArrow"});
            this.modelDropdown.Location = new System.Drawing.Point(93, 90);
            this.modelDropdown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.modelDropdown.Name = "modelDropdown";
            this.modelDropdown.Size = new System.Drawing.Size(139, 23);
            this.modelDropdown.TabIndex = 5;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(3, 92);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(44, 15);
            this.modelLabel.TabIndex = 6;
            this.modelLabel.Text = "Model:";
            // 
            // fieldAssetGroup
            // 
            this.fieldAssetGroup.Controls.Add(this.modelLabel);
            this.fieldAssetGroup.Controls.Add(this.modelDropdown);
            this.fieldAssetGroup.Controls.Add(this.laneDropdown);
            this.fieldAssetGroup.Controls.Add(this.laneLabel);
            this.fieldAssetGroup.Controls.Add(this.msLabel);
            this.fieldAssetGroup.Controls.Add(this.timeValue);
            this.fieldAssetGroup.Controls.Add(this.timeLabel);
            this.fieldAssetGroup.Location = new System.Drawing.Point(0, 0);
            this.fieldAssetGroup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAssetGroup.Name = "fieldAssetGroup";
            this.fieldAssetGroup.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAssetGroup.Size = new System.Drawing.Size(250, 133);
            this.fieldAssetGroup.TabIndex = 0;
            this.fieldAssetGroup.TabStop = false;
            this.fieldAssetGroup.Text = "fieldAssetGroup";
            // 
            // FieldAssetComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.fieldAssetGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldAssetComponent";
            this.Size = new System.Drawing.Size(250, 133);
            this.fieldAssetGroup.ResumeLayout(false);
            this.fieldAssetGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label timeLabel;
        public TextBox timeValue;
        private Label msLabel;
        private Label laneLabel;
        public ComboBox laneDropdown;
        public ComboBox modelDropdown;
        private Label modelLabel;
        public GroupBox fieldAssetGroup;
    }
}