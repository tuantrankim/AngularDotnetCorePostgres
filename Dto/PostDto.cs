using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Dto
{
    public class PostDto
    {
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        public string City { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
