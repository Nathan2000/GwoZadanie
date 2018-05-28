using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZegarekLib
{
    public class ClockFace : INotifyPropertyChanged
	{
		public int SmallHandLength { get; set; }
		public int LargeHandLength { get; set; }

		private Point center;
		private int radius;
		private Point topLeftCorner;
		private Point smallHandPoint;
		private Point largeHandPoint;
		private double angleRadians;

		public Point Center
		{
			get { return center; }
			set { if (center != value) { center = value; NotifyPropertyChanged(); } }
		}

		public int Radius
		{
			get { return radius; }
			set { if (radius != value) { radius = value; NotifyPropertyChanged(); NotifyPropertyChanged("Diameter"); } }
		}

		public int Diameter { get { return radius * 2; } }

		public Point TopLeftCorner
		{
			get { return topLeftCorner; }
			set { if (topLeftCorner != value) { topLeftCorner = value; NotifyPropertyChanged(); } }
		}

		public Point SmallHandPoint
		{
			get { return smallHandPoint; }
			set { if (smallHandPoint != value) { smallHandPoint = value; NotifyPropertyChanged(); } }
		}

		public Point LargeHandPoint
		{
			get { return largeHandPoint; }
			set { if (largeHandPoint != value) { largeHandPoint = value; NotifyPropertyChanged(); } }
		}

		public double AngleRadians
		{
			get { return angleRadians; }
			set { if (angleRadians != value) { angleRadians = value; NotifyPropertyChanged(); NotifyPropertyChanged("AngleDegrees"); } }
		}

		public double AngleDegrees { get { return angleRadians * 180.0 / Math.PI; } }

		public event PropertyChangedEventHandler PropertyChanged;

		// This method is called by the Set accessor of each property.
		// The CallerMemberName attribute that is applied to the optional propertyName
		// parameter causes the property name of the caller to be substituted as an argument.
		private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ClockFace(int areaWidth, int areaHeight)
		{
			int halfWidth = areaWidth / 2;
			int halfHeight = areaHeight / 2;

			Center = new Point(halfWidth, halfHeight);
			Radius = Math.Min(halfWidth, halfHeight) - 10;
			TopLeftCorner = new Point(halfWidth - Radius, halfHeight - Radius);
			
			SmallHandLength = Radius - 40;
			LargeHandLength = Radius - 20;

			SetTime(DateTime.Now);
		}

		public void SetTime(DateTime date)
		{
			SetTime(date.TimeOfDay);
		}

		public void SetTime(TimeSpan time)
		{
			var smallHandAngle = time.Hours % 12.0 / 12.0 * 2 * Math.PI;
			var largeHandAngle = time.Minutes / 60.0 * 2 * Math.PI;
			SmallHandPoint = new Point(
				Center.X + (int)GetHandX(smallHandAngle, SmallHandLength),
				Center.Y - (int)GetHandY(smallHandAngle, SmallHandLength));
			LargeHandPoint = new Point(
				Center.X + (int)GetHandX(largeHandAngle, LargeHandLength),
				Center.Y - (int)GetHandY(largeHandAngle, LargeHandLength));
			AngleRadians = GetAngleBetween(smallHandAngle, largeHandAngle);
		}

		private double GetHandX(double angle, double handLength)
		{
			return handLength * Math.Sin(angle);
		}

		private double GetHandY(double angle, double handLength)
		{
			return handLength * Math.Cos(angle);
		}

		private double GetAngleBetween(double angle1, double angle2)
		{
			var tempAngle = Math.Abs(angle2 - angle1);
			if (tempAngle > Math.PI)
				tempAngle = 2 * Math.PI - tempAngle;

			return tempAngle;
		}
	}
}
