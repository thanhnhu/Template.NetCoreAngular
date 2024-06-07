using System.ComponentModel.DataAnnotations;

/* 
 * An AGGREGATE is a cluster of associated objects that we treat 
 * as a unit for the purpose of data changes.Each AGGREGATE has a 
 * root and a boundary.The boundary defines what is inside the 
 * AGGREGATE.The root is a single, specific ENTITY contained 
 * in the AGGREGATE. 
 * 
 * It can be read simply and anyone can understand the meaning of
 * a Book and the scope of its definition just seeing this class.
 * Must be alligned with the language used by the requirements
 * (ubiqutuos language)
 */

namespace Template.NetCore.Domain.Books
{
    //public class Task : IAggregateRoot
    public class Book: Entity
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
