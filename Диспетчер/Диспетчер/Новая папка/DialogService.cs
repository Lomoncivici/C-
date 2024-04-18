using System.Windows;
using TaskManager.Interfaces;
using Диспетчер;

namespace TaskManager.Services
{
    public class DialogService : IDialogService
    {
        public void ShowAddTaskDialog()
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog();
        }
    }
}