using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public partial class BossChartComponent : UserControl
    {
        public BossBattleChartManager BossBattleChartManager;

        public ObservableCollection<MoMButton<BossNote>> Notes = new ObservableCollection<MoMButton<BossNote>>();
        public ObservableCollection<MoMButton<PerformerNote<BossLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<BossLane>>>();
        public ObservableCollection<MoMButton<TimeShift<BossLane>>> Times = new ObservableCollection<MoMButton<TimeShift<BossLane>>>();

        public int ZoomVariable = 10;

        // TODO Add ability to drag and drop notes ALREADY on the lanes
        // TODO Remove MoMButton from UI after deleting (That's why ObservableCollection?)
        // TODO Add default animations to different note types
        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public BossChartComponent()
        {
            InitializeComponent();

            foreach(Panel lane in chartNotePanel.Controls)
            {
                lane.DragEnter += this.chartLane_DragEnter;
                lane.DragDrop += this.chartLane_DragDrop;
            }
        }

        private void chartTimeValue_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(((TextBox)sender).Text))
                return;

            var value = (int.Parse(((TextBox)sender).Text) + 5000) / this.ZoomVariable; // Add 5 seconds of padding

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
            var noteType = e.Data.GetData(DataFormats.Text).ToString();

            Panel panel = ((Panel)sender);
            Point pt = new Point(e.X, e.Y);
            Point controlRelatedCoords = panel.PointToClient(pt);

            var lane = (BossLane)Enum.Parse(typeof(BossLane), panel.Name[5..]);

            if (noteType.Equals("Enemy Note"))
            {
                var momButton = new MoMButton<BossNote>
                {
                    Id = Notes.Count,
                    Type = "Note",
                    Note = new BossNote(),
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Red,
                        Height = 19,
                        Width = 19,
                        Name = $"note-{Notes.Count}",
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(controlRelatedCoords.X, 0);

                //momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Notes.Add(momButton);

                var toolTip = new ToolTip();
                toolTip.SetToolTip(momButton.Button, (controlRelatedCoords.X * this.ZoomVariable).ToString());

                this.AddToLane(lane, momButton.Button);
            }
            else if (noteType.Equals("Performer Note"))
            {
                var momButton = new MoMButton<PerformerNote<BossLane>>
                {
                    Id = Performers.Count,
                    Type = "Performer",
                    Note = new PerformerNote<BossLane>(),
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Purple,
                        Height = 19,
                        Width = 19,
                        Name = $"performer-{Performers.Count}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(controlRelatedCoords.X, 0);

                //momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Performers.Add(momButton);

                var toolTip = new ToolTip();
                toolTip.SetToolTip(momButton.Button, (controlRelatedCoords.X * this.ZoomVariable).ToString());

                this.AddToLane(lane, momButton.Button);
            }
        }

        public void LoadChart(BossBattleSong bossBattleSong)
        {
            var toolTip = new ToolTip();

            this.ResetChart();

            var songLength = (bossBattleSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            this.songTypeDropdown.SelectedItem = "Boss Battle";
            this.notesCheckbox.Checked = true;
            this.performerCheckbox.Checked = true;
            this.chartTimeValue.Text = songLength.ToString();

            for (int i = 0; i < bossBattleSong.NoteCount; ++i)
            {
                var momButton = new MoMButton<BossNote>
                {
                    Id = i,
                    Type = "Note",
                    Note = bossBattleSong.Notes[i],
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

            for (int i = 0; i < bossBattleSong.PerformerCount; ++i)
            {
                var momButton = new MoMButton<PerformerNote<BossLane>>
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

            for (int i = 0; i < bossBattleSong.TimeShiftCount; ++i)
            {
                var momButton = new MoMButton<TimeShift<BossLane>>
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

                this.AddToLane(BossLane.PlayerTop, momButton.Button);
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

        public void AddToLane(BossLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case BossLane.PlayerTop:
                    this.panelPlayerLeft.Controls.Add(buttonNote);
                    break;
                case BossLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Add(buttonNote);
                    break;
                case BossLane.PlayerBottom:
                    this.panelPlayerRight.Controls.Add(buttonNote);
                    break;
                default:
                    break;
            }
        }

        public void RemoveFromLane(BossLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case BossLane.PlayerTop:
                    this.panelPlayerLeft.Controls.Remove(buttonNote);
                    break;
                case BossLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Remove(buttonNote);
                    break;
                case BossLane.PlayerBottom:
                    this.panelPlayerRight.Controls.Remove(buttonNote);
                    break;
                default:
                    break;
            }
        }
    }
}
