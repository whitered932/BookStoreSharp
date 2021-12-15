using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        [Required] public string Title { get; set; }

        [MinLength(50)] public string Description { get; set; }

        [ForeignKey("AuthorId")] public Author Author { get; set; }

        public Guid AuthorId { get; set; }
    }
}