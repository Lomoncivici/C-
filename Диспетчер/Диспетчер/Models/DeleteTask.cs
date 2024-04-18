using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private ObservableCollection<TaskModel> _tasks;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _tasks = new ObservableCollection<TaskModel>();

            AddTaskCommand = new RelayCommand(OpenAddTaskWindow);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        private void OpenAddTaskWindow()
        {
            _dialogService.ShowAddTaskDialog();
        }

        private void DeleteTask(object parameter)
        {
            if (parameter is TaskModel task)
            {
                Tasks.Remove(task);
            }
        }
    }
}