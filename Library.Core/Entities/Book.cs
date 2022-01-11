namespace Library.Core.Entities;

public class Book : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int PagesAmount { get; set; }
    
    public virtual Address CreationAddress { get; set; }
    
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
}