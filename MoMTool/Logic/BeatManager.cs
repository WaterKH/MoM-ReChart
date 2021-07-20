using MoMMusicAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class BeatManager
    {
        public int ZoomVariable { get; set; } = 10;
        public TimeShift<FieldLane> CurrentTempo { get; set; }
        public int CurrentTime { get; set; }

        public List<Panel> WholeBeats { get; set; } = new List<Panel> { null };
        public List<Panel> HalfBeats { get; set; } = new List<Panel> { null, null };
        public List<Panel> QuarterBeats { get; set; } = new List<Panel> { null, null, null, null };
        public List<Panel> EighthBeats { get; set; } = new List<Panel> { null, null, null, null, null, null, null, null };
        public List<Panel> SixteenthBeats { get; set; } = new List<Panel> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        public List<Panel> ThirtySecondBeats { get; set; } = new List<Panel> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        public void DisplayChartBeats(List<MoMButton<TimeShift<FieldLane>>> times, Point position, int panelHeight)
        {
            TimeShift<FieldLane> currTempo = null;

            if (times.Count == 1)
            {
                currTempo = times.FirstOrDefault().Note;
            }
            else
            {
                for (int i = 0; i < times.Count; ++i)
                {
                    var time = times[i].Note;

                    if (i + 1 < times.Count)
                    {
                        var nextTime = times[i + 1].Note;

                        if ((position.X * this.ZoomVariable) >= time.HitTime && (position.X * this.ZoomVariable) < nextTime.HitTime)
                        {
                            currTempo = time;

                            break;
                        }
                    }
                    else
                    {
                        currTempo = time;
                    }
                }
            }

            var closestTime = ((int)(position.X / currTempo.Speed)) * currTempo.Speed;

            if (closestTime != this.CurrentTime)
            {
                this.CurrentTempo = currTempo;
                this.CurrentTime = closestTime;

                this.CreateChartBeats(panelHeight);
            }
        }

        private void CreateChartBeats(int panelHeight)
        {
            var wholeNote = (this.CurrentTempo.Speed * 4) / this.ZoomVariable;
            var halfNote = wholeNote / 2;
            var quarterNote = wholeNote / 4;
            var eighthNote = wholeNote / 8;
            var sixteenthNote = wholeNote / 16;
            var thirtySecondNote = wholeNote / 32;

            for (int i = 1; i <= 1; ++i)
                this.WholeBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((wholeNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.Whole };

            for (int i = 1; i <= 2; ++i)
                this.HalfBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((halfNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.Half };
            
            for (int i = 1; i <= 4; ++i)
                this.QuarterBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((quarterNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.Quarter };

            for (int i = 1; i <= 8; ++i)
                this.EighthBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((eighthNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.Eighth };

            for (int i = 1; i <= 16; ++i)
                this.SixteenthBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((sixteenthNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.Sixteenth };

            for (int i = 1; i <= 32; ++i)
                this.ThirtySecondBeats[i - 1] = new Panel { Width = 1, Height = panelHeight, Location = new Point((thirtySecondNote * i) + this.CurrentTime, 0), Visible = Settings.CurrentBeat == Beat.ThirtySecond };
        }
    }
}