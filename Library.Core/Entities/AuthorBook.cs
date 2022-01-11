﻿namespace Library.Core.Entities;

public class AuthorBook
{
    public int AuthorId { get; set; }
    public int BookId { get; set; }

    public virtual Author Author { get; set; }
    public virtual Book Book { get; set; }
}