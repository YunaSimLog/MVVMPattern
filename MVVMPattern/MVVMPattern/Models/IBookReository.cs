using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPattern.Models
{
    public interface IBookReository
    {
        // 모든 책리스트를 가져온다.
        IEnumerable<Book>? GetAllBookList();

        // 책을 추가한다.
        bool AddNewBook(Book book);

        // 책을 제거한다.
        bool RemoveBook(int id);

        // 책이 존재하는지 확인한다.
        bool ExistBook(int id);
    }
}
