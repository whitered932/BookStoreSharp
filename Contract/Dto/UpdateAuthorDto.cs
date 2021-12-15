#nullable enable
using System;

namespace Contract.Dto
{
    public class UpdateAuthorDto
    {
        public String? Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}