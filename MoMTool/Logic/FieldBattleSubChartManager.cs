using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class FieldBattleSubChartManager
    {
        public FieldBattleChartManager ParentChartManager { get; set; }
        public bool DisplayingSubChart { get; set; } = false;

        public dynamic FieldSubChartComponent { get; set; }
        //public FieldSubChartAssetComponent FieldSubChartAssetComponent { get; set; }
        //public PerformerComponent PerformerComponent { get; set; }
        //public TimeShiftComponent TimeShiftComponent { get; set; }

        private readonly ToolTip toolTip;

        public FieldBattleSubChartManager(FieldBattleChartManager parentChartManager)
        {
            this.ParentChartManager = parentChartManager;
            this.toolTip = new ToolTip();
        }

        public void LoadSubChartComponent<TNoteType>(int id, TNoteType note) where TNoteType : Note<FieldLane>
        {
            if (this.FieldSubChartComponent != null)
            {
                this.Close();
            }

            // Switch on the type and load the correct subchart
            if (typeof(TNoteType) == typeof(FieldNote))
                this.LoadSubChartComponent(id, (FieldNote)(Note<FieldLane>)note);
            else if (typeof(TNoteType) == typeof(FieldAsset))
                this.LoadSubChartComponent(id, (FieldAsset)(Note<FieldLane>)note);
            else if (typeof(TNoteType) == typeof(PerformerNote<FieldLane>))
                this.LoadSubChartComponent(id, (PerformerNote<FieldLane>)(Note<FieldLane>)note);
            else if (typeof(TNoteType) == typeof(TimeShift<FieldLane>))
                this.LoadSubChartComponent(id, (TimeShift<FieldLane>)(Note<FieldLane>)note);

            this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.Add(this.FieldSubChartComponent);
            this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab].Controls[^1].BringToFront();

            this.DisplayingSubChart = true;
        }

        public void LoadSubChartComponent(int id, FieldNote note)
        {
            this.FieldSubChartComponent = new FieldSubChartNoteComponent { Visible = true };
            this.FieldSubChartComponent.FieldBattleSubChartManager = this;
            this.FieldSubChartComponent.ParentChartComponent = this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.FieldSubChartComponent.fieldNoteComponent.fieldNoteGroup.Text = $"Field Note {id}";
            this.FieldSubChartComponent.fieldNoteComponent.timeValue.Text = note.HitTime.ToString();
            this.FieldSubChartComponent.fieldNoteComponent.laneDropdown.SelectedItem = note.Lane.ToString();
            this.FieldSubChartComponent.fieldNoteComponent.modelDropdown.SelectedItem = note.ModelType.ToString();
            this.FieldSubChartComponent.fieldNoteComponent.starFlag.Checked = note.StarFlag;
            this.FieldSubChartComponent.fieldNoteComponent.previousNoteDropdown.SelectedItem = note.PreviousEnemyNote;
            this.FieldSubChartComponent.fieldNoteComponent.nextNoteDropdown.SelectedItem = note.NextEnemyNote;
            this.FieldSubChartComponent.fieldNoteComponent.shooterDropdown.SelectedItem = note.ProjectileOriginNote;

            if (note.ModelType == FieldModelType.EnemyShooterProjectile)
            {
                if (note.NoteType == 2)
                    this.FieldSubChartComponent.fieldNoteComponent.modelDropdown.SelectedItem = "EnemyShooterProjectile";
                else
                    this.FieldSubChartComponent.fieldNoteComponent.modelDropdown.SelectedItem = "EnemyShooter";
            }
            else if (note.ModelType == FieldModelType.AerialEnemyShooterProjectile)
            {
                if (note.NoteType == 2)
                    this.FieldSubChartComponent.fieldNoteComponent.modelDropdown.SelectedItem = "AerialEnemyShooterProjectile";
                else
                    this.FieldSubChartComponent.fieldNoteComponent.modelDropdown.SelectedItem = "AerialEnemyShooter";
            }

            // Setup Animations
            this.LoadAnimationChartComponent(note.Animations);
        }

        public void LoadSubChartComponent(int id, FieldAsset asset)
        {
            this.FieldSubChartComponent = new FieldSubChartAssetComponent { Visible = true };
            this.FieldSubChartComponent.FieldBattleSubChartManager = this;
            this.FieldSubChartComponent.ParentChartComponent = this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.FieldSubChartComponent.fieldAssetComponent.fieldAssetGroup.Text = $"Field Asset {id}";
            this.FieldSubChartComponent.fieldAssetComponent.timeValue.Text = asset.HitTime.ToString();
            this.FieldSubChartComponent.fieldAssetComponent.laneDropdown.SelectedItem = asset.Lane.ToString();
            this.FieldSubChartComponent.fieldAssetComponent.modelDropdown.SelectedItem = asset.ModelType.ToString();

            if (asset.ModelType == FieldAssetType.AerialShooterArrow)
            {
                this.FieldSubChartComponent.fieldAssetComponent.modelDropdown.SelectedItem = "AerialShooterArrow";
            }

            // Setup Animations
            this.LoadAnimationChartComponent(asset.Animations);
        }

        public void LoadSubChartComponent(int id, PerformerNote<FieldLane> performer)
        {
            this.FieldSubChartComponent = new PerformerComponent { Visible = true };
            this.FieldSubChartComponent.SubChartManager = this;
            this.FieldSubChartComponent.UpdateLane(typeof(FieldLane));
            this.FieldSubChartComponent.ParentChartComponent = this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.FieldSubChartComponent.performerGroup.Text = $"Performer Note {id}";
            this.FieldSubChartComponent.timeValue.Text = performer.HitTime.ToString();
            this.FieldSubChartComponent.laneDropdown.SelectedItem = performer.Lane.ToString();
            this.FieldSubChartComponent.typeDropdown.SelectedItem = performer.PerformerType.ToString();
        }

        public void LoadSubChartComponent(int id, TimeShift<FieldLane> time)
        {
            this.FieldSubChartComponent = new TimeShiftComponent { Visible = true };
            this.FieldSubChartComponent.SubChartManager = this;
            this.FieldSubChartComponent.ParentChartComponent = this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.FieldSubChartComponent.timeShiftGroup.Text = $"Time Shift {id}";
            this.FieldSubChartComponent.timeValue.Text = time.HitTime.ToString();
            this.FieldSubChartComponent.speedValue.Text = time.Speed.ToString();
        }

        private void LoadAnimationChartComponent(List<FieldAnimation> anims)
        {
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
                    this.FieldSubChartComponent.animationPanel.Visible = true;
                    this.FieldSubChartComponent.fieldAnimationComponent.LoadAnimationComponent(momButton);
                };
                this.FieldSubChartComponent.Animations.Add(momButton);

                toolTip.SetToolTip(momButton.Button, anim.AnimationEndTime.ToString());

                this.FieldSubChartComponent.AddToLane(anim.Lane, momButton.Button);
            }

            this.FieldSubChartComponent.CalculateAnimationChartLength();
            this.FieldSubChartComponent.SetAnimationPositions();
        }

        public void LoadSubChartOffsetComponent()
        {
            if (this.FieldSubChartComponent != null)
            {
                this.Close();
            }

            this.FieldSubChartComponent = new OffsetComponent { Visible = true };
            this.FieldSubChartComponent.SubChartManager = this;
            this.FieldSubChartComponent.ParentChartComponent = this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab];

            this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.Add(this.FieldSubChartComponent);
            this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab].Controls[^1].BringToFront();

            this.FieldSubChartComponent.valueOffset.Text = ((this.ParentChartManager.BeatManager.Offset * Settings.ZoomVariable) + this.ParentChartManager.BeatManager.OffsetRemainder).ToString();

            this.DisplayingSubChart = true;
        }

        public void Close()
        {
            this.ParentChartManager.FieldCharts[this.ParentChartManager.CurrentDifficultyTab].Controls.RemoveByKey(this.FieldSubChartComponent.Name);
            this.FieldSubChartComponent.Visible = false;
            this.FieldSubChartComponent = null;

            this.DisplayingSubChart = false;
        }
    }
}