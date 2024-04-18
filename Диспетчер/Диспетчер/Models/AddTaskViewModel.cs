using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Interfaces;

namespace TaskManager.ViewModels
{
    public class AddTaskViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public AddTaskViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SaveTaskCommand = new RelayCommand(SaveTask);
            CancelCommand = new RelayCommand(Cancel);
        }

        public ICommand SaveTaskCommand { get; }
        public ICommand CancelCommand { get; }

        private void SaveTask()
        {
            _dialogService.CloseDialog();
        }

        private void Cancel()
        {
            _dialogService.CloseDialog();
        }
    }
}