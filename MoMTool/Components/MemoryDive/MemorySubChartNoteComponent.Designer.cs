using System.Drawing;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class MemorySubChartNoteComponent : UserControl
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
            this.close = new System.Windows.Forms.Button();
            this.saveNote = new System.Windows.Forms.Button();
            this.deleteNote = new System.Windows.Forms.Button();
            this.memoryNoteComponent = new MoMTool.Logic.MemoryNoteComponent();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Crimson;
            this.close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.close.Location = new System.Drawing.Point(465, 6);
            this.close.Margin = new System.Windows.Forms.Padding(6);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(50, 49);
            this.close.TabIndex = 2;
            this.close.Text = "x";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.noteClose_Click);
            // 
            // saveNote
            // 
            this.saveNote.BackColor = System.Drawing.Color.LimeGreen;
            this.saveNote.Location = new System.Drawing.Point(17, 670);
            this.saveNote.Margin = new System.Windows.Forms.Padding(6);
            this.saveNote.Name = "saveNote";
            this.saveNote.Size = new System.Drawing.Size(197, 53);
            this.saveNote.TabIndex = 8;
            this.saveNote.Text = "Save Note";
            this.saveNote.UseVisualStyleBackColor = false;
            this.saveNote.Click += new System.EventHandler(this.saveNote_Click);
            // 
            // deleteNote
            // 
            this.deleteNote.BackColor = System.Drawing.Color.Red;
            this.deleteNote.Location = new System.Drawing.Point(225, 670);
            this.deleteNote.Margin = new System.Windows.Forms.Padding(6);
            this.deleteNote.Name = "deleteNote";
            this.deleteNote.Size = new System.Drawing.Size(197, 53);
            this.deleteNote.TabIndex = 9;
            this.deleteNote.Text = "Delete Note";
            this.deleteNote.UseVisualStyleBackColor = false;
            this.deleteNote.Click += new System.EventHandler(this.deleteNote_Click);
            // 
            // memoryNoteComponent
            // 
            this.memoryNoteComponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.memoryNoteComponent.CausesValidation = false;
            this.memoryNoteComponent.Location = new System.Drawing.Point(17, 63);
            this.memoryNoteComponent.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.memoryNoteComponent.Name = "memoryNoteComponent";
            this.memoryNoteComponent.Size = new System.Drawing.Size(480, 409);
            this.memoryNoteComponent.TabIndex = 10;
            // 
            // MemorySubChartNoteComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CausesValidation = false;
            this.Controls.Add(this.memoryNoteComponent);
            this.Controls.Add(this.deleteNote);
            this.Controls.Add(this.saveNote);
            this.Controls.Add(this.close);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MemorySubChartNoteComponent";
            this.Size = new System.Drawing.Size(521, 757);
            this.ResumeLayout(false);

        }

        #endregion
        private Button close;
        private Button saveNote;
        private Button deleteNote;
        public MemoryNoteComponent memoryNoteComponent;
    }
}