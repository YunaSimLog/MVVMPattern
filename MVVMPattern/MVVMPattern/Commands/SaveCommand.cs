using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMPattern.Models;
using MVVMPattern.ViewModels;

namespace MVVMPattern.Commands
{
    public class SaveCommand : ICommand
    {
        MainViewModel _mainViewModel;
        IBookReository _bookReository;

        public SaveCommand(MainViewModel mainViewModel, IBookReository bookReository)
        {
            _mainViewModel = mainViewModel;
            _bookReository = bookReository;
        }

        private Book GetBook()
        {
            Book? book = new Book()
            {
                Title = _mainViewModel.Title,
                Renter = _mainViewModel.Renter,
            };

            int.TryParse(_mainViewModel.ID, out int id);
            DateTime.TryParse(_mainViewModel.RentalPeriod, out DateTime rentalPeriod);

            book.ID = id;
            book.RentalPeriod = rentalPeriod;

            return book;
        }

        private bool IsValidSave(Book book)
        {
            if (book.ID <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(book.Title))
                return false;
            if (book.RentalPeriod == default(DateTime) | string.IsNullOrWhiteSpace(book.Renter))
                return false;

            return true;
        }

        private void Save()
        {
            var book = GetBook();
            _bookReository.SaveBook(book);
        }

        // 실행 가능 여부 체크
        public bool CanExecute(object? parameter)
        {
            return IsValidSave(GetBook());
        }

        public void Execute(object? parameter)
        {
            Save();
        }

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
