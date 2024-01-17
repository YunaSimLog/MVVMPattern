using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMPattern.Models;

namespace MVVMPattern.ViewModels
{
    public class MainViewModel
    {
        private readonly IBookReository _bookReository;

        public MainViewModel(IBookReository bookReository)
        {
            _bookReository = bookReository;

            SaveCommand = new SaveCommand(this, bookReository);
        }

        public string ID { get; set; } = "";
        public string Title { get; set; } = "";
        public string Renter { get; set; } = "";
        public string RentalPeriod { get; set; } = "";

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
