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
using System.Windows.Shapes;
using CKLLib;

namespace WPFTraining
{
	/// <summary>
	/// Логика взаимодействия для EntryDeltaWindow.xaml
	/// </summary>
	public partial class EntryDeltaWindow : Window
	{
		private TimeIntervalWithDeltaAction _action;
		private TimeInterval _interval;
		public EntryDeltaWindow(TimeIntervalWithDeltaAction action, TimeInterval interval)
		{
			InitializeComponent();
			_action = action;
			_interval = interval;
		}

		private void ConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			double delta = Convert.ToDouble(DeltaTextBox.Text);
			_action.Invoke(_interval, delta);

			Hide();
        }
    }
}
