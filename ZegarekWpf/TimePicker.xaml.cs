using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZegarekWpf
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
			var now = DateTime.Now;
			Hours = now.Hour;
			Minutes = now.Minute;
			Seconds = now.Second;
			txtHours.Text = now.ToString("HH");
			txtMinutes.Text = now.ToString("mm");
		}

		#region Properties

		#region Value

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
				"Value",
				typeof(TimeSpan),
				typeof(TimePicker),
				new UIPropertyMetadata(DateTime.Now.TimeOfDay, new PropertyChangedCallback(OnValueChanged)));

		public TimeSpan Value
		{
			get { return (TimeSpan)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		#endregion Value

		#region Hours

		public static readonly DependencyProperty HoursProperty = DependencyProperty.Register(
				"Hours",
				typeof(int),
				typeof(TimePicker),
				new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		public int Hours
		{
			get { return (int)GetValue(HoursProperty); }
			set { SetValue(HoursProperty, value); }
		}

		#endregion Hours

		#region Minutes

		public static readonly DependencyProperty MinutesProperty = DependencyProperty.Register(
				"Minutes",
				typeof(int),
				typeof(TimePicker),
				new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		public int Minutes
		{
			get { return (int)GetValue(MinutesProperty); }
			set { SetValue(MinutesProperty, value); }
		}

		#endregion Minutes

		#region Seconds

		public static readonly DependencyProperty SecondsProperty = DependencyProperty.Register(
				"Seconds",
				typeof(int),
				typeof(TimePicker),
				new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		public int Seconds
		{
			get { return (int)GetValue(SecondsProperty); }
			set { SetValue(SecondsProperty, value); }
		}

		#endregion Seconds

		#endregion Properties

		private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			var picker = obj as TimePicker;
			picker.Hours = ((TimeSpan)e.NewValue).Hours;
			picker.Minutes = ((TimeSpan)e.NewValue).Minutes;
			picker.Seconds = ((TimeSpan)e.NewValue).Seconds;
		}

		private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			var picker = obj as TimePicker;
			picker.Value = new TimeSpan(picker.Hours, picker.Minutes, picker.Seconds);
		}
		
		/*
		
		private void txt_KeyUp(object sender, KeyEventArgs e)
		{
			// check for up and down keyboard presses
			if (Key.Up.Equals(e.Key))
			{
				btnUp_Click(this, null);
			}
			else if (Key.Down.Equals(e.Key))
			{
				btnDown_Click(this, null);
			}
		}

		private void txt_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (e.Delta > 0)
			{
				btnUp_Click(this, null);
			}
			else
			{
				btnDown_Click(this, null);
			}
		}

		private void txt_PreviewKeyUp(object sender, KeyEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			// make sure all characters are number
			bool allNumbers = textBox.Text.All(Char.IsNumber);
			if (!allNumbers)
			{
				e.Handled = true;
				return;
			}
			
			// make sure user did not enter values out of range
			int value;
			int.TryParse(textBox.Text, out value);
			if ("txtHours".Equals(textBox.Name) && value > 12)
			{
				EnforceLimits(e, textBox);
			}
			else if ("txtMinutes".Equals(textBox.Name) && value > 59)
			{
				EnforceLimits(e, textBox);
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Enforces the limits.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
		/// <param name="textBox">The text box.</param>
		/// <param name="enteredValue">The entered value.</param>
		private static void EnforceLimits(KeyEventArgs e, TextBox textBox)
		{
			string enteredValue = GetEnteredValue(e.Key);
			string text = textBox.Text.Replace(enteredValue, "");
			if (string.IsNullOrEmpty(text))
			{
				text = enteredValue;
			}
			textBox.Text = text;
			e.Handled = true;
		}

		/// <summary>
		/// Gets the entered value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		private static string GetEnteredValue(Key key)
		{
			string value = string.Empty;
			switch (key)
			{
				case Key.D0:
				case Key.NumPad0:
					value = "0";
					break;
				case Key.D1:
				case Key.NumPad1:
					value = "1";
					break;
				case Key.D2:
				case Key.NumPad2:
					value = "2";
					break;
				case Key.D3:
				case Key.NumPad3:
					value = "3";
					break;
				case Key.D4:
				case Key.NumPad4:
					value = "4";
					break;
				case Key.D5:
				case Key.NumPad5:
					value = "5";
					break;
				case Key.D6:
				case Key.NumPad6:
					value = "6";
					break;
				case Key.D7:
				case Key.NumPad7:
					value = "7";
					break;
				case Key.D8:
				case Key.NumPad8:
					value = "8";
					break;
				case Key.D9:
				case Key.NumPad9:
					value = "9";
					break;
			}
			return value;
		}
		*/

		#region Event Subscriptions

		private void btnUp_Click(object sender, RoutedEventArgs e)
		{
			string controlId = GetControlWithFocus()?.Name;
			if (controlId == txtHours.Name)
				ChangeHours(ChangeDirection.Increment);
			else if (controlId == txtMinutes.Name)
				ChangeMinutes(ChangeDirection.Increment);
		}

		private void btnDown_Click(object sender, RoutedEventArgs e)
		{
			string controlId = GetControlWithFocus()?.Name;
			if (controlId == txtHours.Name)
				ChangeHours(ChangeDirection.Decrement);
			else if (controlId == txtMinutes.Name)
				ChangeMinutes(ChangeDirection.Decrement);
		}

		#endregion Event Subscriptions

		#region Methods

		private void ChangeHours(ChangeDirection direction)
		{
			var currentHours = Hours;
			switch (direction)
			{
				case ChangeDirection.Increment:
					currentHours++;
					if (currentHours > 23)
						currentHours = 0;
					break;
				case ChangeDirection.Decrement:
					currentHours--;
					if (currentHours < 0)
						currentHours = 23;
					break;
			}
			Hours = currentHours;
		}

		private void ChangeMinutes(ChangeDirection direction)
		{
			var currentMinutes = Minutes;
			switch (direction)
			{
				case ChangeDirection.Increment:
					currentMinutes++;
					if (currentMinutes > 59)
						currentMinutes = 0;
					break;
				case ChangeDirection.Decrement:
					currentMinutes--;
					if (currentMinutes < 0)
						currentMinutes = 59;
					break;
			}
			Minutes = currentMinutes;
		}

		private TextBox GetControlWithFocus()
		{
			TextBox txt = null;
			if (txtHours.IsFocused)
				txt = txtHours;
			else if (txtMinutes.IsFocused)
				txt = txtMinutes;

			return txt;
		}

		private enum ChangeDirection
		{
			Increment,
			Decrement
		}

		#endregion Methods
	}
}
