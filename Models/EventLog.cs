using System;
using System.ComponentModel.DataAnnotations;

namespace AngularDotnetCore.Models
{
    public class EventLog
    {
        //By default Id is set to be primary key, auto generate
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }
        public string EventType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
