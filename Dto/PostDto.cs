using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Dto
{
    public class PostDto
    {
        public int? Id { get; set; }
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public string PostalCode { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
