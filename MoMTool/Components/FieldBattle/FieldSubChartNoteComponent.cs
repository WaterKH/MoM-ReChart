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
        public FieldChartComponent ParentChartComponent { get; set; }
        public FieldBattleSubChartManager FieldBattleSubChartManager { get; set; }

        public ObservableCollection<MoMButton<FieldAnimation>> Animations = new ObservableCollection<MoMButton<FieldAnimation>>();

        public FieldSubChartNoteComponent()
        {
            InitializeComponent();

            this.fieldNoteComponent.modelDropdown.SelectedIndexChanged += this.modelDropdown_SelectedIndexChanged;
        }

        private void noteClose_Click(object sender, EventArgs e)
        {
            this.FieldBattleSubChartManager.Close();
        }

        private void animationClose_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;
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

        private void modelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem.ToString();

            var visible = item.Contains("Multi") || item.Contains("Glide");
            var time = int.Parse(this.fieldNoteComponent.timeValue.Text);

            this.fieldNoteComponent.nextNote.Visible = visible;
            this.fieldNoteComponent.nextNoteDropdown.Visible = visible;
            this.fieldNoteComponent.previousNote.Visible = visible;
            this.fieldNoteComponent.previousNoteDropdown.Visible = visible;

            if (visible)
            {
                // TODO Look into this and make sure the Enum is being parsed correctly (Issue with multiple Enums with same number)
                var nextItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.ModelType.ToString() == item && x.HitTime > time);
                this.fieldNoteComponent.nextNoteDropdown.Items.AddRange(nextItems.ToArray());

                var prevItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.ModelType.ToString() == item && x.HitTime < time);
                this.fieldNoteComponent.previousNoteDropdown.Items.AddRange(prevItems.ToArray());
            }

            visible = item.Equals("EnemyShooterProjectile") || item.Equals("AerialEnemyShooterProjectile");

            this.fieldNoteComponent.projectileNote.Visible = visible;
            this.fieldNoteComponent.shooterDropdown.Visible = visible;

            if (visible)
            {
                IEnumerable<FieldNote> shooterItems = null;

                if (item == "EnemyShooterProjectile")
                    shooterItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.ModelType.ToString() == "EnemyShooterProjectile" && x.NoteType == 0 && x.HitTime > time);
                else if (item == "AerialEnemyShooterProjectile")
                    shooterItems = this.ParentChartComponent.Notes.Select(x => x.Note).Where(x => x.ModelType.ToString() == "AerialEnemyShooterProjectile" && x.NoteType == 0 && x.HitTime > time);

                this.fieldNoteComponent.shooterDropdown.Items.AddRange(shooterItems.ToArray());
            }
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

            note.NoteType = this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Crystal") ? 1 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Projectile") ? 2 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "GlideNote" ? 3 :
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "Barrel" ||
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "Crate" ? 4 :
                    0;
            note.HitTime = int.Parse(this.fieldNoteComponent.timeValue.Text);
            note.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.fieldNoteComponent.laneDropdown.SelectedItem.ToString());
            note.AerialFlag = (this.fieldNoteComponent.modelDropdown.SelectedItem.ToString().Contains("Aerial") && 
                (this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() != "HittableAerialUncommonEnemy") && 
                    this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() != "AerialEnemyShooterProjectile") ||
                (this.fieldNoteComponent.modelDropdown.SelectedItem.ToString() == "GlideNote" && this.fieldNoteComponent.previousNoteDropdown.SelectedItem == null);
            note.ProjectileOriginNote = (FieldNote)this.fieldNoteComponent.shooterDropdown.SelectedItem;
            note.NextEnemyNote = (FieldNote)this.fieldNoteComponent.nextNoteDropdown.SelectedItem;
            note.PreviousEnemyNote = (FieldNote)this.fieldNoteComponent.previousNoteDropdown.SelectedItem;
            note.ModelType = (FieldModelType)Enum.Parse(typeof(FieldModelType), this.fieldNoteComponent.modelDropdown.SelectedItem.ToString());
            note.StarFlag = this.fieldNoteComponent.starFlag.Checked;
            note.PartyFlag = this.fieldNoteComponent.partyFlag.Checked;
            //note.AlternateFlag Unk3 = note.alternateModel.Checked // TODO Unk3 is the alternate model flag it seems

            if (note.ModelType == FieldModelType.MultiHitGroundEnemy || note.ModelType == FieldModelType.MultiHitAerialEnemy)
            {
                if (note.PreviousEnemyNote != null)
                {
                    note.Animations[0].AnimationStartTime = note.HitTime;
                    note.Animations[0].AnimationEndTime = note.HitTime;
                }
            }

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

        public void CalculateAnimationChartLength()
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

        public void SetAnimationPositions()
        {
            this.Animations.ToList().ForEach(x => x.Button.Location = new Point((x.Note.AnimationEndTime - this.ChartOffset) / 10, 0));
        }
    }
}