using System.Configuration;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using CKLLib;
using CKLDrawing;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.IO;
using CKLLib.Operations;
namespace WPFTraining
{
	public partial class MainWindow : Window
	{
		private CKLView _view;
		public MainWindow()
		{
			InitializeComponent();

			CKL ckl = new CKL();

			
			_view = new CKLView(ckl);

			Container.Children.Add(_view);

			_operationsButtons = new Button[] { TimeTransformButton, UnionButton, IntersectButton, DifferenceButton, 
			SemanticUnionButton, SemanticIntersectButton, SemanticDifferenceButton, TranspositionButton, 
				TruncateLowButton, TruncateHighButton, CompositionButton};

		}

		private void ResetCkl(CKL ckl)
		{
			Container.Children.Remove(_view);
			_view = new CKLView(ckl);
			Container.Children.Add(_view);
			FilePathLabel.Content = ckl.FilePath;
		}

		private Button[] _operationsButtons;

		private void ChangeOperationsButtonsColors(Button active)
		{
			foreach (Button button in _operationsButtons) 
			{
				if (button.Equals(active)) button.Background = new SolidColorBrush(Colors.White);
				else button.Background = new SolidColorBrush(Color.FromRgb(221,221,221));
			}
		}

        private void BrowseButtonClick(object sender, RoutedEventArgs e) 
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "CKL Files (*.ckl)|*.ckl";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (dialog.ShowDialog() == true) 
            {
                string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) 
				{
					MessageBox.Show($"Unavailable to open this ckl file!");
				}

				try
				{
					ResetCkl(CKL.GetFromFile(path));
				}
				catch (Exception ex) 
				{
					MessageBox.Show($"Error opening: {ex.Message}");
				}
            }
        }

        private void OnUnionClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

                CKL unionCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.Union(_view.Ckl, unionCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnIntersectClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL intersectCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.Intersection(_view.Ckl, intersectCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnDifferenceClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL diffCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.Difference(_view.Ckl, diffCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnInversionClick(object sender, RoutedEventArgs e) 
        {
			try
			{
				ResetCkl(CKLMath.Inversion(_view.Ckl));
				ChangeOperationsButtonsColors((Button)sender);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show($"Uncorrect data: {ex.Message}");
			}
		}

        private void OnSemanticUnionClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL semanticUnionCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.SemanticUnion(_view.Ckl, semanticUnionCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnSemanticIntersectClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL semanticIntersectCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.SemanticIntersection(_view.Ckl, semanticIntersectCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnSemanticDifferenceClick(object sender, RoutedEventArgs e) 
        {
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL semanticDiffCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.SemanticDifference(_view.Ckl, semanticDiffCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

		private void OnTranspositionButtonClick(object sender, RoutedEventArgs e) 
		{
			try
			{
				ResetCkl(CKLMath.Tranposition(_view.Ckl));
				ChangeOperationsButtonsColors((Button)sender);
			}
			catch (ArgumentException ex) 
			{
				MessageBox.Show($"Uncorrect data: {ex.Message}");
			}
		}

		private void OnCompositionButtonClick(object sender, RoutedEventArgs e) 
		{
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "CKL Files (*.ckl)|*.ckl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				if (CKL.GetFromFile(path) == null) return;

				CKL compositionCkl = CKL.GetFromFile(path);

				try
				{
					ResetCkl(CKLMath.Composition(_view.Ckl, compositionCkl));
					ChangeOperationsButtonsColors((Button)sender);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show($"Uncorrect data: {ex.Message}");
				}
			}
		}

        private void OnSaveClick(object sender, RoutedEventArgs e) 
        {
            try
            {
                CKL.Save(_view.Ckl);
                MessageBox.Show("File is succesfull saved!");
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private int _currentDelCoast = 0;
        private TimeDimentions _currentDimentions = default;
		private static readonly int[] TIME_DIMENTIONS_CONVERT = new int[] { 1000, 1000, 1000, 60, 60, 24, 7 };

		private void ScalePlus_Click(object sender, RoutedEventArgs e)
		{
            if (_currentDelCoast != _view.DelCoast)
            {
                _currentDelCoast = _view.DelCoast;
                _currentDimentions = _view.TimeDimention;
            }
           
            if (_currentDelCoast * 2 >= TIME_DIMENTIONS_CONVERT[(int)_currentDimentions] 
                    && !_currentDimentions.Equals(TimeDimentions.WEEKS)) 
            {
                _currentDelCoast = 1;
                _currentDimentions = (TimeDimentions)(int)_currentDimentions + 1;
            }
            else _currentDelCoast *= 2;
            
            
            _view.ChangeDelCoast(_currentDimentions, _currentDelCoast);
            
		}

		private void ScaleMinus_Click(object sender, RoutedEventArgs e)
		{
			if (_currentDelCoast != _view.DelCoast)
			{
				_currentDelCoast = _view.DelCoast;
				_currentDimentions = _view.TimeDimention;
			}

            if (_currentDelCoast / 2 == 0
                    && !_currentDimentions.Equals(TimeDimentions.NANOSECONDS))
            {
                _currentDimentions = (TimeDimentions)(int)_currentDimentions - 1;
                _currentDelCoast = TIME_DIMENTIONS_CONVERT[(int)_currentDimentions] / 2;
            }
            else if (_currentDelCoast >= 2) _currentDelCoast /= 2;
			
            _view.ChangeDelCoast(_currentDimentions, _currentDelCoast);
		}
	}
}