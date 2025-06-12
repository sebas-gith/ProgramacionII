﻿using System.ComponentModel.DataAnnotations;

namespace Administradora_de_libros.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; } 
    }
}
