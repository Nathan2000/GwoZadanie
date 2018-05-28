using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZegarekLib;

namespace ZegarekWinForms
{
    public partial class Form1 : Form
    {
        Pen largeHandPen = new Pen(Color.Black, 2);
        Pen smallHandPen = new Pen(Color.Black, 4);
		ClockFace clock;

        public Form1()
        {
            InitializeComponent();
			clock = new ClockFace(clockFace.Width, clockFace.Height);

            clockFace.Image = new Bitmap(clockFace.Width, clockFace.Height);
            Redraw();
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
			clock.SetTime(timePicker.Value);

            using (var g = Graphics.FromImage(clockFace.Image))
            {
                g.Clear(Color.Transparent);
                g.DrawEllipse(
					Pens.Black,
					clock.TopLeftCorner.X,
					clock.TopLeftCorner.Y,
					clock.Radius * 2,
					clock.Radius * 2);
                g.DrawLine(
                    smallHandPen,
                    clock.Center.X,
                    clock.Center.Y,
                    clock.SmallHandPoint.X,
                    clock.SmallHandPoint.Y);
                g.DrawLine(
                    largeHandPen,
					clock.Center.X,
					clock.Center.Y,
					clock.LargeHandPoint.X,
					clock.LargeHandPoint.Y);
                clockFace.Refresh();
            }
            
            txtAngle.Text = string.Format("{0}°", clock.AngleDegrees);
        }
    }
}
