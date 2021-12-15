using System;

namespace Contract.Dto
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
    }
}