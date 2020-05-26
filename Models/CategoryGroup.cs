using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularDotnetCore.Models
{
    public class CategoryGroup
    {
        //By default Id is set to be primary key, auto generate
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
