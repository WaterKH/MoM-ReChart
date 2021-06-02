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
    public partial class FieldSubChartNoteComponent : UserControl
    {
        public int ChartOffset { get; set; }
        public int ChartLength { get; set; }
        public FieldChartComponent ParentChartComponent;

        public ObservableCollection<MoMButton<FieldAnimation>> Animations = new ObservableCollection<MoMButton<FieldAnimation>>();

        public FieldSubChartNoteComponent()
        {
            InitializeComponent();
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void animationClose_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;
        }

        public void LoadSubChartComponent(int id, FieldNote note, FieldChartComponent parentChartComponent)
        {
            this.Visible = true;

            this.ParentChartComponent = parentChartComponent;

            //var note = momButton.Note;

            this.fieldNoteComponent.fieldNoteGroup.Text = $"Field Note {id}";
            this.fieldNoteComponent.timeValue.Text = note.HitTime.ToString();
            this.fieldNoteComponent.laneDropdown.SelectedItem = note.Lane.ToString();
            this.fieldNoteComponent.modelDropdown.SelectedItem = note.ModelType.ToString();
            this.fieldNoteComponent.starFlag.Checked = note.StarFlag;
            this.fieldNoteComponent.previousNoteValue.Text = note.PreviousEnemyNote.ToString();
            this.fieldNoteComponent.nextNoteValue.Text = note.NextEnemyNote.ToString();
            this.fieldNoteComponent.projectileNoteEnemy.Text = note.ProjectileOriginNote.ToString();

            if (note.ModelType == FieldModelType.Projectile)
            {
                if (note.NoteType == 2)
                    this.fieldNoteComponent.modelDropdown.SelectedItem = "Projectile";
                else
                    this.fieldNoteComponent.modelDropdown.SelectedItem = "ProjectileEnemy";
            }
            else if (note.ModelType == FieldModelType.RareEnemyProjectile)
            {
                if (note.NoteType == 2)
                    this.fieldNoteComponent.modelDropdown.SelectedItem = "RareEnemyProjectile";
                else
                    this.fieldNoteComponent.modelDropdown.SelectedItem = "RareEnemy";
            }

            // Setup Animations
            this.LoadAnimationChartComponent(note.Animations);
        }

        public void LoadSubChartComponent(int id, FieldAsset asset, FieldChartComponent parentChartComponent)
        {
            this.Visible = true;
        }

        public void LoadSubChartComponent(int id, PerformerNote<FieldLane> performer, FieldChartComponent parentChartComponent)
        {
            this.Visible = true;
        }

        public void LoadSubChartComponent(int id, TimeShift time, FieldChartComponent parentChartComponent)
        {
            this.Visible = true;
        }

        public void LoadAnimationChartComponent(List<FieldAnimation> anims)
        {
            this.ClearPanels();

            var toolTip = new ToolTip();

            foreach (var anim in anims)
            {
                var momButton = new MoMButton<FieldAnimation>
                {
                    Id = anim.Id,
                    Type = "Animation",
                    Note = anim,
                    Button = new Button
                    {
                        Text = "",
                        //Image = Image.FromFile("Resources/note_shadow.png"),
                        BackColor = Color.AliceBlue,
                        Height = 19,
                        Width = 19,
                        Name = $"anim-{anim.Id}",
                        TabStop = false
                    },
                };

                momButton.Button.Click += (object sender, EventArgs e) =>
                {
                    this.animationPanel.Visible = true;
                    this.fieldAnimationComponent.LoadAnimationComponent(momButton);
                };
                this.Animations.Add(momButton);

                toolTip.SetToolTip(momButton.Button, anim.AnimationEndTime.ToString());

                this.AddToLane(anim.Lane, momButton.Button);
            }

            this.CalculateAnimationChartLength();
            this.SetAnimationPositions();
        }

        public void ClearPanels()
        {
            foreach (Panel lane in this.chartAnimationPanel.Controls)
            {
                lane.Size = new Size(0, 19);
            }

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

        private void saveAnimation_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;

            var animIndex = int.Parse(this.fieldAnimationComponent.fieldEnemyAnimationGroup.Text.Split(' ')[^1]);
            var noteIndex = int.Parse(this.fieldNoteComponent.fieldNoteGroup.Text.Split(' ')[^1]);

            var anim = this.ParentChartComponent.Notes[noteIndex].Note.Animations[animIndex];

            anim.AnimationStartTime = int.Parse(this.fieldAnimationComponent.startTimeValue.Text);
            anim.AnimationEndTime = int.Parse(this.fieldAnimationComponent.endTimeValue.Text);
            anim.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.fieldAnimationComponent.laneDropdown.SelectedItem.ToString());
            anim.AerialFlag = this.fieldAnimationComponent.aerialFlag.Checked;
            anim.Previous = int.Parse(this.fieldAnimationComponent.startNoteValue.Text);
            anim.Next = int.Parse(this.fieldAnimationComponent.endNoteValue.Text);

            this.ParentChartComponent.Notes[noteIndex].Note.Animations[animIndex] = anim;
            this.Animations[animIndex].Button.Location = new Point((Animations[animIndex].Note.AnimationEndTime - this.ChartOffset) / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.CalculateAnimationChartLength();
            this.SetAnimationPositions();

            this.AddToLane(this.Animations[animIndex].Note.Lane, this.Animations[animIndex].Button);
        }

        private void deleteAnimation_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;

            var animIndex = int.Parse(this.fieldAnimationComponent.fieldEnemyAnimationGroup.Text.Split(' ')[^1]);
            var noteIndex = int.Parse(this.fieldNoteComponent.fieldNoteGroup.Text.Split(' ')[^1]);

            // TODO Check for if it's a note or other

            this.RemoveFromLane(this.Animations[animIndex].Note.Lane, this.Animations[animIndex].Button);

            this.Animations[animIndex].Button.Visible = false;
            this.Animations[animIndex].Button = null;
            this.ParentChartComponent.Notes[noteIndex].Note.Animations.RemoveAt(animIndex);
            this.Animations.RemoveAt(animIndex);
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.fieldNoteComponent.fieldNoteGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Notes[noteIndex];
            var note = momButton.Note;

            //this.RemoveFromLane(note.Lane, momButton.Button);

            note.NoteType = this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Crystal") ? 1 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Projectile") ? 2 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "GlideNote" ? 3 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "Barrel" ||
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "Crate" ? 4 :
                    0;
            note.HitTime = int.Parse(this.fieldNoteComponent.timeValue.Text);
            note.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.fieldNoteComponent.laneDropdown.SelectedItem.ToString());
            note.AerialFlag = (this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Aerial") && this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() != "HittableAerialUncommonEnemy") ||
                        (this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "GlideNote" && this.fieldNoteComponent.previousNoteValue.Text == "-1") || this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Aerial") ||
                        this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "Projectile"; //|| (note.modelDropdown.SelectedItem.ToString() == "ProjectileEnemy" && note.aerialFlag.Checked))
            note.ProjectileOriginNote = int.Parse(this.fieldNoteComponent.projectileNoteEnemy.Text);
            note.NextEnemyNote = int.Parse(this.fieldNoteComponent.nextNoteValue.Text);
            note.PreviousEnemyNote = int.Parse(this.fieldNoteComponent.previousNoteValue.Text);
            note.ModelType = (FieldModelType)Enum.Parse(typeof(FieldModelType), this.fieldNoteComponent.modelDropdown.SelectedItem.ToString());
            note.StarFlag = this.fieldNoteComponent.starFlag.Checked;
            note.PartyFlag = this.fieldNoteComponent.partyFlag.Checked;
            //note.AlternateFlag Unk3 = note.alternateModel.Checked // TODO Unk3 is the alternate model flag it seems

            ParentChartComponent.Notes[noteIndex].Note = note;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(note.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, note.HitTime.ToString());
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var noteIndex = int.Parse(this.fieldNoteComponent.fieldNoteGroup.Text.Split(' ')[^1]);

            this.ParentChartComponent.RemoveFromLane(this.ParentChartComponent.Notes[noteIndex].Note.Lane, this.ParentChartComponent.Notes[noteIndex].Button);

            this.ParentChartComponent.Notes[noteIndex].Button.Visible = false;
            this.ParentChartComponent.Notes[noteIndex].Button = null;
            this.ParentChartComponent.Notes.RemoveAt(noteIndex);
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            var noteIndex = int.Parse(this.fieldNoteComponent.fieldNoteGroup.Text.Split(' ')[^1]);
            var animIndex = this.ParentChartComponent.Notes[noteIndex].Note.Animations.Count;
            
            var toolTip = new ToolTip();

            var momButton = new MoMButton<FieldAnimation>
            {
                Id = this.Animations.Count,
                Type = "Animation",
                Note = new FieldAnimation
                {
                    AnimationStartTime = this.ChartOffset,
                    AnimationEndTime = this.ChartOffset
                },
                Button = new Button
                {
                    Text = "",
                    //Image = Image.FromFile("Resources/note_shadow.png"),
                    BackColor = Color.AliceBlue,
                    Height = 19,
                    Width = 19,
                    Name = $"anim-{this.Animations.Count}",
                    TabStop = false
                },
            };

            momButton.Button.Location = new Point(0, 0);

            momButton.Button.Click += (object sender, EventArgs e) =>
            {
                this.animationPanel.Visible = true;
                this.fieldAnimationComponent.LoadAnimationComponent(momButton);
            };
            this.Animations.Add(momButton);
            this.ParentChartComponent.Notes[noteIndex].Note.Animations.Add(momButton.Note);

            toolTip.SetToolTip(momButton.Button, momButton.Note.AnimationEndTime.ToString());

            this.AddToLane(FieldLane.OutOfMapLeft, momButton.Button);
        }

        private void AddToLane(FieldLane lane, Button buttonNote)
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

        private void RemoveFromLane(FieldLane lane, Button buttonNote)
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

        private void CalculateAnimationChartLength()
        {
            this.ChartOffset = this.Animations.Select(x => x.Note.AnimationEndTime).OrderBy(x => x).FirstOrDefault();
            var endTime = this.Animations.Select(x => x.Note.AnimationEndTime).OrderByDescending(x => x).FirstOrDefault();
            this.ChartLength = ((endTime - this.ChartOffset) + 5000) / 10;

            this.panelOutOfMapLeft.Width = this.ChartLength;
            this.panelSomewhereLeft.Width = this.ChartLength;
            this.panelPartyMember1Left.Width = this.ChartLength;
            this.panelPartyMember1Center.Width = this.ChartLength;
            this.panelPartyMember1Right.Width = this.ChartLength;
            this.panelPlayerLeft.Width = this.ChartLength;
            this.panelPlayerCenter.Width = this.ChartLength;
            this.panelPlayerRight.Width = this.ChartLength;
            this.panelPartyMember2Left.Width = this.ChartLength;
            this.panelPartyMember2Center.Width = this.ChartLength;
            this.panelPartyMember2Right.Width = this.ChartLength;
            this.panelSomewhereRight.Width = this.ChartLength;
            this.panelOutOfMapRight.Width = this.ChartLength;
        }

        private void SetAnimationPositions()
        {
            this.Animations.ToList().ForEach(x => x.Button.Location = new Point((x.Note.AnimationEndTime - this.ChartOffset) / 10, 0));
        }
    }
}
