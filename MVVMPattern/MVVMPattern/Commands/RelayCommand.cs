using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPattern.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T>? _execute;
        private readonly Predicate<T>? _canExecute;

        // 대리자로 외부에서 호출할 수 있게처리함.
        public RelayCommand(Action<T>? execute, Predicate<T>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            // ?? => 값이 없다면 true로 반환
            return _canExecute?.Invoke((T)parameter!) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke((T)parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
