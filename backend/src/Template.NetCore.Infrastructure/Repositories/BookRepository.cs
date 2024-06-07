using Template.NetCore.Domain.Books;
using Template.NetCore.Infrastructure.Context;

namespace Template.NetCore.Infrastructure.Repositories
{
    /*
     * Repository: Mediates between the domain and data mapping layers 
     * using a collection-like interface for accessing domain objects. 
     * https://martinfowler.com/eaaCatalog/repository.html
     * 
     * This is the implementation for ITaskRepository which needs to
     * implement the generic IRepository actions. 
     * Both are located in Domain layer given that they are interfaces
     * attached to Task domain (these interfaces are called ports in
     * hexagonal architecture and the implementation in this class is
     * called adapter)
     * 
     * With this architecture pattern your data access code can be changed
     * easily only performing the changes in this class. 
     * You may want to use a MongoDB, SQL or whatever, you just need to 
     * change it here.
     */

    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext dbContext) : base(dbContext) { }
    }
}
