using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class FieldBattleChartManager
    {
        public MusicFile MusicFile;
        public FieldBattleSubChartManager FieldBattleSubChartManager; // TODO Maybe make this private?

        public int ZoomVariable = 10;

        public Dictionary<Difficulty, FieldChartComponent> FieldCharts { get; set; }

        private readonly ToolTip ToolTip = null;

        public FieldBattleChartManager(MusicFile musicFile)
        {
            this.MusicFile = musicFile; 
            this.ToolTip = new ToolTip();
            this.FieldBattleSubChartManager = new FieldBattleSubChartManager();
        }

        public void DecompileFieldBattleSongs()
        {
            this.FieldCharts = new Dictionary<Difficulty, FieldChartComponent>();

            foreach (FieldBattleSong song in this.MusicFile.SongPositions.Values)
            {
                this.FieldCharts.Add(song.Difficulty, this.CreateChart(song));
            }
        }

        private FieldChartComponent CreateChart(FieldBattleSong fieldBattleSong)
        {
            var fieldChart = new FieldChartComponent();

            var songLength = (fieldBattleSong.Notes.OrderByDescending(x => x.HitTime).FirstOrDefault().HitTime);

            fieldChart.songTypeDropdown.SelectedItem = "Field Battle";
            fieldChart.notesCheckbox.Checked = true;
            fieldChart.assetsCheckbox.Checked = true;
            fieldChart.performerCheckbox.Checked = true;
            fieldChart.chartTimeValue.Text = songLength.ToString();


            fieldChart.Notes = this.CreateChartButtons(ref fieldChart, fieldBattleSong.NoteCount, fieldBattleSong.Notes, "Note", Color.Red);
            fieldChart.Assets = this.CreateChartButtons(ref fieldChart, fieldBattleSong.AssetCount, fieldBattleSong.FieldAssets, "Asset", Color.Blue);
            fieldChart.Performers = this.CreateChartButtons(ref fieldChart, fieldBattleSong.PerformerCount, fieldBattleSong.PerformerNotes, "Performer", Color.Purple);
            fieldChart.Times = this.CreateChartButtons(ref fieldChart, fieldBattleSong.TimeShiftCount, fieldBattleSong.TimeShifts, "Time", Color.Yellow);

            return fieldChart;
        }

        private ObservableCollection<MoMButton<TNoteType>> CreateChartButtons<TNoteType>(ref FieldChartComponent fieldChart, int count, List<TNoteType> components, string type, Color color) where TNoteType : Note<FieldLane>
        {
            var fieldChartButtons = new ObservableCollection<MoMButton<TNoteType>>();

            for (int i = 0; i < count; ++i)
            {
                this.CreateChartButton(ref fieldChart, i, components[i], type, color);
            }

            return fieldChartButtons;
        }

        public MoMButton<TNoteType> CreateChartButton<TNoteType>(ref FieldChartComponent fieldChart, int id, TNoteType component, string type, Color color) where TNoteType : Note<FieldLane>
        {
            var momButton = new MoMButton<TNoteType>
            {
                Id = id,
                Type = type,
                Note = component,
                Button = new Button
                {
                    Text = "",
                    //Image = Image.FromFile("Resources/note_shadow.png"),
                    BackColor = color,
                    Height = 19,
                    Width = 19,
                    Name = $"{type.ToLower()}-{id}",
                    TabStop = false
                },
            };

            momButton.Button.Location = new Point(momButton.Note.HitTime / this.ZoomVariable, 0);
            momButton.Button.Click += (object sender, EventArgs e) => { FieldBattleSubChartManager.LoadSubChartComponent(momButton.Id, momButton.Note); };

            ToolTip.SetToolTip(momButton.Button, momButton.Note.HitTime.ToString());

            fieldChart.AddToLane(momButton.Note.Lane, momButton.Button);

            return momButton;
        }
    }
}