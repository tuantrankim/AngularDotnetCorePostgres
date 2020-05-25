using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Models
{
    public class City
    {
        //By default Id is set to be primary key, auto generate
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public State State { get; set; }

        public int StateId { get; set; }

    }
}
