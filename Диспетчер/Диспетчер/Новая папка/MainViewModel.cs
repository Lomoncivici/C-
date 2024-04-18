using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<TaskModel> _tasks;

        public MainViewModel()
        {
            _tasks = new ObservableCollection<TaskModel>();
            AddTaskCommand = new RelayCommand(OpenAddTaskWindow);
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
    }
}