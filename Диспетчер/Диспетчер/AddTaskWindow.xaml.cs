using System.Windows;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    public partial class AddTaskWindow : Window
    {
        public AddTaskWindow()
        {
            InitializeComponent();
            DataContext = new AddTaskViewModel();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as AddTaskViewModel;

            viewModel?.SaveTaskCommand.Execute(null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as AddTaskViewModel;

            viewModel?.CancelCommand.Execute(null);
        }
    }
}