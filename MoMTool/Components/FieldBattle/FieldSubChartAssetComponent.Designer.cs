using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class FieldSubChartAssetComponent : UserControl
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
            this.fieldAssetComponent = new MoMTool.Logic.FieldAssetComponent();
            this.close = new System.Windows.Forms.Button();
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
            this.chartAnimationPanel = new System.Windows.Forms.Panel();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.deleteAnimation = new System.Windows.Forms.Button();
            this.saveAnimation = new System.Windows.Forms.Button();
            this.fieldAnimationComponent = new MoMTool.Logic.FieldAnimationComponent();
            this.animationClose = new System.Windows.Forms.Button();
            this.animationText = new System.Windows.Forms.Label();
            this.saveAsset = new System.Windows.Forms.Button();
            this.deleteAsset = new System.Windows.Forms.Button();
            this.addAnimationButton = new System.Windows.Forms.Button();
            this.chartAnimationPanel.SuspendLayout();
            this.animationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldAssetComponent
            // 
            this.fieldAssetComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fieldAssetComponent.CausesValidation = false;
            this.fieldAssetComponent.Location = new System.Drawing.Point(0, 13);
            this.fieldAssetComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAssetComponent.Name = "fieldAssetComponent";
            this.fieldAssetComponent.Size = new System.Drawing.Size(250, 250);
            this.fieldAssetComponent.TabIndex = 1;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Crimson;
            this.close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.close.Location = new System.Drawing.Point(532, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(27, 23);
            this.close.TabIndex = 2;
            this.close.Text = "x";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.assetClose_Click);
            // 
            // panelOutOfMapRight
            // 
            this.panelOutOfMapRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapRight.Location = new System.Drawing.Point(0, 300);
            this.panelOutOfMapRight.Name = "panelOutOfMapRight";
            this.panelOutOfMapRight.Size = new System.Drawing.Size(137, 19);
            this.panelOutOfMapRight.TabIndex = 12;
            // 
            // panelSomewhereRight
            // 
            this.panelSomewhereRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereRight.Location = new System.Drawing.Point(0, 275);
            this.panelSomewhereRight.Name = "panelSomewhereRight";
            this.panelSomewhereRight.Size = new System.Drawing.Size(137, 19);
            this.panelSomewhereRight.TabIndex = 11;
            // 
            // panelPlayerRight
            // 
            this.panelPlayerRight.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerRight.Location = new System.Drawing.Point(0, 175);
            this.panelPlayerRight.Name = "panelPlayerRight";
            this.panelPlayerRight.Size = new System.Drawing.Size(137, 19);
            this.panelPlayerRight.TabIndex = 7;
            // 
            // panelPartyMember2Center
            // 
            this.panelPartyMember2Center.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Center.Location = new System.Drawing.Point(0, 225);
            this.panelPartyMember2Center.Name = "panelPartyMember2Center";
            this.panelPartyMember2Center.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember2Center.TabIndex = 9;
            // 
            // panelPartyMember1Center
            // 
            this.panelPartyMember1Center.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Center.Location = new System.Drawing.Point(0, 75);
            this.panelPartyMember1Center.Name = "panelPartyMember1Center";
            this.panelPartyMember1Center.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember1Center.TabIndex = 3;
            // 
            // panelPartyMember2Right
            // 
            this.panelPartyMember2Right.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Right.Location = new System.Drawing.Point(0, 250);
            this.panelPartyMember2Right.Name = "panelPartyMember2Right";
            this.panelPartyMember2Right.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember2Right.TabIndex = 10;
            // 
            // panelPlayerLeft
            // 
            this.panelPlayerLeft.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerLeft.Location = new System.Drawing.Point(0, 125);
            this.panelPlayerLeft.Name = "panelPlayerLeft";
            this.panelPlayerLeft.Size = new System.Drawing.Size(137, 19);
            this.panelPlayerLeft.TabIndex = 5;
            // 
            // panelPartyMember2Left
            // 
            this.panelPartyMember2Left.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Left.Location = new System.Drawing.Point(0, 200);
            this.panelPartyMember2Left.Name = "panelPartyMember2Left";
            this.panelPartyMember2Left.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember2Left.TabIndex = 8;
            // 
            // panelSomewhereLeft
            // 
            this.panelSomewhereLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereLeft.Location = new System.Drawing.Point(0, 25);
            this.panelSomewhereLeft.Name = "panelSomewhereLeft";
            this.panelSomewhereLeft.Size = new System.Drawing.Size(137, 19);
            this.panelSomewhereLeft.TabIndex = 1;
            // 
            // panelPlayerCenter
            // 
            this.panelPlayerCenter.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerCenter.Location = new System.Drawing.Point(0, 150);
            this.panelPlayerCenter.Name = "panelPlayerCenter";
            this.panelPlayerCenter.Size = new System.Drawing.Size(137, 19);
            this.panelPlayerCenter.TabIndex = 6;
            // 
            // panelPartyMember1Left
            // 
            this.panelPartyMember1Left.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Left.Location = new System.Drawing.Point(0, 50);
            this.panelPartyMember1Left.Name = "panelPartyMember1Left";
            this.panelPartyMember1Left.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember1Left.TabIndex = 2;
            // 
            // panelPartyMember1Right
            // 
            this.panelPartyMember1Right.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Right.Location = new System.Drawing.Point(0, 100);
            this.panelPartyMember1Right.Name = "panelPartyMember1Right";
            this.panelPartyMember1Right.Size = new System.Drawing.Size(137, 19);
            this.panelPartyMember1Right.TabIndex = 4;
            // 
            // panelOutOfMapLeft
            // 
            this.panelOutOfMapLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapLeft.Location = new System.Drawing.Point(0, 0);
            this.panelOutOfMapLeft.Name = "panelOutOfMapLeft";
            this.panelOutOfMapLeft.Size = new System.Drawing.Size(137, 19);
            this.panelOutOfMapLeft.TabIndex = 0;
            // 
            // chartAnimationPanel
            // 
            this.chartAnimationPanel.AutoScroll = true;
            this.chartAnimationPanel.Controls.Add(this.panelOutOfMapRight);
            this.chartAnimationPanel.Controls.Add(this.panelSomewhereRight);
            this.chartAnimationPanel.Controls.Add(this.panelPlayerRight);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember2Center);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember1Center);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember2Right);
            this.chartAnimationPanel.Controls.Add(this.panelPlayerLeft);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember2Left);
            this.chartAnimationPanel.Controls.Add(this.panelSomewhereLeft);
            this.chartAnimationPanel.Controls.Add(this.panelPlayerCenter);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember1Left);
            this.chartAnimationPanel.Controls.Add(this.panelPartyMember1Right);
            this.chartAnimationPanel.Controls.Add(this.panelOutOfMapLeft);
            this.chartAnimationPanel.Location = new System.Drawing.Point(255, 29);
            this.chartAnimationPanel.Name = "chartAnimationPanel";
            this.chartAnimationPanel.Size = new System.Drawing.Size(304, 327);
            this.chartAnimationPanel.TabIndex = 3;
            // 
            // animationPanel
            // 
            this.animationPanel.Controls.Add(this.deleteAnimation);
            this.animationPanel.Controls.Add(this.saveAnimation);
            this.animationPanel.Controls.Add(this.fieldAnimationComponent);
            this.animationPanel.Controls.Add(this.animationClose);
            this.animationPanel.Location = new System.Drawing.Point(255, 29);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(304, 294);
            this.animationPanel.TabIndex = 13;
            this.animationPanel.Visible = false;
            // 
            // deleteAnimation
            // 
            this.deleteAnimation.BackColor = System.Drawing.Color.Red;
            this.deleteAnimation.Location = new System.Drawing.Point(143, 253);
            this.deleteAnimation.Name = "deleteAnimation";
            this.deleteAnimation.Size = new System.Drawing.Size(106, 25);
            this.deleteAnimation.TabIndex = 10;
            this.deleteAnimation.Text = "Delete Anim";
            this.deleteAnimation.UseVisualStyleBackColor = false;
            this.deleteAnimation.Click += new System.EventHandler(this.deleteAnimation_Click);
            // 
            // saveAnimation
            // 
            this.saveAnimation.BackColor = System.Drawing.Color.LimeGreen;
            this.saveAnimation.Location = new System.Drawing.Point(31, 253);
            this.saveAnimation.Name = "saveAnimation";
            this.saveAnimation.Size = new System.Drawing.Size(106, 25);
            this.saveAnimation.TabIndex = 7;
            this.saveAnimation.Text = "Save Animation";
            this.saveAnimation.UseVisualStyleBackColor = false;
            this.saveAnimation.Click += new System.EventHandler(this.saveAnimation_Click);
            // 
            // fieldAnimationComponent
            // 
            this.fieldAnimationComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fieldAnimationComponent.CausesValidation = false;
            this.fieldAnimationComponent.Location = new System.Drawing.Point(31, 50);
            this.fieldAnimationComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAnimationComponent.Name = "fieldAnimationComponent";
            this.fieldAnimationComponent.Size = new System.Drawing.Size(250, 199);
            this.fieldAnimationComponent.TabIndex = 6;
            // 
            // animationClose
            // 
            this.animationClose.BackColor = System.Drawing.Color.Crimson;
            this.animationClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.animationClose.Location = new System.Drawing.Point(267, 9);
            this.animationClose.Name = "animationClose";
            this.animationClose.Size = new System.Drawing.Size(27, 23);
            this.animationClose.TabIndex = 5;
            this.animationClose.Text = "x";
            this.animationClose.UseVisualStyleBackColor = false;
            this.animationClose.Click += new System.EventHandler(this.animationClose_Click);
            // 
            // animationText
            // 
            this.animationText.AutoSize = true;
            this.animationText.Location = new System.Drawing.Point(255, 8);
            this.animationText.Name = "animationText";
            this.animationText.Size = new System.Drawing.Size(68, 15);
            this.animationText.TabIndex = 4;
            this.animationText.Text = "Animations";
            // 
            // saveAsset
            // 
            this.saveAsset.BackColor = System.Drawing.Color.LimeGreen;
            this.saveAsset.Location = new System.Drawing.Point(9, 314);
            this.saveAsset.Name = "saveAsset";
            this.saveAsset.Size = new System.Drawing.Size(106, 25);
            this.saveAsset.TabIndex = 8;
            this.saveAsset.Text = "Save Asset";
            this.saveAsset.UseVisualStyleBackColor = false;
            this.saveAsset.Click += new System.EventHandler(this.saveAsset_Click);
            // 
            // deleteAsset
            // 
            this.deleteAsset.BackColor = System.Drawing.Color.Red;
            this.deleteAsset.Location = new System.Drawing.Point(121, 314);
            this.deleteAsset.Name = "deleteAsset";
            this.deleteAsset.Size = new System.Drawing.Size(106, 25);
            this.deleteAsset.TabIndex = 9;
            this.deleteAsset.Text = "Delete Asset";
            this.deleteAsset.UseVisualStyleBackColor = false;
            this.deleteAsset.Click += new System.EventHandler(this.deleteAsset_Click);
            // 
            // addAnimationButton
            // 
            this.addAnimationButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addAnimationButton.Location = new System.Drawing.Point(329, 4);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(97, 23);
            this.addAnimationButton.TabIndex = 10;
            this.addAnimationButton.Text = "Add Anim";
            this.addAnimationButton.UseVisualStyleBackColor = false;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // FieldSubChartAssetComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CausesValidation = false;
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.addAnimationButton);
            this.Controls.Add(this.deleteAsset);
            this.Controls.Add(this.saveAsset);
            this.Controls.Add(this.animationText);
            this.Controls.Add(this.chartAnimationPanel);
            this.Controls.Add(this.close);
            this.Controls.Add(this.fieldAssetComponent);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FieldSubChartAssetComponent";
            this.Size = new System.Drawing.Size(567, 355);
            this.chartAnimationPanel.ResumeLayout(false);
            this.animationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public FieldAssetComponent fieldAssetComponent;
        private Button close;
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
        private Panel chartAnimationPanel;
        private Label animationText;
        public Panel animationPanel;
        private Button animationClose;
        public FieldAnimationComponent fieldAnimationComponent;
        private Button saveAnimation;
        private Button saveAsset;
        private Button deleteAnimation;
        private Button deleteAsset;
        private Button addAnimationButton;
    }
}