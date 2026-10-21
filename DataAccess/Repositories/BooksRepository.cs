using Common.Models;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.Repositories
{
    //What is the role of a Repository?
    //The repository class will define CRUD (Create Read Update Delete)
    //operations which will be LINQ based

    //The idea about the management of instance creation is to create an instance once in the beginning and inject it
    //in the client classes (such as BooksRepository)
    //Without knowing we are utilizing a design pattern called DEPENDENCY INJECTION
    public class BooksRepository
    {
        private LibraryDbContext _context;
        public BooksRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> GetBooks() {
            return _context.Books;
        }
        public IQueryable<Book> GetBooks(string keyword)
        {
            return GetBooks().Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
        public IQueryable<Book> GetBooks(string keyword, int pageSize, int startAt)
        {
            return GetBooks(keyword).Skip(startAt).Take(pageSize);
        }

        public void AddBook(Book b)
        {
            _context.Books.Add(b);
            _context.SaveChanges();
        }
        //public async Task<Book> GetBook(string isbn)
        //{
        //    if (string.IsNullOrEmpty(isbn))
        //    {
        //        throw new Exception();
        //    }
        //    var book = await _context.Books.FirstOrDefaultAsync(b => b.Isbn == isbn);
        //    if(book == null{
        //        throw new BadRequestException(new {message = ""})
        //    }
        //}
    }
}
