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
    public class SaveCommand : CommandBase
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
            if (_bookReository.SaveBook(book))
            {
                _mainViewModel.Clear();
                _mainViewModel.DisplayListView();
            }
        }

        // 실행 가능 여부 체크
        public override bool CanExecute(object? parameter)
        {
            return IsValidSave(GetBook());
        }

        public override void Execute(object? parameter)
        {
            Save();
        }
    }
}
