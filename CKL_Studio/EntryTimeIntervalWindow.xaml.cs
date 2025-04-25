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
	/// Логика взаимодействия для EntryTimeIntervalWindow.xaml
	/// </summary>
	public partial class EntryTimeIntervalWindow : Window
	{
		private TimeIntervalAction _timeAction;
		private TimeIntervalWithDeltaAction _timeDeltaAction;
		private ObjectsWithTimeIntervalAction _objsAction; 
		public EntryTimeIntervalWindow(TimeIntervalAction timeAction)
		{
			InitializeComponent();
			_timeAction = timeAction;
		}

		public EntryTimeIntervalWindow(TimeIntervalWithDeltaAction timeDeltaAction) 
		{
			InitializeComponent();
			_timeDeltaAction = timeDeltaAction;
		}

		public EntryTimeIntervalWindow(ObjectsWithTimeIntervalAction objsAction) 
		{
			InitializeComponent();
			_objsAction = objsAction;
		}

		private void ConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			TimeInterval interval = new TimeInterval(Convert.ToDouble(StartTimeTextBox.Text), Convert.ToDouble(EndTimeTextBox.Text));

			if (_timeDeltaAction != null) new EntryDeltaWindow(_timeDeltaAction, interval).ShowDialog();

			else if (_objsAction != null) 
				new EntryObjectsWindow(_objsAction, interval).ShowDialog();

			else _timeAction?.Invoke(interval);

			Hide();
		}
    }
}
