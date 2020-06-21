using System.ComponentModel.DataAnnotations;

namespace AngularDotnetCore.Models
{
    public class Category
    {
        //By default Id is set to be primary key, auto generate
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? CategoryGroupId { get; set; }
        public CategoryGroup CategoryGroup { get; set; }
        [StringLength(2000)]
        public string ExternalUrl { get; set; }
        [StringLength(50)]
        public string Icon { get; set; }
        public int? PostCount { get; set; }
    }
}
