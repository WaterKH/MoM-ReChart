using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class SubFieldChartComponent : UserControl
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
            this.closeAsset = new System.Windows.Forms.Button();
            this.saveAsset = new System.Windows.Forms.Button();
            this.deleteAsset = new System.Windows.Forms.Button();
            this.fieldAssetComponent1 = new MoMTool.Logic.FieldAssetComponent();
            this.SuspendLayout();
            // 
            // closeAsset
            // 
            this.closeAsset.BackColor = System.Drawing.Color.Crimson;
            this.closeAsset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeAsset.Location = new System.Drawing.Point(255, -1);
            this.closeAsset.Name = "closeAsset";
            this.closeAsset.Size = new System.Drawing.Size(27, 23);
            this.closeAsset.TabIndex = 2;
            this.closeAsset.Text = "x";
            this.closeAsset.UseVisualStyleBackColor = false;
            this.closeAsset.Click += new System.EventHandler(this.closeAsset_Click);
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
            // fieldAssetComponent1
            // 
            this.fieldAssetComponent1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fieldAssetComponent1.CausesValidation = false;
            this.fieldAssetComponent1.Location = new System.Drawing.Point(9, 26);
            this.fieldAssetComponent1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fieldAssetComponent1.Name = "fieldAssetComponent1";
            this.fieldAssetComponent1.Size = new System.Drawing.Size(250, 133);
            this.fieldAssetComponent1.TabIndex = 10;
            // 
            // SubFieldChartComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CausesValidation = false;
            this.Controls.Add(this.fieldAssetComponent1);
            this.Controls.Add(this.deleteAsset);
            this.Controls.Add(this.saveAsset);
            this.Controls.Add(this.closeAsset);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "SubFieldChartComponent";
            this.Size = new System.Drawing.Size(288, 353);
            this.ResumeLayout(false);

        }

        #endregion
        private Button closeAsset;
        private Button saveAsset;
        private Button deleteAsset;
        private FieldAssetComponent fieldAssetComponent1;
    }
}