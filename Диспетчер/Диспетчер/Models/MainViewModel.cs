using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Interfaces;
using System.Collections.ObjectModel;

namespace TaskManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Tasks = new ObservableCollection<TaskModel>();
            AddTaskCommand = new RelayCommand(OpenAddTaskWindow);
        }

        public ObservableCollection<TaskModel> Tasks { get; set; }

        public ICommand AddTaskCommand { get; }

        private void OpenAddTaskWindow()
        {
            _dialogService.ShowAddTaskDialog();
        }
    }
}