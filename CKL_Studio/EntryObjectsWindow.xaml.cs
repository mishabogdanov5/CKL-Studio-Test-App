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
	public partial class EntryObjectsWindow : Window
	{
		private ObjectsWithTimeIntervalAction _action;
		private TimeInterval _interval;
		public EntryObjectsWindow(ObjectsWithTimeIntervalAction action, TimeInterval interval)
		{
			InitializeComponent();
			
			_interval = interval;
			_action = action;
		}

		private List<object> GetObjects(string s) 
		{
			return s.Split(',').Select(str => (object)str).ToList();
		}

		private void EntryButton_Click(object sender, RoutedEventArgs e)
		{
			//try
			//{
				_action?.Invoke(GetObjects(ObjectsTextBox.Text), _interval);
			//}
			//catch (Exception ex) 
			//{
				//MessageBox.Show(ex.Message);
			//}

			Hide();
        }
    }
}
