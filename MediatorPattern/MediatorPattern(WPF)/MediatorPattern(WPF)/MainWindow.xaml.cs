using System.Windows;
using System.Windows.Controls;

namespace MediatorPattern_WPF_
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Mediator mediator = new Mediator();
		public MainWindow()
		{
			InitializeComponent();
			mediator.Register(txtName);
			mediator.Register(lstName);
			mediator.Register(btnAdd);
			mediator.Register(btnClear);
		}

		private void txtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			mediator.TextChange();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			mediator.ClickAddButton();
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			mediator.ClickClearButton();
		}
	}

	public class Mediator
	{
		private TextBox objTextBox;
		private ListBox objListBox;
		private Button objBtnAdd;
		private Button objBtnClear;

		public void Register(Control obj)
		{
			if (obj is TextBox)
			{
				objTextBox = obj as TextBox;
			}
			else if (obj is ListBox)
			{
				objListBox = obj as ListBox;
			}
			else if (obj is Button)
			{
				if (obj.Name == "btnAdd")
				{
					objBtnAdd = obj as Button;
				}
				else
				{
					objBtnClear = obj as Button;
				}
				obj.IsEnabled = false;
			}
		}

		public void TextChange()
		{
			if (objTextBox.Text.Length > 0)
			{
				objBtnAdd.IsEnabled = true;
				objBtnClear.IsEnabled = true;
			}
			else
			{
				objBtnAdd.IsEnabled = false;
				objBtnClear.IsEnabled = false;
			}
		}

		public void ClickAddButton()
		{
			objListBox.Items.Add(objTextBox.Text);
			objBtnAdd.IsEnabled = false;
			objBtnClear.IsEnabled = false;
			objTextBox.Text = "";
		}

		public void ClickClearButton()
		{
			objTextBox.Text = "";
			objBtnAdd.IsEnabled = false;
			objBtnClear.IsEnabled = false;
		}
	}
}
