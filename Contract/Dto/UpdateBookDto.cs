#nullable enable
using System;

namespace Contract.Dto
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Description { set; get; }
        public Guid? AuthorId { get; set; }
    }
}