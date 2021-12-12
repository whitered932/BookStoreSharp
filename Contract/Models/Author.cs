using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        [Required] public string Name { get; set; }
        [Required] public DateTime BirthDate { get; set; } = DateTime.Now;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}