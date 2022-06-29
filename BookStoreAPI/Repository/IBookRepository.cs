using BookStoreAPI.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(Book book);
        Task UpdateBookAsync(int id, Book book);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument book);
        Task DeleteBookAsync(int id);
    }
}
