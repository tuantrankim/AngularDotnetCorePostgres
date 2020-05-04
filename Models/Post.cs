using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
