using Common.Models;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Addbook(Book b)
        {
            _context.Books.Add(b);
        }
    }
}
