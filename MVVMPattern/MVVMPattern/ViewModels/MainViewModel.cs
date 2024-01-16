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
        }

        public int ID { get; set; } = 1;
        public string Title { get; set; } = "dd";
        public string Writer { get; set; } = "cc";
        public string RentalPeriod { get; set; } = "ddd";
    }
}
