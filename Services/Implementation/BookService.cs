using BookStore.Entities;
using BookStore.Helpers;
using BookStore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class BookService : IBookService
    {
        public List<Category> GetAllCategories()
        {
            return DBHelper.GetAllCategories();
        }

        public List<Book> GetAllBooks()
        {
            return DBHelper.GetAllBooks();
        }
    }
}
