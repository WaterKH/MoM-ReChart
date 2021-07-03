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
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Default Types", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Pre-Configured Notes", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Pre-Configured Assets", System.Windows.Forms.HorizontalAlignment.Left);
            this.fileName = new System.Windows.Forms.TextBox();
            this.openFileExplorer = new System.Windows.Forms.Button();
            this.recompileFieldButton = new System.Windows.Forms.Button();
            this.tabProud = new System.Windows.Forms.TabPage();
            this.tabStandard = new System.Windows.Forms.TabPage();
            this.tabBeginner = new System.Windows.Forms.TabPage();
            this.difficultyControl = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.noteListLabel = new System.Windows.Forms.Label();
            this.debugCheckbox = new System.Windows.Forms.CheckBox();
            this.clearChartButton = new System.Windows.Forms.Button();
            this.deleteChartButton = new System.Windows.Forms.Button();
            this.noteListView = new System.Windows.Forms.ListView();
            this.recompileMemoryButton = new System.Windows.Forms.Button();
            this.recompileBossButton = new System.Windows.Forms.Button();
            this.difficultyControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(121, 8);
            this.fileName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fileName.Name = "fileName";
            this.fileName.PlaceholderText = "File Path";
            this.fileName.Size = new System.Drawing.Size(272, 27);
            this.fileName.TabIndex = 1;
            this.fileName.TabStop = false;
            // 
            // openFileExplorer
            // 
            this.openFileExplorer.Location = new System.Drawing.Point(12, 6);
            this.openFileExplorer.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.openFileExplorer.Name = "openFileExplorer";
            this.openFileExplorer.Size = new System.Drawing.Size(103, 29);
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
            this.recompileFieldButton.Size = new System.Drawing.Size(168, 29);
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
            this.tabProud.Size = new System.Drawing.Size(804, 514);
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
            this.tabStandard.Size = new System.Drawing.Size(804, 514);
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
            this.tabBeginner.Size = new System.Drawing.Size(804, 514);
            this.tabBeginner.TabIndex = 0;
            this.tabBeginner.Text = "Beginner";
            this.tabBeginner.UseVisualStyleBackColor = true;
            // 
            // difficultyControl
            // 
            this.difficultyControl.Controls.Add(this.tabBeginner);
            this.difficultyControl.Controls.Add(this.tabStandard);
            this.difficultyControl.Controls.Add(this.tabProud);
            this.difficultyControl.Location = new System.Drawing.Point(7, 76);
            this.difficultyControl.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.difficultyControl.MaximumSize = new System.Drawing.Size(2286, 2667);
            this.difficultyControl.MinimumSize = new System.Drawing.Size(572, 533);
            this.difficultyControl.Name = "difficultyControl";
            this.difficultyControl.SelectedIndex = 0;
            this.difficultyControl.Size = new System.Drawing.Size(812, 547);
            this.difficultyControl.TabIndex = 0;
            this.difficultyControl.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zoomInButton);
            this.panel1.Controls.Add(this.zoomOutButton);
            this.panel1.Location = new System.Drawing.Point(684, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 28);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "zoom";
            // 
            // zoomInButton
            // 
            this.zoomInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomInButton.Location = new System.Drawing.Point(84, 0);
            this.zoomInButton.Margin = new System.Windows.Forms.Padding(4);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(39, 28);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.TabStop = false;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomOutButton.Location = new System.Drawing.Point(0, 0);
            this.zoomOutButton.Margin = new System.Windows.Forms.Padding(4);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(32, 28);
            this.zoomOutButton.TabIndex = 0;
            this.zoomOutButton.TabStop = false;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // noteListLabel
            // 
            this.noteListLabel.AutoSize = true;
            this.noteListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.noteListLabel.Location = new System.Drawing.Point(830, 82);
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
            this.clearChartButton.Location = new System.Drawing.Point(830, 7);
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
            this.deleteChartButton.BackColor = System.Drawing.Color.IndianRed;
            this.deleteChartButton.Location = new System.Drawing.Point(940, 7);
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
            this.noteListView.AutoArrange = false;
            listViewGroup10.Header = "Default Types";
            listViewGroup10.Name = "groupDefaultTypes";
            listViewGroup11.Header = "Pre-Configured Notes";
            listViewGroup11.Name = "groupPreConfiguredNotes";
            listViewGroup12.Header = "Pre-Configured Assets";
            listViewGroup12.Name = "groupPreConfiguredAssets";
            this.noteListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup10,
            listViewGroup11,
            listViewGroup12});
            this.noteListView.HideSelection = false;
            this.noteListView.Location = new System.Drawing.Point(824, 105);
            this.noteListView.Margin = new System.Windows.Forms.Padding(2);
            this.noteListView.Name = "noteListView";
            this.noteListView.Size = new System.Drawing.Size(208, 513);
            this.noteListView.TabIndex = 11;
            this.noteListView.TabStop = false;
            this.noteListView.UseCompatibleStateImageBehavior = false;
            this.noteListView.View = System.Windows.Forms.View.Tile;
            // 
            // recompileMemoryButton
            // 
            this.recompileMemoryButton.Location = new System.Drawing.Point(505, 10);
            this.recompileMemoryButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileMemoryButton.Name = "recompileMemoryButton";
            this.recompileMemoryButton.Size = new System.Drawing.Size(200, 29);
            this.recompileMemoryButton.TabIndex = 12;
            this.recompileMemoryButton.TabStop = false;
            this.recompileMemoryButton.Text = "Recompile Memory Song";
            this.recompileMemoryButton.UseVisualStyleBackColor = true;
            this.recompileMemoryButton.Visible = false;
            this.recompileMemoryButton.Click += new System.EventHandler(this.recompileMemorySongButton_Click);
            // 
            // recompileBossButton
            // 
            this.recompileBossButton.Location = new System.Drawing.Point(505, 10);
            this.recompileBossButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileBossButton.Name = "recompileBossButton";
            this.recompileBossButton.Size = new System.Drawing.Size(168, 29);
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
            this.ClientSize = new System.Drawing.Size(1038, 624);
            this.Controls.Add(this.recompileBossButton);
            this.Controls.Add(this.recompileMemoryButton);
            this.Controls.Add(this.noteListView);
            this.Controls.Add(this.deleteChartButton);
            this.Controls.Add(this.clearChartButton);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.noteListLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.recompileFieldButton);
            this.Controls.Add(this.openFileExplorer);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.difficultyControl);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
        private System.Windows.Forms.Button recompileFieldButton;
        private System.Windows.Forms.TabPage tabProud;
        private System.Windows.Forms.TabPage tabStandard;
        private System.Windows.Forms.TabPage tabBeginner;
        private System.Windows.Forms.TabControl difficultyControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.Label noteListLabel;
        private CheckBox debugCheckbox;
        private Button clearChartButton;
        private Button deleteChartButton;
        private ListView noteListView;
        private Button recompileMemoryButton;
        private Button recompileBossButton;
    }
}

