using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Contract.Models;

namespace Contract.Dto
{
    public class CreateBookDTO
    {
        [Required] public string Title { get; set; }
        [Required] public Guid AuthorId { get; set; }

        [AllowNull] public string Description { get; set; }
    }
}