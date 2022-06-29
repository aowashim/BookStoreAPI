using BookStoreAPI.Data;
using BookStoreAPI.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }

        public async Task<int> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            //var bookFromDb = await _context.Books.FindAsync(id);

            //if (book != null)
            //{
            //    bookFromDb.Title = book.Title;
            //    bookFromDb.Description = book.Description;

            //    await _context.SaveChangesAsync();

            var updatedBook = new Book
            {
                Id = id,
                Title = book.Title,
                Description = book.Description,
            };

            _context.Books.Update(updatedBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument book)
        {
            var bookFromDb = await _context.Books.FindAsync(id);

            if (bookFromDb != null)
            {
                book.ApplyTo(bookFromDb);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Book { Id = id};

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
        }
    }
}

