using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMPattern.Commands;
using MVVMPattern.Models;

namespace MVVMPattern.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _ID = "";
        private string _Title = "";
        private string _Renter = "";
        private string _RentalPeriod = "";
        private ObservableCollection<Book>? _Books = null;

        private readonly IBookReository _bookReository;

        public MainViewModel(IBookReository bookReository)
        {
            _bookReository = bookReository;

            SaveCommand = new SaveCommand(this, bookReository);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);
            CancelCommand = new RelayCommand<object>(_ => Clear());
            MouseLeftButtonUpCommand = new RelayCommand<Book>(MouseButtonUp);
            DisplayListView();
        }

        private void MouseButtonUp(Book book)
        {
            ID = book.ID.ToString();
            Title = book.Title;
            Renter = book.Renter;
            RentalPeriod = book.RentalPeriod.ToString();
        }

        private bool CanDelete(object _)
        {
            int.TryParse(ID, out int id);
            return id > 0;
        }

        private void Delete(object _)
        {
            int.TryParse(ID, out int id);
            if (_bookReository.RemoveBook(Convert.ToInt32(id)))
            {
                Clear();

                DisplayListView();
            }
        }

        public void Clear()
        {
            ID = "";
            Title = "";
            Renter = "";
            RentalPeriod = "";
            //OnPropertyChanged("ID"); // ID가 변경된 사항을 알려준다.
        }

        public void DisplayListView()
        {
            var tmpBook = _bookReository.GetAllBookList();
            if (tmpBook != null)
                Books = new ObservableCollection<Book>(tmpBook);
            else
                Books = new ObservableCollection<Book>();
            //OnPropertyChanged("Books"); ; // Books 리스트가 변경된 사항을 알려준다.
        }


        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        public string Renter
        {
            get => _Renter;
            set
            {
                _Renter = value;
                OnPropertyChanged();
            }
        }

        public string RentalPeriod
        {
            get => _RentalPeriod;
            set
            {
                _RentalPeriod = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book>? Books
        {
            get => _Books;  // 상태를 관찰할 수 있는 컬렉션
            set
            {
                _Books = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand MouseLeftButtonUpCommand { get; set; }
    }
}
