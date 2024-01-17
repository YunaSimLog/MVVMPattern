using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPattern.Commands
{
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// 실행 가능 여부 체크
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool CanExecute(object? parameter);

        /// <summary>
        /// 동작 실행
        /// </summary>
        /// <param name="parameter">연결된 뷰의 컨트롤에에서 CommandParameter="TestData" 값을 가져옴</param>
        public abstract void Execute(object? parameter);

        /// <summary>
        /// UI 상태 변화를 검출
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
