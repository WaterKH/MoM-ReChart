using MoMMusicAnalysis;
using MoMTool.Components.SelfContainedComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoMTool.Logic
{
    public class BeatManager<TLane>
    {
        public int ZoomVariable { get; set; } = 10;
        public TimeShift<TLane> CurrentTempo { get; set; }
        public int CurrentTime { get; set; }
        public int Offset { get; set; }
        public int OffsetRemainder { get; set; }

        public List<Line> WholeBeats { get; set; } = new List<Line> { null };
        public List<Line> HalfBeats { get; set; } = new List<Line> { null, null };
        public List<Line> QuarterBeats { get; set; } = new List<Line> { null, null, null, null };
        public List<Line> EighthBeats { get; set; } = new List<Line> { null, null, null, null, null, null, null, null };
        public List<Line> SixteenthBeats { get; set; } = new List<Line> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        public List<Line> ThirtySecondBeats { get; set; } = new List<Line> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        //public void CalculateOffset(FieldChartComponent chart)
        //{
        //    this.Offset = chart.Notes.FirstOrDefault().Note.HitTime % chart.Times.FirstOrDefault().Note.Speed;

        //    this.OffsetRemainder = this.Offset % Settings.ZoomVariable;
        //    this.Offset /= Settings.ZoomVariable;

            //chart.Times.FirstOrDefault().Button.Location = new Point(this.Offset, 0);
        //}

        public Line SnapToBeat(int positionX)
        {
            Line closestTime = null;

            switch (Settings.CurrentBeat)
            {
                case Beat.None:
                    break;
                case Beat.Whole:
                    closestTime = this.WholeBeats.FirstOrDefault();
                    break;
                case Beat.Half:
                    closestTime = this.FindClosestBeat(this.HalfBeats, positionX);
                    break;
                case Beat.Quarter:
                    closestTime = this.FindClosestBeat(this.QuarterBeats, positionX);
                    break;
                case Beat.Eighth:
                    closestTime = this.FindClosestBeat(this.EighthBeats, positionX);
                    break;
                case Beat.Sixteenth:
                    closestTime = this.FindClosestBeat(this.SixteenthBeats, positionX);
                    break;
                case Beat.ThirtySecond:
                    closestTime = this.FindClosestBeat(this.ThirtySecondBeats, positionX);
                    break;
                default:
                    break;
            }

            return closestTime;
        }

        public bool DisplayChartBeats(List<MoMButton<TimeShift<TLane>>> times, TransparentPanel chart, int positionX)
        {
            TimeShift<TLane> currTempo = null;

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

                        if (positionX > (time.HitTime + this.Offset) / this.ZoomVariable && positionX <= (nextTime.HitTime + this.Offset) / this.ZoomVariable)
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

            var tempoWhole = (currTempo.Speed * 4) / Settings.ZoomVariable;

            var currentTime = (positionX / tempoWhole) * tempoWhole;
            
            if (currentTime != this.CurrentTime)
            {
                this.ClearChartBeats(chart);

                this.CurrentTempo = currTempo;
                this.CurrentTime = currentTime;

                this.CreateChartBeats(chart.Height);

                chart.Visible = true;

                return true;
            }

            return false;
        }

        private void CreateChartBeats(int panelHeight)
        {
            var wholeNote = (this.CurrentTempo.Speed * 4) / this.ZoomVariable;
            //var offset = this.CurrentTime % Settings.ZoomVariable;
            for (int i = 0; i < 1; ++i)
                this.WholeBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.Purple, ForeColor = Color.Purple, Location = new Point((wholeNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.Whole };

            var halfNote = (this.CurrentTempo.Speed * 2) / this.ZoomVariable;
            //var halfNoteOffset = (this.CurrentTime / 2) % Settings.ZoomVariable;
            for (int i = 0; i < 2; ++i)
                this.HalfBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.MediumPurple, ForeColor = Color.MediumPurple, Location = new Point((halfNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.Half };

            var quarterNote = (this.CurrentTempo.Speed) / this.ZoomVariable;
            //var quarterNoteOffset = (this.CurrentTime / 4) % Settings.ZoomVariable;
            for (int i = 0; i < 4; ++i)
                this.QuarterBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.MediumPurple, ForeColor = Color.MediumPurple, Location = new Point((quarterNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.Quarter };

            var eighthNote = (this.CurrentTempo.Speed / 2) / this.ZoomVariable;
            //var eighthNoteOffset = (this.CurrentTime / 8) % Settings.ZoomVariable;
            for (int i = 0; i < 8; ++i)
                this.EighthBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.MediumPurple, ForeColor = Color.MediumPurple, Location = new Point((eighthNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.Eighth };

            var sixteenthNote = (this.CurrentTempo.Speed / 4) / this.ZoomVariable;
            //var sixteenthNoteOffset = (this.CurrentTime / 16) % Settings.ZoomVariable;
            for (int i = 0; i < 16; ++i)
                this.SixteenthBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.MediumPurple, ForeColor = Color.MediumPurple, Location = new Point((sixteenthNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.Sixteenth };

            var thirtySecondNote = (this.CurrentTempo.Speed / 8) / this.ZoomVariable;
            //var thirtySecondNoteOffset = (this.CurrentTime / 32) % Settings.ZoomVariable;
            for (int i = 0; i < 32; ++i)
                this.ThirtySecondBeats[i] = new Line { Direction = "Vertical", Offset = this.Offset, OffsetRemainder = this.OffsetRemainder, BackColor = Color.MediumPurple, ForeColor = Color.MediumPurple, Location = new Point((thirtySecondNote * i) + this.CurrentTime + this.Offset, 0), Size = new Size(1, panelHeight), Visible = Settings.CurrentBeat == Beat.ThirtySecond };
        }

        public void ClearChartBeats(TransparentPanel chart)
        {
            for (int i = 0; i < this.WholeBeats.Count; ++i)
                this.ClearChartBeat(this.WholeBeats[i], chart);

            for (int i = 0; i < this.HalfBeats.Count; ++i)
                this.ClearChartBeat(this.HalfBeats[i], chart);

            for (int i = 0; i < this.QuarterBeats.Count; ++i)
                this.ClearChartBeat(this.QuarterBeats[i], chart);

            for (int i = 0; i < this.EighthBeats.Count; ++i)
                this.ClearChartBeat(this.EighthBeats[i], chart);

            for (int i = 0; i < this.SixteenthBeats.Count; ++i)
                this.ClearChartBeat(this.SixteenthBeats[i], chart);

            for (int i = 0; i < this.ThirtySecondBeats.Count; ++i)
                this.ClearChartBeat(this.ThirtySecondBeats[i], chart);

            chart.Visible = false;
        }

        private void ClearChartBeat(Line line, TransparentPanel chart)
        {
            if (line != null)
            {
                chart.Controls.Remove(line);

                line.Visible = false;
                line = null;
            }
        }

        private Line FindClosestBeat(List<Line> beats, int positionX)
        {
            var closestTime = beats.Aggregate((x, y) => Math.Abs(x.Location.X - positionX) < Math.Abs(y.Location.X - positionX) ? x : y);

            beats.ForEach(x =>
            {
                if (x.Location.X == closestTime.Location.X)
                {
                    x.BackColor = Color.MediumPurple;
                    x.ForeColor = Color.MediumPurple;
                }
                else
                {
                    x.BackColor = Color.Purple;
                    x.ForeColor = Color.Purple;
                }
            });

            return closestTime;
        }
    }
}