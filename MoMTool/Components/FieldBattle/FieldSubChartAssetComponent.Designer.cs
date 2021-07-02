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
            this.fieldAssetComponent.Location = new System.Drawing.Point(0, 17);
            this.fieldAssetComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAssetComponent.Name = "fieldAssetComponent";
            this.fieldAssetComponent.Size = new System.Drawing.Size(286, 333);
            this.fieldAssetComponent.TabIndex = 1;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Crimson;
            this.close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.close.Location = new System.Drawing.Point(608, 0);
            this.close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(31, 31);
            this.close.TabIndex = 2;
            this.close.Text = "x";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.assetClose_Click);
            // 
            // panelOutOfMapRight
            // 
            this.panelOutOfMapRight.AllowDrop = true;
            this.panelOutOfMapRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapRight.Location = new System.Drawing.Point(0, 400);
            this.panelOutOfMapRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutOfMapRight.Name = "panelOutOfMapRight";
            this.panelOutOfMapRight.Size = new System.Drawing.Size(157, 25);
            this.panelOutOfMapRight.TabIndex = 12;
            // 
            // panelSomewhereRight
            // 
            this.panelSomewhereRight.AllowDrop = true;
            this.panelSomewhereRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereRight.Location = new System.Drawing.Point(0, 367);
            this.panelSomewhereRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSomewhereRight.Name = "panelSomewhereRight";
            this.panelSomewhereRight.Size = new System.Drawing.Size(157, 25);
            this.panelSomewhereRight.TabIndex = 11;
            // 
            // panelPlayerRight
            // 
            this.panelPlayerRight.AllowDrop = true;
            this.panelPlayerRight.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerRight.Location = new System.Drawing.Point(0, 233);
            this.panelPlayerRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerRight.Name = "panelPlayerRight";
            this.panelPlayerRight.Size = new System.Drawing.Size(157, 25);
            this.panelPlayerRight.TabIndex = 7;
            // 
            // panelPartyMember2Center
            // 
            this.panelPartyMember2Center.AllowDrop = true;
            this.panelPartyMember2Center.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Center.Location = new System.Drawing.Point(0, 300);
            this.panelPartyMember2Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Center.Name = "panelPartyMember2Center";
            this.panelPartyMember2Center.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember2Center.TabIndex = 9;
            // 
            // panelPartyMember1Center
            // 
            this.panelPartyMember1Center.AllowDrop = true;
            this.panelPartyMember1Center.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Center.Location = new System.Drawing.Point(0, 100);
            this.panelPartyMember1Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Center.Name = "panelPartyMember1Center";
            this.panelPartyMember1Center.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember1Center.TabIndex = 3;
            // 
            // panelPartyMember2Right
            // 
            this.panelPartyMember2Right.AllowDrop = true;
            this.panelPartyMember2Right.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Right.Location = new System.Drawing.Point(0, 333);
            this.panelPartyMember2Right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Right.Name = "panelPartyMember2Right";
            this.panelPartyMember2Right.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember2Right.TabIndex = 10;
            // 
            // panelPlayerLeft
            // 
            this.panelPlayerLeft.AllowDrop = true;
            this.panelPlayerLeft.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerLeft.Location = new System.Drawing.Point(0, 167);
            this.panelPlayerLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerLeft.Name = "panelPlayerLeft";
            this.panelPlayerLeft.Size = new System.Drawing.Size(157, 25);
            this.panelPlayerLeft.TabIndex = 5;
            // 
            // panelPartyMember2Left
            // 
            this.panelPartyMember2Left.AllowDrop = true;
            this.panelPartyMember2Left.BackColor = System.Drawing.Color.PaleGreen;
            this.panelPartyMember2Left.Location = new System.Drawing.Point(0, 267);
            this.panelPartyMember2Left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember2Left.Name = "panelPartyMember2Left";
            this.panelPartyMember2Left.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember2Left.TabIndex = 8;
            // 
            // panelSomewhereLeft
            // 
            this.panelSomewhereLeft.AllowDrop = true;
            this.panelSomewhereLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelSomewhereLeft.Location = new System.Drawing.Point(0, 33);
            this.panelSomewhereLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSomewhereLeft.Name = "panelSomewhereLeft";
            this.panelSomewhereLeft.Size = new System.Drawing.Size(157, 25);
            this.panelSomewhereLeft.TabIndex = 1;
            // 
            // panelPlayerCenter
            // 
            this.panelPlayerCenter.AllowDrop = true;
            this.panelPlayerCenter.BackColor = System.Drawing.Color.Pink;
            this.panelPlayerCenter.Location = new System.Drawing.Point(0, 200);
            this.panelPlayerCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPlayerCenter.Name = "panelPlayerCenter";
            this.panelPlayerCenter.Size = new System.Drawing.Size(157, 25);
            this.panelPlayerCenter.TabIndex = 6;
            // 
            // panelPartyMember1Left
            // 
            this.panelPartyMember1Left.AllowDrop = true;
            this.panelPartyMember1Left.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Left.Location = new System.Drawing.Point(0, 67);
            this.panelPartyMember1Left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Left.Name = "panelPartyMember1Left";
            this.panelPartyMember1Left.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember1Left.TabIndex = 2;
            // 
            // panelPartyMember1Right
            // 
            this.panelPartyMember1Right.AllowDrop = true;
            this.panelPartyMember1Right.BackColor = System.Drawing.Color.PowderBlue;
            this.panelPartyMember1Right.Location = new System.Drawing.Point(0, 133);
            this.panelPartyMember1Right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPartyMember1Right.Name = "panelPartyMember1Right";
            this.panelPartyMember1Right.Size = new System.Drawing.Size(157, 25);
            this.panelPartyMember1Right.TabIndex = 4;
            // 
            // panelOutOfMapLeft
            // 
            this.panelOutOfMapLeft.AllowDrop = true;
            this.panelOutOfMapLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutOfMapLeft.Location = new System.Drawing.Point(0, 0);
            this.panelOutOfMapLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutOfMapLeft.Name = "panelOutOfMapLeft";
            this.panelOutOfMapLeft.Size = new System.Drawing.Size(157, 25);
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
            this.chartAnimationPanel.Location = new System.Drawing.Point(291, 39);
            this.chartAnimationPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartAnimationPanel.Name = "chartAnimationPanel";
            this.chartAnimationPanel.Size = new System.Drawing.Size(347, 436);
            this.chartAnimationPanel.TabIndex = 3;
            // 
            // animationPanel
            // 
            this.animationPanel.Controls.Add(this.deleteAnimation);
            this.animationPanel.Controls.Add(this.saveAnimation);
            this.animationPanel.Controls.Add(this.fieldAnimationComponent);
            this.animationPanel.Controls.Add(this.animationClose);
            this.animationPanel.Location = new System.Drawing.Point(291, 39);
            this.animationPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(347, 392);
            this.animationPanel.TabIndex = 13;
            this.animationPanel.Visible = false;
            // 
            // deleteAnimation
            // 
            this.deleteAnimation.BackColor = System.Drawing.Color.Red;
            this.deleteAnimation.Location = new System.Drawing.Point(163, 337);
            this.deleteAnimation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteAnimation.Name = "deleteAnimation";
            this.deleteAnimation.Size = new System.Drawing.Size(121, 33);
            this.deleteAnimation.TabIndex = 10;
            this.deleteAnimation.Text = "Delete Anim";
            this.deleteAnimation.UseVisualStyleBackColor = false;
            this.deleteAnimation.Click += new System.EventHandler(this.deleteAnimation_Click);
            // 
            // saveAnimation
            // 
            this.saveAnimation.BackColor = System.Drawing.Color.LimeGreen;
            this.saveAnimation.Location = new System.Drawing.Point(35, 337);
            this.saveAnimation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveAnimation.Name = "saveAnimation";
            this.saveAnimation.Size = new System.Drawing.Size(121, 33);
            this.saveAnimation.TabIndex = 7;
            this.saveAnimation.Text = "Save Animation";
            this.saveAnimation.UseVisualStyleBackColor = false;
            this.saveAnimation.Click += new System.EventHandler(this.saveAnimation_Click);
            // 
            // fieldAnimationComponent
            // 
            this.fieldAnimationComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fieldAnimationComponent.CausesValidation = false;
            this.fieldAnimationComponent.Location = new System.Drawing.Point(35, 67);
            this.fieldAnimationComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAnimationComponent.Name = "fieldAnimationComponent";
            this.fieldAnimationComponent.Size = new System.Drawing.Size(286, 265);
            this.fieldAnimationComponent.TabIndex = 6;
            // 
            // animationClose
            // 
            this.animationClose.BackColor = System.Drawing.Color.Crimson;
            this.animationClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.animationClose.Location = new System.Drawing.Point(305, 12);
            this.animationClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.animationClose.Name = "animationClose";
            this.animationClose.Size = new System.Drawing.Size(31, 31);
            this.animationClose.TabIndex = 5;
            this.animationClose.Text = "x";
            this.animationClose.UseVisualStyleBackColor = false;
            this.animationClose.Click += new System.EventHandler(this.animationClose_Click);
            // 
            // animationText
            // 
            this.animationText.AutoSize = true;
            this.animationText.Location = new System.Drawing.Point(291, 11);
            this.animationText.Name = "animationText";
            this.animationText.Size = new System.Drawing.Size(84, 20);
            this.animationText.TabIndex = 4;
            this.animationText.Text = "Animations";
            // 
            // saveAsset
            // 
            this.saveAsset.BackColor = System.Drawing.Color.LimeGreen;
            this.saveAsset.Location = new System.Drawing.Point(10, 419);
            this.saveAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveAsset.Name = "saveAsset";
            this.saveAsset.Size = new System.Drawing.Size(121, 33);
            this.saveAsset.TabIndex = 8;
            this.saveAsset.Text = "Save Asset";
            this.saveAsset.UseVisualStyleBackColor = false;
            this.saveAsset.Click += new System.EventHandler(this.saveAsset_Click);
            // 
            // deleteAsset
            // 
            this.deleteAsset.BackColor = System.Drawing.Color.Red;
            this.deleteAsset.Location = new System.Drawing.Point(138, 419);
            this.deleteAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteAsset.Name = "deleteAsset";
            this.deleteAsset.Size = new System.Drawing.Size(121, 33);
            this.deleteAsset.TabIndex = 9;
            this.deleteAsset.Text = "Delete Asset";
            this.deleteAsset.UseVisualStyleBackColor = false;
            this.deleteAsset.Click += new System.EventHandler(this.deleteAsset_Click);
            // 
            // addAnimationButton
            // 
            this.addAnimationButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addAnimationButton.Location = new System.Drawing.Point(376, 5);
            this.addAnimationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(111, 31);
            this.addAnimationButton.TabIndex = 10;
            this.addAnimationButton.Text = "Add Anim";
            this.addAnimationButton.UseVisualStyleBackColor = false;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // FieldSubChartAssetComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
            this.Size = new System.Drawing.Size(648, 473);
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