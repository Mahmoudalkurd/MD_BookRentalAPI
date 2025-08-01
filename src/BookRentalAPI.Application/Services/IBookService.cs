using BookRentalAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookRentalAPI.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(string filter = null, string sort = "asc");
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
