using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BooksJsonRepository : IBooksRepository
    {
        public BooksJsonRepository(string pathToJson)
        {
            _pathToJson = pathToJson;
            if (System.IO.File.Exists(pathToJson) == false)
            {
                using (var fs = System.IO.File.Create(pathToJson))
                    fs.Close();
            }
        }
        private string _pathToJson = "Books.json";
        public void AddBook(Book b)
        {
            //1. get the entire list
            List<Book> myBooks = GetBooks().ToList();
            //2. Add new book to the existent list
            if (GetBook(b.Isbn) == null)
                myBooks.Add(b);
            else throw new Exception("Book already exists");
            //3. Save it back
            //convert from object to a json string
            //aka json serialization
            string jsonBooks = JsonSerializer.Serialize(myBooks);
            System.IO.File.WriteAllText(_pathToJson, jsonBooks);
        }

        public void DeleteBook(string isbn)
        {
            throw new NotImplementedException();
        }

        public Book? GetBook(string isbn)
        {
            return GetBooks().SingleOrDefault(x => x.Isbn == isbn);
        }

        public IQueryable<Book> GetBooks()
        {
            string fileContents = System.IO.File.ReadAllText(_pathToJson);
            //1. Convert from json string into an object (List<Book>)
            //aka json deserialization
            if (string.IsNullOrEmpty(fileContents) == false)
            {
                try
                {
                    List<Book> myBooks = JsonSerializer.Deserialize<List<Book>>(fileContents);
                    return myBooks.AsQueryable();
                }
                catch (Exception ex)
                {
                    //Logging 
                    return new List<Book>().AsQueryable();
                }
            }
            else
            {
                return new List<Book>().AsQueryable();
            }
        }

        public IQueryable<Book> GetBooks(string keyword)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetBooks(string keyword, int pageSize, int startAt)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
