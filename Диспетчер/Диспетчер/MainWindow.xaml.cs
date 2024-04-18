using System;
using System.Windows;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;

            viewModel?.AddTaskCommand.Execute(null);
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;

            var selectedTask = TasksListBox.SelectedItem as TaskModel;

            if (selectedTask != null)
            {
                viewModel?.DeleteTaskCommand.Execute(selectedTask);
            }
        }
    }
}