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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Default Types", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Pre-Configured Notes", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Pre-Configured Assets", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.fileName = new System.Windows.Forms.TextBox();
            this.openFileExplorer = new System.Windows.Forms.Button();
            this.recompileFieldButton = new System.Windows.Forms.Button();
            this.tabProud = new System.Windows.Forms.TabPage();
            this.tabStandard = new System.Windows.Forms.TabPage();
            this.tabBeginner = new System.Windows.Forms.TabPage();
            this.difficultyControl = new System.Windows.Forms.TabControl();
            this.noteListLabel = new System.Windows.Forms.Label();
            this.debugCheckbox = new System.Windows.Forms.CheckBox();
            this.clearChartButton = new System.Windows.Forms.Button();
            this.deleteChartButton = new System.Windows.Forms.Button();
            this.noteListView = new System.Windows.Forms.ListView();
            this.recompileMemoryButton = new System.Windows.Forms.Button();
            this.recompileBossButton = new System.Windows.Forms.Button();
            this.difficultyControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(121, 8);
            this.fileName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fileName.Name = "fileName";
            this.fileName.PlaceholderText = "File Path";
            this.fileName.Size = new System.Drawing.Size(271, 27);
            this.fileName.TabIndex = 1;
            this.fileName.TabStop = false;
            // 
            // openFileExplorer
            // 
            this.openFileExplorer.Location = new System.Drawing.Point(12, 6);
            this.openFileExplorer.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.openFileExplorer.Name = "openFileExplorer";
            this.openFileExplorer.Size = new System.Drawing.Size(102, 29);
            this.openFileExplorer.TabIndex = 2;
            this.openFileExplorer.TabStop = false;
            this.openFileExplorer.Text = "Decompile...";
            this.openFileExplorer.UseVisualStyleBackColor = true;
            this.openFileExplorer.Click += new System.EventHandler(this.openFileExplorer_Click);
            // 
            // recompileFieldButton
            // 
            this.recompileFieldButton.Location = new System.Drawing.Point(505, 9);
            this.recompileFieldButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileFieldButton.Name = "recompileFieldButton";
            this.recompileFieldButton.Size = new System.Drawing.Size(167, 29);
            this.recompileFieldButton.TabIndex = 4;
            this.recompileFieldButton.TabStop = false;
            this.recompileFieldButton.Text = "Recompile Field Song";
            this.recompileFieldButton.UseVisualStyleBackColor = true;
            this.recompileFieldButton.Click += new System.EventHandler(this.recompileFieldSongButton_Click);
            // 
            // tabProud
            // 
            this.tabProud.Location = new System.Drawing.Point(4, 29);
            this.tabProud.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabProud.Name = "tabProud";
            this.tabProud.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabProud.Size = new System.Drawing.Size(817, 564);
            this.tabProud.TabIndex = 2;
            this.tabProud.Text = "Proud";
            this.tabProud.UseVisualStyleBackColor = true;
            // 
            // tabStandard
            // 
            this.tabStandard.Location = new System.Drawing.Point(4, 29);
            this.tabStandard.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabStandard.Name = "tabStandard";
            this.tabStandard.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabStandard.Size = new System.Drawing.Size(817, 564);
            this.tabStandard.TabIndex = 1;
            this.tabStandard.Text = "Standard";
            this.tabStandard.UseVisualStyleBackColor = true;
            // 
            // tabBeginner
            // 
            this.tabBeginner.Location = new System.Drawing.Point(4, 29);
            this.tabBeginner.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabBeginner.Name = "tabBeginner";
            this.tabBeginner.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabBeginner.Size = new System.Drawing.Size(817, 564);
            this.tabBeginner.TabIndex = 0;
            this.tabBeginner.Text = "Beginner";
            this.tabBeginner.UseVisualStyleBackColor = true;
            // 
            // difficultyControl
            // 
            this.difficultyControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difficultyControl.Controls.Add(this.tabBeginner);
            this.difficultyControl.Controls.Add(this.tabStandard);
            this.difficultyControl.Controls.Add(this.tabProud);
            this.difficultyControl.Location = new System.Drawing.Point(7, 76);
            this.difficultyControl.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.difficultyControl.MaximumSize = new System.Drawing.Size(2286, 2667);
            this.difficultyControl.MinimumSize = new System.Drawing.Size(572, 533);
            this.difficultyControl.Name = "difficultyControl";
            this.difficultyControl.SelectedIndex = 0;
            this.difficultyControl.Size = new System.Drawing.Size(825, 597);
            this.difficultyControl.TabIndex = 0;
            this.difficultyControl.TabStop = false;
            // 
            // noteListLabel
            // 
            this.noteListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noteListLabel.AutoSize = true;
            this.noteListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.noteListLabel.Location = new System.Drawing.Point(835, 76);
            this.noteListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noteListLabel.Name = "noteListLabel";
            this.noteListLabel.Size = new System.Drawing.Size(73, 20);
            this.noteListLabel.TabIndex = 7;
            this.noteListLabel.Text = "Note List";
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.Location = new System.Drawing.Point(398, 9);
            this.debugCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(76, 24);
            this.debugCheckbox.TabIndex = 8;
            this.debugCheckbox.TabStop = false;
            this.debugCheckbox.Text = "Debug";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            // 
            // clearChartButton
            // 
            this.clearChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearChartButton.Location = new System.Drawing.Point(838, 6);
            this.clearChartButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearChartButton.Name = "clearChartButton";
            this.clearChartButton.Size = new System.Drawing.Size(103, 29);
            this.clearChartButton.TabIndex = 9;
            this.clearChartButton.TabStop = false;
            this.clearChartButton.Text = "Clear Chart";
            this.clearChartButton.UseVisualStyleBackColor = true;
            this.clearChartButton.Click += new System.EventHandler(this.clearChartButton_Click);
            // 
            // deleteChartButton
            // 
            this.deleteChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteChartButton.BackColor = System.Drawing.Color.IndianRed;
            this.deleteChartButton.Location = new System.Drawing.Point(949, 6);
            this.deleteChartButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteChartButton.Name = "deleteChartButton";
            this.deleteChartButton.Size = new System.Drawing.Size(92, 29);
            this.deleteChartButton.TabIndex = 10;
            this.deleteChartButton.TabStop = false;
            this.deleteChartButton.Text = "Delete Chart";
            this.deleteChartButton.UseVisualStyleBackColor = false;
            this.deleteChartButton.Click += new System.EventHandler(this.deleteChartButton_Click);
            // 
            // noteListView
            // 
            this.noteListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noteListView.AutoArrange = false;
            listViewGroup1.Header = "Default Types";
            listViewGroup1.Name = "groupDefaultTypes";
            listViewGroup2.Header = "Pre-Configured Notes";
            listViewGroup2.Name = "groupPreConfiguredNotes";
            listViewGroup3.Header = "Pre-Configured Assets";
            listViewGroup3.Name = "groupPreConfiguredAssets";
            this.noteListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.noteListView.HideSelection = false;
            this.noteListView.Location = new System.Drawing.Point(835, 105);
            this.noteListView.Margin = new System.Windows.Forms.Padding(2);
            this.noteListView.Name = "noteListView";
            this.noteListView.Size = new System.Drawing.Size(206, 567);
            this.noteListView.TabIndex = 11;
            this.noteListView.TabStop = false;
            this.noteListView.UseCompatibleStateImageBehavior = false;
            this.noteListView.View = System.Windows.Forms.View.Tile;
            // 
            // recompileMemoryButton
            // 
            this.recompileMemoryButton.Location = new System.Drawing.Point(505, 9);
            this.recompileMemoryButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileMemoryButton.Name = "recompileMemoryButton";
            this.recompileMemoryButton.Size = new System.Drawing.Size(199, 29);
            this.recompileMemoryButton.TabIndex = 12;
            this.recompileMemoryButton.TabStop = false;
            this.recompileMemoryButton.Text = "Recompile Memory Song";
            this.recompileMemoryButton.UseVisualStyleBackColor = true;
            this.recompileMemoryButton.Visible = false;
            this.recompileMemoryButton.Click += new System.EventHandler(this.recompileMemorySongButton_Click);
            // 
            // recompileBossButton
            // 
            this.recompileBossButton.Location = new System.Drawing.Point(505, 9);
            this.recompileBossButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileBossButton.Name = "recompileBossButton";
            this.recompileBossButton.Size = new System.Drawing.Size(167, 29);
            this.recompileBossButton.TabIndex = 13;
            this.recompileBossButton.TabStop = false;
            this.recompileBossButton.Text = "Recompile Boss Song";
            this.recompileBossButton.UseVisualStyleBackColor = true;
            this.recompileBossButton.Visible = false;
            this.recompileBossButton.Click += new System.EventHandler(this.recompileBossSongButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 683);
            this.Controls.Add(this.recompileBossButton);
            this.Controls.Add(this.recompileMemoryButton);
            this.Controls.Add(this.noteListView);
            this.Controls.Add(this.deleteChartButton);
            this.Controls.Add(this.clearChartButton);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.noteListLabel);
            this.Controls.Add(this.recompileFieldButton);
            this.Controls.Add(this.openFileExplorer);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.difficultyControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Main";
            this.Text = "Melody of Memory Music Tool";
            this.difficultyControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button openFileExplorer;
        private System.Windows.Forms.Button recompileFieldButton;
        private System.Windows.Forms.TabPage tabProud;
        private System.Windows.Forms.TabPage tabStandard;
        private System.Windows.Forms.TabPage tabBeginner;
        private System.Windows.Forms.TabControl difficultyControl;
        private System.Windows.Forms.Label noteListLabel;
        private CheckBox debugCheckbox;
        private Button clearChartButton;
        private Button deleteChartButton;
        private ListView noteListView;
        private Button recompileMemoryButton;
        private Button recompileBossButton;
    }
}

