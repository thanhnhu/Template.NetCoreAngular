/*
 * Repository: Mediates between the domain and data mapping layers 
 * using a collection-like interface for accessing domain objects. 
 * 
 * https://martinfowler.com/eaaCatalog/repository.html
 * 
 * This is the interface of the repository for books which uses the
 * generic repository for all actions IRepository<Book>
 * To be implemented in Infrastructure layer
 */

namespace Template.NetCore.Domain.Books
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
