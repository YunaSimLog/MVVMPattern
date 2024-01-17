using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPattern.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Renter { get; set; }
        public DateTime? RentalPeriod { get; set; }

        /// <summary>
        /// 책을 대여하여, 대여 날짜를 업데이트 한다.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        public void RentBook(int id, Book book)
        {
            Renter = book.Renter;
            RentalPeriod = book.RentalPeriod;
        }
    }
}
