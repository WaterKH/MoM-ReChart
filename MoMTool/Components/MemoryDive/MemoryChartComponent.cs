using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class MemoryChartComponent : UserControl
    {
        public MemoryDiveChartManager MemoryDiveChartManager;

        public ObservableCollection<MoMButton<MemoryNote>> Notes = new ObservableCollection<MoMButton<MemoryNote>>();
        public ObservableCollection<MoMButton<PerformerNote<MemoryLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<MemoryLane>>>();
        public ObservableCollection<MoMButton<TimeShift<MemoryLane>>> Times = new ObservableCollection<MoMButton<TimeShift<MemoryLane>>>();

        public int ZoomVariable = 10;

        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public MemoryChartComponent()
        {
            InitializeComponent();

            foreach(Panel lane in chartNotePanel.Controls)
            {
                lane.DragEnter += this.chartLane_DragEnter;
                lane.DragDrop += this.chartLane_DragDrop;
            }

            this.Dock = DockStyle.Fill;
        }

        private void chartTimeValue_TextChanged(object sender, EventArgs e)
        {
            var value = this.MemoryDiveChartManager.CalculateChartLength(((TextBox)sender).Text);

            if (value == 0)
                return;

            this.panelPlayerLeft.Width = value;
            this.panelPlayerCenter.Width = value;
            this.panelPlayerRight.Width = value;
        }

        private void notesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;
            
            this.Notes.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void performerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;

            this.Performers.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void chartLane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void chartLane_DragDrop(object sender, DragEventArgs e)
        {
            var panel = ((Panel)sender);
            var point = new Point(e.X, e.Y);
            var data = e.Data.GetData(DataFormats.Text).ToString();
            var noteType = Regex.Match(data, "ListViewItem: {(.*)}").Groups[1].Value;

            if (noteType != "")
            {
                this.MemoryDiveChartManager.CreateDroppedNote(panel, point, noteType);
            }
            else
            {
                this.MemoryDiveChartManager.MoveChartNote(panel, point, data);
            }
        }

        public void LoadChart(MemoryDiveSong memoryDiveSong)
        {
            var toolTip = new ToolTip();

            this.ResetChart();

            var songLength = (memoryDiveSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            this.songTypeDropdown.SelectedItem = "Memory Dive";
            this.notesCheckbox.Checked = true;
            this.performerCheckbox.Checked = true;
            this.chartTimeValue.Text = songLength.ToString();

            for (int i = 0; i < memoryDiveSong.NoteCount; ++i)
            {
                var momButton = new MoMButton<MemoryNote>
                {
                    Id = i,
                    Type = "Note",
                    Note = memoryDiveSong.Notes[i],
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Red,
                        Height = 19,
                        Width = 19,
                        Name = $"note-{i}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);

                //momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Notes.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

                this.AddToLane(momButton.Note.Lane, momButton.Button);
            }

            for (int i = 0; i < memoryDiveSong.PerformerCount; ++i)
            {
                var momButton = new MoMButton<PerformerNote<MemoryLane>>
                {
                    Type = "Performer",
                    //Note = fieldBattleSong.PerformerNotes[i],
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Purple,
                        Height = 19,
                        Width = 19,
                        Name = $"performer-{i}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);

                //momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Performers.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

                //this.AddToLane(momButton.Note.Lane, momButton.Button);
            }

            for (int i = 0; i < memoryDiveSong.TimeShiftCount; ++i)
            {
                var momButton = new MoMButton<TimeShift<MemoryLane>>
                {
                    Type = "Time",
                    //Note = fieldBattleSong.TimeShifts[i],
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Yellow,
                        Height = 19,
                        Width = 19,
                        Name = $"time-{i}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                //momButton.Button.Location = new Point(momButton.Note.ChangeTime / this.ZoomVariable, 0);

                //momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Times.Add(momButton);

                //toolTip.SetToolTip(momButton.Button, momButton.Note.ChangeTime.ToString());

                this.AddToLane(MemoryLane.PlayerLeft, momButton.Button);
            }
        }

        public void ResetChart()
        {
            this.songTypeDropdown.SelectedItem = null;
            this.notesCheckbox.Checked = false;
            this.performerCheckbox.Checked = false;
            this.chartLengthText.Text = string.Empty;

            this.Notes.Clear();
            this.Performers.Clear();
            this.Times.Clear();

            this.ClearPanels();
        }

        private void ClearPanels()
        {
            this.panelPlayerLeft.Controls.Clear();
            this.panelPlayerCenter.Controls.Clear();
            this.panelPlayerRight.Controls.Clear();
        }

        public void AddToLane(MemoryLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case MemoryLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Add(buttonNote);
                    break;
                case MemoryLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Add(buttonNote);
                    break;
                case MemoryLane.PlayerRight:
                    this.panelPlayerRight.Controls.Add(buttonNote);
                    break;
                default:
                    break;
            }
        }

        public void RemoveFromLane(MemoryLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case MemoryLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Remove(buttonNote);
                    break;
                case MemoryLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Remove(buttonNote);
                    break;
                case MemoryLane.PlayerRight:
                    this.panelPlayerRight.Controls.Remove(buttonNote);
                    break;
                default:
                    break;
            }
        }
    }
}
