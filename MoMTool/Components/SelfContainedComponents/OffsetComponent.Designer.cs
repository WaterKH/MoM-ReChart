using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class OffsetComponent : UserControl
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
            this.saveOffset = new System.Windows.Forms.Button();
            this.closeTime = new System.Windows.Forms.Button();
            this.labelOffset = new System.Windows.Forms.Label();
            this.valueOffset = new System.Windows.Forms.TextBox();
            this.labelOffsetHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveOffset
            // 
            this.saveOffset.BackColor = System.Drawing.Color.LimeGreen;
            this.saveOffset.Location = new System.Drawing.Point(12, 420);
            this.saveOffset.Margin = new System.Windows.Forms.Padding(4);
            this.saveOffset.Name = "saveOffset";
            this.saveOffset.Size = new System.Drawing.Size(121, 33);
            this.saveOffset.TabIndex = 11;
            this.saveOffset.Text = "Save Offset";
            this.saveOffset.UseVisualStyleBackColor = false;
            this.saveOffset.Click += new System.EventHandler(this.saveOffset_Click);
            // 
            // closeTime
            // 
            this.closeTime.BackColor = System.Drawing.Color.Crimson;
            this.closeTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeTime.Location = new System.Drawing.Point(292, 0);
            this.closeTime.Margin = new System.Windows.Forms.Padding(4);
            this.closeTime.Name = "closeTime";
            this.closeTime.Size = new System.Drawing.Size(31, 31);
            this.closeTime.TabIndex = 10;
            this.closeTime.Text = "x";
            this.closeTime.UseVisualStyleBackColor = false;
            this.closeTime.Click += new System.EventHandler(this.closeOffset_Click);
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(12, 66);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(52, 20);
            this.labelOffset.TabIndex = 12;
            this.labelOffset.Text = "Offset:";
            // 
            // valueOffset
            // 
            this.valueOffset.Location = new System.Drawing.Point(70, 63);
            this.valueOffset.Name = "valueOffset";
            this.valueOffset.Size = new System.Drawing.Size(125, 27);
            this.valueOffset.TabIndex = 13;
            // 
            // labelOffsetHelp
            // 
            this.labelOffsetHelp.AutoSize = true;
            this.labelOffsetHelp.Location = new System.Drawing.Point(12, 104);
            this.labelOffsetHelp.MaximumSize = new System.Drawing.Size(300, 100);
            this.labelOffsetHelp.Name = "labelOffsetHelp";
            this.labelOffsetHelp.Size = new System.Drawing.Size(281, 40);
            this.labelOffsetHelp.TabIndex = 14;
            this.labelOffsetHelp.Text = "Input the note HitTime you would like to start at";
            // 
            // OffsetComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.Controls.Add(this.labelOffsetHelp);
            this.Controls.Add(this.valueOffset);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.saveOffset);
            this.Controls.Add(this.closeTime);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "OffsetComponent";
            this.Size = new System.Drawing.Size(329, 471);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button saveOffset;
        private Button closeTime;
        private Label labelOffset;
        public TextBox valueOffset;
        private Label labelOffsetHelp;
    }
}