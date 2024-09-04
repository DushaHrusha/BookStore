using BookStore.Core.Models;

public interface IBooksService
{
    public Task<List<Book>> GetAllBooks();

    public Task<Guid> CreateBook(Book book);

    public Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    
    public Task<Guid> DeleteBook(Guid id);
}