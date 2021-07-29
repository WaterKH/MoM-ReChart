using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MoMTool.Components.SelfContainedComponents
{
    public partial class Line : UserControl
    {
        public string Direction { get; set; } = ""; // "Up" - For when the next note is above the current one; "Down" - For when the next note is below the current one; "" - For center notes
        public int Offset { get; set; } = 0;
        public int OffsetRemainder { get; set; } = 0;

        public Line()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            Point[] points;
            GraphicsPath path = new GraphicsPath();

            if (this.Direction == "Vertical")
            {
                points = new Point[] {
                    new Point(0, Height),
                    new Point(1, Height),
                    new Point(1, 0),
                    new Point(0, 0),
                };
            }
            else if (this.Direction == "Up")
            {
                points = new Point[] {
                    new Point(0, Height - 3),
                    new Point(3, Height),
                    new Point(Width, 3),
                    new Point(Width - 3, 0),
                };
            }
            else if (this.Direction == "Down")
            {
                points = new Point[] {
                    new Point(3, 0),
                    new Point(0, 3),
                    new Point(Width - 3, Height),
                    new Point(Width, Height - 3),
                };
            }
            else
            {
                points = new Point[] {
                    new Point(0, (Height - 3) / 2),
                    new Point(Width, (Height - 3) / 2),
                    new Point(Width, (Height + 3) / 2),
                    new Point(0, (Height + 3) / 2),
                };
            }

            path.AddPolygon(points);

            this.Region = new Region(path);
        }
    }
}