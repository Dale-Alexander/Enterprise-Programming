using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IBooksRepository
    {
        public void AddBook(Book b);
        public Book? GetBook(string isbn);
        public IQueryable<Book> GetBooks();
        public IQueryable<Book> GetBooks(string keyword);
        public IQueryable<Book> GetBooks(string keyword, int pageSize, int startAt);
        public void UpdateBook(Book b);
        public void DeleteBook(string isbn);




    }
}
