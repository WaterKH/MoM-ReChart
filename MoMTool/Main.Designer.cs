using System.Windows.Forms;

namespace MoMTool
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileName = new System.Windows.Forms.TextBox();
            this.openFileExplorer = new System.Windows.Forms.Button();
            this.recompileButton = new System.Windows.Forms.Button();
            this.tabProud = new System.Windows.Forms.TabPage();
            this.tabStandard = new System.Windows.Forms.TabPage();
            this.tabBeginner = new System.Windows.Forms.TabPage();
            this.difficultyControl = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.noteListBox = new System.Windows.Forms.ListBox();
            this.noteListLabel = new System.Windows.Forms.Label();
            this.debugCheckbox = new System.Windows.Forms.CheckBox();
            this.clearChartButton = new System.Windows.Forms.Button();
            this.deleteChartButton = new System.Windows.Forms.Button();
            this.difficultyControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(196, 13);
            this.fileName.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.fileName.Name = "fileName";
            this.fileName.PlaceholderText = "File Path";
            this.fileName.Size = new System.Drawing.Size(440, 39);
            this.fileName.TabIndex = 1;
            this.fileName.TextChanged += new System.EventHandler(this.fileName_TextChanged);
            // 
            // openFileExplorer
            // 
            this.openFileExplorer.Location = new System.Drawing.Point(20, 9);
            this.openFileExplorer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.openFileExplorer.Name = "openFileExplorer";
            this.openFileExplorer.Size = new System.Drawing.Size(168, 47);
            this.openFileExplorer.TabIndex = 2;
            this.openFileExplorer.Text = "Decompile...";
            this.openFileExplorer.UseVisualStyleBackColor = true;
            this.openFileExplorer.Click += new System.EventHandler(this.openFileExplorer_Click);
            // 
            // recompileButton
            // 
            this.recompileButton.Location = new System.Drawing.Point(821, 15);
            this.recompileButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.recompileButton.Name = "recompileButton";
            this.recompileButton.Size = new System.Drawing.Size(273, 47);
            this.recompileButton.TabIndex = 4;
            this.recompileButton.Text = "Recompile Field Song";
            this.recompileButton.UseVisualStyleBackColor = true;
            this.recompileButton.Click += new System.EventHandler(this.recompileFieldSongButton_Click);
            // 
            // tabProud
            // 
            this.tabProud.Location = new System.Drawing.Point(8, 46);
            this.tabProud.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabProud.Name = "tabProud";
            this.tabProud.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabProud.Size = new System.Drawing.Size(1304, 821);
            this.tabProud.TabIndex = 2;
            this.tabProud.Text = "Proud";
            this.tabProud.UseVisualStyleBackColor = true;
            // 
            // tabStandard
            // 
            this.tabStandard.Location = new System.Drawing.Point(8, 46);
            this.tabStandard.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabStandard.Name = "tabStandard";
            this.tabStandard.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabStandard.Size = new System.Drawing.Size(1304, 821);
            this.tabStandard.TabIndex = 1;
            this.tabStandard.Text = "Standard";
            this.tabStandard.UseVisualStyleBackColor = true;
            // 
            // tabBeginner
            // 
            this.tabBeginner.Location = new System.Drawing.Point(8, 46);
            this.tabBeginner.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabBeginner.Name = "tabBeginner";
            this.tabBeginner.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabBeginner.Size = new System.Drawing.Size(1304, 821);
            this.tabBeginner.TabIndex = 0;
            this.tabBeginner.Text = "Beginner";
            this.tabBeginner.UseVisualStyleBackColor = true;
            // 
            // difficultyControl
            // 
            this.difficultyControl.Controls.Add(this.tabBeginner);
            this.difficultyControl.Controls.Add(this.tabStandard);
            this.difficultyControl.Controls.Add(this.tabProud);
            this.difficultyControl.Location = new System.Drawing.Point(11, 122);
            this.difficultyControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.difficultyControl.MaximumSize = new System.Drawing.Size(3714, 4267);
            this.difficultyControl.MinimumSize = new System.Drawing.Size(929, 853);
            this.difficultyControl.Name = "difficultyControl";
            this.difficultyControl.SelectedIndex = 0;
            this.difficultyControl.Size = new System.Drawing.Size(1320, 875);
            this.difficultyControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zoomInButton);
            this.panel1.Controls.Add(this.zoomOutButton);
            this.panel1.Location = new System.Drawing.Point(1111, 122);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 45);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "zoom";
            // 
            // zoomInButton
            // 
            this.zoomInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomInButton.Location = new System.Drawing.Point(136, 0);
            this.zoomInButton.Margin = new System.Windows.Forms.Padding(6);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(63, 45);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomOutButton.Location = new System.Drawing.Point(0, 0);
            this.zoomOutButton.Margin = new System.Windows.Forms.Padding(6);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(52, 45);
            this.zoomOutButton.TabIndex = 0;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // noteListBox
            // 
            this.noteListBox.AllowDrop = true;
            this.noteListBox.FormattingEnabled = true;
            this.noteListBox.ItemHeight = 32;
            this.noteListBox.Items.AddRange(new object[] {
            "Enemy Note",
            "Asset",
            "Performer Note"});
            this.noteListBox.Location = new System.Drawing.Point(1348, 171);
            this.noteListBox.Margin = new System.Windows.Forms.Padding(6);
            this.noteListBox.Name = "noteListBox";
            this.noteListBox.Size = new System.Drawing.Size(325, 804);
            this.noteListBox.TabIndex = 0;
            // 
            // noteListLabel
            // 
            this.noteListLabel.AutoSize = true;
            this.noteListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.noteListLabel.Location = new System.Drawing.Point(1348, 132);
            this.noteListLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.noteListLabel.Name = "noteListLabel";
            this.noteListLabel.Size = new System.Drawing.Size(116, 32);
            this.noteListLabel.TabIndex = 7;
            this.noteListLabel.Text = "Note List";
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.Location = new System.Drawing.Point(646, 15);
            this.debugCheckbox.Margin = new System.Windows.Forms.Padding(6);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(118, 36);
            this.debugCheckbox.TabIndex = 8;
            this.debugCheckbox.Text = "Debug";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            // 
            // clearChartButton
            // 
            this.clearChartButton.Location = new System.Drawing.Point(1348, 11);
            this.clearChartButton.Margin = new System.Windows.Forms.Padding(6);
            this.clearChartButton.Name = "clearChartButton";
            this.clearChartButton.Size = new System.Drawing.Size(167, 47);
            this.clearChartButton.TabIndex = 9;
            this.clearChartButton.Text = "Clear Chart";
            this.clearChartButton.UseVisualStyleBackColor = true;
            this.clearChartButton.Click += new System.EventHandler(this.clearChartButton_Click);
            // 
            // deleteChartButton
            // 
            this.deleteChartButton.BackColor = System.Drawing.Color.IndianRed;
            this.deleteChartButton.Location = new System.Drawing.Point(1527, 11);
            this.deleteChartButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteChartButton.Name = "deleteChartButton";
            this.deleteChartButton.Size = new System.Drawing.Size(150, 47);
            this.deleteChartButton.TabIndex = 10;
            this.deleteChartButton.Text = "Delete Chart";
            this.deleteChartButton.UseVisualStyleBackColor = false;
            this.deleteChartButton.Click += new System.EventHandler(this.deleteChartButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1686, 998);
            this.Controls.Add(this.deleteChartButton);
            this.Controls.Add(this.clearChartButton);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.noteListBox);
            this.Controls.Add(this.noteListLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.recompileButton);
            this.Controls.Add(this.openFileExplorer);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.difficultyControl);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Main";
            this.Text = "Melody of Memory Music Tool";
            this.difficultyControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button openFileExplorer;
        private System.Windows.Forms.Button recompileButton;
        private System.Windows.Forms.TabPage tabProud;
        private System.Windows.Forms.TabPage tabStandard;
        private System.Windows.Forms.TabPage tabBeginner;
        private System.Windows.Forms.TabControl difficultyControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.ListBox noteListBox;
        private System.Windows.Forms.Label noteListLabel;
        private CheckBox debugCheckbox;
        private Button clearChartButton;
        private Button deleteChartButton;
    }
}

