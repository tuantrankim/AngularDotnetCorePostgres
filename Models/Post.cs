using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Models
{
    public class Post
    {
        //By default Id is set to be primary key and auto increase
        public int? Id { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string Content { get; set; }
        
        public string City { get; set; }
        public int? CityId { get; set; }
        public int? CategoryId { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
         
    }
}
