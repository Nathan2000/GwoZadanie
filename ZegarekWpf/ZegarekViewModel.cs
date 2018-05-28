using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZegarekLib;

namespace ZegarekWpf
{
	class ZegarekViewModel : DependencyObject
	{
		//public ClockFace Clock { get; set; }

		// Hack. I don't know how to get information on the automatically calculated element size to the ViewModel
		public int ClockFaceWidth { get; set; } = 174;
		public int ClockFaceHeight { get; set; } = 174;
		
		#region Clock
		
		public static readonly DependencyProperty ClockProperty = DependencyProperty.Register(
				"Clock",
				typeof(ClockFace),
				typeof(ZegarekViewModel));

		public ClockFace Clock
		{
			get { return (ClockFace)GetValue(ClockProperty); }
			set { SetValue(ClockProperty, value); }
		}

		#endregion Clock

		#region Time

		public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
				"Time",
				typeof(TimeSpan),
				typeof(ZegarekViewModel),
				new UIPropertyMetadata(DateTime.Now.TimeOfDay, new PropertyChangedCallback(OnTimeChanged)));

		public TimeSpan Time
		{
			get { return (TimeSpan)GetValue(TimeProperty); }
			set { SetValue(TimeProperty, value); }
		}

		#endregion Time

		private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			var zegarek = obj as ZegarekViewModel;
			zegarek.Clock.SetTime((TimeSpan)e.NewValue);
		}
		
		public ZegarekViewModel()
		{
			Clock = new ClockFace(ClockFaceWidth, ClockFaceHeight);
			Clock.SetTime(DateTime.Now);
		}
	}
}
