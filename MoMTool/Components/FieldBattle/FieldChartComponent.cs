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
    public partial class FieldChartComponent : UserControl
    {
        public ObservableCollection<MoMButton<FieldNote>> Notes = new ObservableCollection<MoMButton<FieldNote>>();
        public ObservableCollection<MoMButton<FieldAsset>> Assets = new ObservableCollection<MoMButton<FieldAsset>>();
        public ObservableCollection<MoMButton<PerformerNote<FieldLane>>> Performers = new ObservableCollection<MoMButton<PerformerNote<FieldLane>>>();
        public ObservableCollection<MoMButton<TimeShift>> Times = new ObservableCollection<MoMButton<TimeShift>>();

        public int ZoomVariable = 10;

        // TODO Add ability to drag and drop notes ALREADY on the lanes
        // TODO Remove MoMButton from UI after deleting (That's why ObservableCollection?)
        // TODO Add default animations to different note types
        // TODO Draw lines between Multi hit/ Glide Notes
        // TODO Account for overlapping lines
        public FieldChartComponent()
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

            this.panelOutOfMapLeft.Width = value;
            this.panelSomewhereLeft.Width = value;
            this.panelPartyMember1Left.Width = value;
            this.panelPartyMember1Center.Width = value;
            this.panelPartyMember1Right.Width = value;
            this.panelPlayerLeft.Width = value;
            this.panelPlayerCenter.Width = value;
            this.panelPlayerRight.Width = value;
            this.panelPartyMember2Left.Width = value;
            this.panelPartyMember2Center.Width = value;
            this.panelPartyMember2Right.Width = value;
            this.panelSomewhereRight.Width = value;
            this.panelOutOfMapRight.Width = value;
        }

        private void notesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;
            
            this.Notes.ToList().ForEach(x => x.Button.Visible = value);
        }

        private void assetsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = ((CheckBox)sender).Checked;
            var parent = ((CheckBox)sender).Parent;

            this.Assets.ToList().ForEach(x => x.Button.Visible = value);
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

            var lane = (FieldLane)Enum.Parse(typeof(FieldLane), panel.Name[5..]);

            if (noteType.Equals("Enemy Note"))
            {
                var momButton = new MoMButton<FieldNote>
                {
                    Id = Notes.Count,
                    Type = "Note",
                    Note = new FieldNote(),
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

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Notes.Add(momButton);

                var toolTip = new ToolTip();
                toolTip.SetToolTip(momButton.Button, (controlRelatedCoords.X * this.ZoomVariable).ToString());

                this.AddToLane(lane, momButton.Button);
            }
            else if (noteType.Equals("Asset"))
            {
                var momButton = new MoMButton<FieldAsset>
                {
                    Id = Assets.Count,
                    Type = "Asset",
                    Note = new FieldAsset(),
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Blue,
                        Height = 19,
                        Width = 19,
                        Name = $"asset-{Assets.Count}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(controlRelatedCoords.X, 0);

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Assets.Add(momButton);

                var toolTip = new ToolTip();
                toolTip.SetToolTip(momButton.Button, (controlRelatedCoords.X * this.ZoomVariable).ToString());

                this.AddToLane(lane, momButton.Button);
            }
            else if (noteType.Equals("Performer Note"))
            {
                var momButton = new MoMButton<PerformerNote<FieldLane>>
                {
                    Id = Performers.Count,
                    Type = "Performer",
                    Note = new PerformerNote<FieldLane>(),
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

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Performers.Add(momButton);

                var toolTip = new ToolTip();
                toolTip.SetToolTip(momButton.Button, (controlRelatedCoords.X * this.ZoomVariable).ToString());

                this.AddToLane(lane, momButton.Button);
            }
        }

        public void LoadChart(FieldBattleSong fieldBattleSong)
        {
            var toolTip = new ToolTip();

            this.ResetChart();

            var songLength = (fieldBattleSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            this.songTypeDropdown.SelectedItem = "Field Battle";
            this.notesCheckbox.Checked = true;
            this.assetsCheckbox.Checked = true;
            this.performerCheckbox.Checked = true;
            this.chartTimeValue.Text = songLength.ToString();

            for (int i = 0; i < fieldBattleSong.NoteCount; ++i)
            {
                var momButton = new MoMButton<FieldNote>
                {
                    Id = i,
                    Type = "Note",
                    Note = fieldBattleSong.Notes[i],
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = fieldBattleSong.Notes[i].ModelType == FieldModelType.GlideNote ? Color.Green : Color.Red,
                        Height = 19,
                        Width = 19,
                        Name = $"note-{i}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Notes.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

                this.AddToLane(momButton.Note.Lane, momButton.Button);
            }

            for (int i = 0; i < fieldBattleSong.AssetCount; ++i)
            {
                var momButton = new MoMButton<FieldAsset>
                {
                    Type = "Asset",
                    Note = fieldBattleSong.FieldAssets[i],
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.Blue,
                        Height = 19,
                        Width = 19,
                        Name = $"asset-{i}",
                        //TabIndex = -1,
                        TabStop = false
                    },
                };

                momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Assets.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

                this.AddToLane(momButton.Note.Lane, momButton.Button);
            }

            for (int i = 0; i < fieldBattleSong.PerformerCount; ++i)
            {
                var momButton = new MoMButton<PerformerNote<FieldLane>>
                {
                    Type = "Performer",
                    Note = fieldBattleSong.PerformerNotes[i],
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

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Performers.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

                this.AddToLane(momButton.Note.Lane, momButton.Button);
            }

            for (int i = 0; i < fieldBattleSong.TimeShiftCount; ++i)
            {
                var momButton = new MoMButton<TimeShift>
                {
                    Type = "Time",
                    Note = fieldBattleSong.TimeShifts[i],
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

                momButton.Button.Location = new Point(momButton.Note.ChangeTime / this.ZoomVariable, 0);

                momButton.Button.Click += (object sender, EventArgs e) => { momButton.Button.Focus(); this.subChartComponent.LoadSubChartComponent(momButton.Id, momButton.Note, this); };
                this.Times.Add(momButton);

                toolTip.SetToolTip(momButton.Button, momButton.Note.ChangeTime.ToString());

                this.AddToLane(FieldLane.PlayerCenter, momButton.Button);
            }
        }

        public void ResetChart()
        {
            this.songTypeDropdown.SelectedItem = null;
            this.notesCheckbox.Checked = false;
            this.assetsCheckbox.Checked = false;
            this.performerCheckbox.Checked = false;
            this.chartLengthText.Text = string.Empty;

            this.Notes.Clear();
            this.Assets.Clear();
            this.Performers.Clear();
            this.Times.Clear();

            this.ClearPanels();
        }

        private void ClearPanels()
        {
            this.panelOutOfMapLeft.Controls.Clear();
            this.panelSomewhereLeft.Controls.Clear();
            this.panelPartyMember1Left.Controls.Clear();
            this.panelPartyMember1Center.Controls.Clear();
            this.panelPartyMember1Right.Controls.Clear();
            this.panelPlayerLeft.Controls.Clear();
            this.panelPlayerCenter.Controls.Clear();
            this.panelPlayerRight.Controls.Clear();
            this.panelPartyMember2Left.Controls.Clear();
            this.panelPartyMember2Center.Controls.Clear();
            this.panelPartyMember2Right.Controls.Clear();
            this.panelSomewhereRight.Controls.Clear();
            this.panelOutOfMapRight.Controls.Clear();
        }

        public void AddToLane(FieldLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case FieldLane.OutOfMapLeft:
                    this.panelOutOfMapLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.SomewhereLeft:
                    this.panelSomewhereLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Left:
                    this.panelPartyMember1Left.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Center:
                    this.panelPartyMember1Center.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember1Right:
                    this.panelPartyMember1Right.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Add(buttonNote);
                    break;
                case FieldLane.PlayerRight:
                    this.panelPlayerRight.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Left:
                    this.panelPartyMember2Left.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Center:
                    this.panelPartyMember2Center.Controls.Add(buttonNote);
                    break;
                case FieldLane.PartyMember2Right:
                    this.panelPartyMember2Right.Controls.Add(buttonNote);
                    break;
                case FieldLane.SomewhereRight:
                    this.panelSomewhereRight.Controls.Add(buttonNote);
                    break;
                case FieldLane.OutOfMapRight:
                    this.panelOutOfMapRight.Controls.Add(buttonNote);
                    break;
                default:
                    break;
            }
        }

        public void RemoveFromLane(FieldLane lane, Button buttonNote)
        {
            switch (lane)
            {
                case FieldLane.OutOfMapLeft:
                    this.panelOutOfMapLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.SomewhereLeft:
                    this.panelSomewhereLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Left:
                    this.panelPartyMember1Left.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Center:
                    this.panelPartyMember1Center.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember1Right:
                    this.panelPartyMember1Right.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerLeft:
                    this.panelPlayerLeft.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerCenter:
                    this.panelPlayerCenter.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PlayerRight:
                    this.panelPlayerRight.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Left:
                    this.panelPartyMember2Left.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Center:
                    this.panelPartyMember2Center.Controls.Remove(buttonNote);
                    break;
                case FieldLane.PartyMember2Right:
                    this.panelPartyMember2Right.Controls.Remove(buttonNote);
                    break;
                case FieldLane.SomewhereRight:
                    this.panelSomewhereRight.Controls.Remove(buttonNote);
                    break;
                case FieldLane.OutOfMapRight:
                    this.panelOutOfMapRight.Controls.Remove(buttonNote);
                    break;
                default:
                    break;
            }
        }
    }
}
