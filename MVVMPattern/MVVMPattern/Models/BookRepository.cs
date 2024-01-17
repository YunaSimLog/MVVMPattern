using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using MVVMPattern.Properties;

namespace MVVMPattern.Models
{
    public class BookRepository : IBookReository
    {
        private List<Book> GetBooks()
        {
            IEnumerable<Book>? tmpBooks = GetAllBookList();
            List<Book> books;

            if (tmpBooks != null)
                books = tmpBooks.ToList();
            else
                books = new List<Book>();

            return books;
        }

        private void SaveSettings(IEnumerable<Book> book)
        {
            string jsonData = JsonSerializer.Serialize(book);
            Settings settings = new Settings();
            settings.BookJsonData = jsonData;
            settings.Save();
        }

        public IEnumerable<Book>? GetAllBookList()
        {
            string jsonData = new Settings().BookJsonData;
            return string.IsNullOrWhiteSpace(jsonData)
                ? null
                : JsonSerializer.Deserialize<IEnumerable<Book>>(jsonData);
        }

        public bool SaveBook(Book book)
        {
            try
            {
                var books = GetBooks();

                // 이미 존재하는 ID일 경우 예외처리
                if (books.Exists(b => b.ID == book.ID))
                {
                    MessageBox.Show("이미 등록된 ID 입니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                books.Add(book);

                SaveSettings(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool RemoveBook(int id)
        {
            var books = GetBooks();

            try
            {
                var book = books.Find(b => b.ID == id);
                if (book == null)
                {
                    MessageBox.Show("존재하지 않는 ID 입니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                books.Remove(book);

                SaveSettings(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool ExistBook(int id) => GetBooks().Exists(b => b.ID == id);
    }
}
