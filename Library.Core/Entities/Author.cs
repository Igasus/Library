namespace Library.Core.Entities;

public class Author : Entity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public virtual Address BirthAddress { get; set; }
    
    public virtual ICollection<Book> Books { get; set; }
    public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
}