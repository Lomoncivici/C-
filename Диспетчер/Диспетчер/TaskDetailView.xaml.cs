using System.Windows;
using System.Windows.Controls;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    public partial class TaskDetailView : UserControl
    {
        public TaskDetailView()
        {
            InitializeComponent();
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as TaskDetailViewModel;
            viewModel?.DeleteTaskCommand.Execute(null);
        }
    }
}