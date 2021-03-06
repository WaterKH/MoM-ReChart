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
    public partial class FieldSubChartAssetComponent : UserControl
    {
        public int ChartOffset { get; set; }
        public int ChartLength { get; set; }
        public FieldChartComponent ParentChartComponent { get; set; }
        public FieldBattleSubChartManager FieldBattleSubChartManager { get; set; }

        public ObservableCollection<MoMButton<FieldAnimation>> Animations = new ObservableCollection<MoMButton<FieldAnimation>>();

        public FieldSubChartAssetComponent()
        {
            InitializeComponent();
        }

        private void assetClose_Click(object sender, EventArgs e)
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

        private void saveAnimation_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;

            var animIndex = int.Parse(this.fieldAnimationComponent.fieldEnemyAnimationGroup.Text.Split(' ')[^1]);
            var assetIndex = int.Parse(this.fieldAssetComponent.fieldAssetGroup.Text.Split(' ')[^1]);

            var anim = this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations.FirstOrDefault(x => x.Id == animIndex);


            anim.AnimationStartTime = int.Parse(this.fieldAnimationComponent.startTimeValue.Text);
            anim.AnimationEndTime = int.Parse(this.fieldAnimationComponent.endTimeValue.Text);
            anim.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.fieldAnimationComponent.laneDropdown.SelectedItem.ToString());
            anim.AerialFlag = this.fieldAnimationComponent.aerialFlag.Checked;
            anim.Previous = int.Parse(this.fieldAnimationComponent.startNoteValue.Text);
            anim.Next = int.Parse(this.fieldAnimationComponent.endNoteValue.Text);

            this.Animations.FirstOrDefault(x =>  x.Id == animIndex).Button.Location = new Point((this.Animations.FirstOrDefault(x => x.Id == animIndex).Note.AnimationEndTime - this.ChartOffset) / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.CalculateAnimationChartLength();
            this.SetAnimationPositions();

            this.AddToLane(this.Animations.FirstOrDefault(x => x.Id == animIndex).Note.Lane, this.Animations.FirstOrDefault(x => x.Id == animIndex).Button);
        }

        private void deleteAnimation_Click(object sender, EventArgs e)
        {
            this.animationPanel.Visible = false;

            var animIndex = int.Parse(this.fieldAnimationComponent.fieldEnemyAnimationGroup.Text.Split(' ')[^1]);
            var assetIndex = int.Parse(this.fieldAssetComponent.fieldAssetGroup.Text.Split(' ')[^1]);
            var anim = this.Animations.FirstOrDefault(x => x.Id == animIndex);

            this.RemoveFromLane(anim.Note.Lane, anim.Button);

            anim.Button.Visible = false;
            anim.Button = null;
            this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations.Remove(anim.Note);
            this.Animations.Remove(anim);

            for (int i = 0; i < this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations.Count; ++i)
                this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations[i].Id = i;
        }

        private void saveAsset_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var assetIndex = int.Parse(this.fieldAssetComponent.fieldAssetGroup.Text.Split(' ')[^1]);

            var momButton = ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex);
            var asset = momButton.Note;

            asset.JumpFlag = this.fieldAssetComponent.modelDropdown.SelectedItem.ToString().Contains("Arrow") ? true : false;
            asset.HitTime = int.Parse(this.fieldAssetComponent.timeValue.Text);
            asset.Lane = (FieldLane)Enum.Parse(typeof(FieldLane), this.fieldAssetComponent.laneDropdown.SelectedItem.ToString());
            asset.Unk1 = this.fieldAssetComponent.modelDropdown.SelectedItem.ToString() == "CrystalRightLeft" ? 1 : 0;

            if (this.fieldAssetComponent.modelDropdown.SelectedItem.ToString() == "AerialShooterArrow")
                asset.ModelType = FieldAssetType.AerialShooterArrow;
            else 
                asset.ModelType = (FieldAssetType)Enum.Parse(typeof(FieldAssetType), this.fieldAssetComponent.modelDropdown.SelectedItem.ToString());

            ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note = asset;
            momButton.Button.Location = new Point(momButton.Note.HitTime / 10, 0); // TODO Add back the this.zoomVariable in place of 10

            this.ParentChartComponent.AddToLane(asset.Lane, momButton.Button);
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(momButton.Button, asset.HitTime.ToString());

            momButton.Button.Image = this.FieldBattleSubChartManager.ParentChartManager.GetImageForModelType(asset.ModelType);
        }

        private void deleteAsset_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            var assetIndex = int.Parse(this.fieldAssetComponent.fieldAssetGroup.Text.Split(' ')[^1]);
            var asset = this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex);

            this.ParentChartComponent.RemoveFromLane(asset.Note.Lane, asset.Button);

            asset.Button.Visible = false;
            asset.Button = null;
            this.ParentChartComponent.Assets.Remove(asset);

            for (int i = 0; i < this.ParentChartComponent.Assets.Count; ++i)
                this.ParentChartComponent.Assets[i].Id = i;
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            var assetIndex = int.Parse(this.fieldAssetComponent.fieldAssetGroup.Text.Split(' ')[^1]);
            var animIndex = this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations.Count;

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
            this.ParentChartComponent.Assets.FirstOrDefault(x => x.Id == assetIndex).Note.Animations.Add(momButton.Note);

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