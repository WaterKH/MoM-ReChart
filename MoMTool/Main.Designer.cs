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
            this.decompileButton = new System.Windows.Forms.Button();
            this.recompileButton = new System.Windows.Forms.Button();
            this.proudTab = new System.Windows.Forms.TabPage();
            this.proudFieldChartComponent = new MoMTool.Logic.FieldChartComponent();
            this.standardTab = new System.Windows.Forms.TabPage();
            this.standardFieldChartComponent = new MoMTool.Logic.FieldChartComponent();
            this.beginnerTab = new System.Windows.Forms.TabPage();
            this.beginnerFieldChartComponent = new MoMTool.Logic.FieldChartComponent();
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
            this.proudTab.SuspendLayout();
            this.standardTab.SuspendLayout();
            this.beginnerTab.SuspendLayout();
            this.difficultyControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(97, 6);
            this.fileName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fileName.Name = "fileName";
            this.fileName.PlaceholderText = "File Path";
            this.fileName.Size = new System.Drawing.Size(239, 23);
            this.fileName.TabIndex = 1;
            this.fileName.TextChanged += new System.EventHandler(this.fileName_TextChanged);
            // 
            // openFileExplorer
            // 
            this.openFileExplorer.Location = new System.Drawing.Point(11, 4);
            this.openFileExplorer.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.openFileExplorer.Name = "openFileExplorer";
            this.openFileExplorer.Size = new System.Drawing.Size(81, 22);
            this.openFileExplorer.TabIndex = 2;
            this.openFileExplorer.Text = "Open...";
            this.openFileExplorer.UseVisualStyleBackColor = true;
            this.openFileExplorer.Click += new System.EventHandler(this.openFileExplorer_Click);
            // 
            // decompileButton
            // 
            this.decompileButton.Location = new System.Drawing.Point(369, 4);
            this.decompileButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.decompileButton.Name = "decompileButton";
            this.decompileButton.Size = new System.Drawing.Size(81, 22);
            this.decompileButton.TabIndex = 3;
            this.decompileButton.Text = "Decompile";
            this.decompileButton.UseVisualStyleBackColor = true;
            this.decompileButton.Click += new System.EventHandler(this.decompileButton_Click);
            // 
            // recompileButton
            // 
            this.recompileButton.Location = new System.Drawing.Point(558, 4);
            this.recompileButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.recompileButton.Name = "recompileButton";
            this.recompileButton.Size = new System.Drawing.Size(147, 22);
            this.recompileButton.TabIndex = 4;
            this.recompileButton.Text = "Recompile Field Song";
            this.recompileButton.UseVisualStyleBackColor = true;
            this.recompileButton.Click += new System.EventHandler(this.recompileFieldSongButton_Click);
            // 
            // proudTab
            // 
            this.proudTab.Controls.Add(this.proudFieldChartComponent);
            this.proudTab.Location = new System.Drawing.Point(4, 24);
            this.proudTab.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.proudTab.Name = "proudTab";
            this.proudTab.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.proudTab.Size = new System.Drawing.Size(703, 382);
            this.proudTab.TabIndex = 2;
            this.proudTab.Text = "Proud";
            this.proudTab.UseVisualStyleBackColor = true;
            // 
            // proudFieldChartComponent
            // 
            this.proudFieldChartComponent.AllowDrop = true;
            this.proudFieldChartComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.proudFieldChartComponent.CausesValidation = false;
            this.proudFieldChartComponent.Location = new System.Drawing.Point(0, 0);
            this.proudFieldChartComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.proudFieldChartComponent.Name = "proudFieldChartComponent";
            this.proudFieldChartComponent.Size = new System.Drawing.Size(706, 384);
            this.proudFieldChartComponent.TabIndex = 2;
            this.proudFieldChartComponent.Visible = false;
            // 
            // standardTab
            // 
            this.standardTab.Controls.Add(this.standardFieldChartComponent);
            this.standardTab.Location = new System.Drawing.Point(4, 24);
            this.standardTab.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standardTab.Name = "standardTab";
            this.standardTab.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standardTab.Size = new System.Drawing.Size(703, 382);
            this.standardTab.TabIndex = 1;
            this.standardTab.Text = "Standard";
            this.standardTab.UseVisualStyleBackColor = true;
            // 
            // standardFieldChartComponent
            // 
            this.standardFieldChartComponent.AllowDrop = true;
            this.standardFieldChartComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.standardFieldChartComponent.CausesValidation = false;
            this.standardFieldChartComponent.Location = new System.Drawing.Point(0, 0);
            this.standardFieldChartComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.standardFieldChartComponent.Name = "standardFieldChartComponent";
            this.standardFieldChartComponent.Size = new System.Drawing.Size(706, 384);
            this.standardFieldChartComponent.TabIndex = 2;
            this.standardFieldChartComponent.Visible = false;
            // 
            // beginnerTab
            // 
            this.beginnerTab.Controls.Add(this.beginnerFieldChartComponent);
            this.beginnerTab.Location = new System.Drawing.Point(4, 24);
            this.beginnerTab.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.beginnerTab.Name = "beginnerTab";
            this.beginnerTab.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.beginnerTab.Size = new System.Drawing.Size(703, 382);
            this.beginnerTab.TabIndex = 0;
            this.beginnerTab.Text = "Beginner";
            this.beginnerTab.UseVisualStyleBackColor = true;
            // 
            // beginnerFieldChartComponent
            // 
            this.beginnerFieldChartComponent.AllowDrop = true;
            this.beginnerFieldChartComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.beginnerFieldChartComponent.CausesValidation = false;
            this.beginnerFieldChartComponent.Location = new System.Drawing.Point(0, 0);
            this.beginnerFieldChartComponent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.beginnerFieldChartComponent.Name = "beginnerFieldChartComponent";
            this.beginnerFieldChartComponent.Size = new System.Drawing.Size(706, 384);
            this.beginnerFieldChartComponent.TabIndex = 0;
            this.beginnerFieldChartComponent.Visible = false;
            // 
            // difficultyControl
            // 
            this.difficultyControl.Controls.Add(this.beginnerTab);
            this.difficultyControl.Controls.Add(this.standardTab);
            this.difficultyControl.Controls.Add(this.proudTab);
            this.difficultyControl.Location = new System.Drawing.Point(6, 57);
            this.difficultyControl.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.difficultyControl.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.difficultyControl.MinimumSize = new System.Drawing.Size(500, 400);
            this.difficultyControl.Name = "difficultyControl";
            this.difficultyControl.SelectedIndex = 0;
            this.difficultyControl.Size = new System.Drawing.Size(711, 410);
            this.difficultyControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zoomInButton);
            this.panel1.Controls.Add(this.zoomOutButton);
            this.panel1.Location = new System.Drawing.Point(598, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 21);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "zoom";
            // 
            // zoomInButton
            // 
            this.zoomInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomInButton.Location = new System.Drawing.Point(73, 0);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(34, 21);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zoomOutButton.Location = new System.Drawing.Point(0, 0);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(28, 21);
            this.zoomOutButton.TabIndex = 0;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // noteListBox
            // 
            this.noteListBox.AllowDrop = true;
            this.noteListBox.FormattingEnabled = true;
            this.noteListBox.ItemHeight = 15;
            this.noteListBox.Items.AddRange(new object[] {
            "Enemy Note",
            "Asset",
            "Performer Note"});
            this.noteListBox.Location = new System.Drawing.Point(726, 80);
            this.noteListBox.Name = "noteListBox";
            this.noteListBox.Size = new System.Drawing.Size(177, 379);
            this.noteListBox.TabIndex = 0;
            // 
            // noteListLabel
            // 
            this.noteListLabel.AutoSize = true;
            this.noteListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.noteListLabel.Location = new System.Drawing.Point(726, 62);
            this.noteListLabel.Name = "noteListLabel";
            this.noteListLabel.Size = new System.Drawing.Size(57, 15);
            this.noteListLabel.TabIndex = 7;
            this.noteListLabel.Text = "Note List";
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.Location = new System.Drawing.Point(455, 6);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(61, 19);
            this.debugCheckbox.TabIndex = 8;
            this.debugCheckbox.Text = "Debug";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            // 
            // clearChartButton
            // 
            this.clearChartButton.Location = new System.Drawing.Point(726, 5);
            this.clearChartButton.Name = "clearChartButton";
            this.clearChartButton.Size = new System.Drawing.Size(90, 22);
            this.clearChartButton.TabIndex = 9;
            this.clearChartButton.Text = "Clear Chart";
            this.clearChartButton.UseVisualStyleBackColor = true;
            this.clearChartButton.Click += new System.EventHandler(this.clearChartButton_Click);
            // 
            // deleteChartButton
            // 
            this.deleteChartButton.BackColor = System.Drawing.Color.IndianRed;
            this.deleteChartButton.Location = new System.Drawing.Point(822, 5);
            this.deleteChartButton.Name = "deleteChartButton";
            this.deleteChartButton.Size = new System.Drawing.Size(81, 22);
            this.deleteChartButton.TabIndex = 10;
            this.deleteChartButton.Text = "Delete Chart";
            this.deleteChartButton.UseVisualStyleBackColor = false;
            this.deleteChartButton.Click += new System.EventHandler(this.deleteChartButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 468);
            this.Controls.Add(this.deleteChartButton);
            this.Controls.Add(this.clearChartButton);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.noteListBox);
            this.Controls.Add(this.noteListLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.recompileButton);
            this.Controls.Add(this.decompileButton);
            this.Controls.Add(this.openFileExplorer);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.difficultyControl);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Main";
            this.Text = "Melody of Memory Music Tool";
            this.proudTab.ResumeLayout(false);
            this.standardTab.ResumeLayout(false);
            this.beginnerTab.ResumeLayout(false);
            this.difficultyControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button openFileExplorer;
        private System.Windows.Forms.Button decompileButton;
        private System.Windows.Forms.Button recompileButton;
        private System.Windows.Forms.TabPage proudTab;
        private System.Windows.Forms.TabPage standardTab;
        private System.Windows.Forms.TabPage beginnerTab;
        private System.Windows.Forms.TabControl difficultyControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        public Logic.FieldChartComponent proudFieldChartComponent;
        public Logic.FieldChartComponent standardFieldChartComponent;
        private System.Windows.Forms.ListBox noteListBox;
        private System.Windows.Forms.Label noteListLabel;
        private CheckBox debugCheckbox;
        private Button clearChartButton;
        public Logic.FieldChartComponent beginnerFieldChartComponent;
        private Button deleteChartButton;
    }
}

