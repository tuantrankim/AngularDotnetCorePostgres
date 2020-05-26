using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryGroupId { get; set; }
        public string CategoryGroupName { get; set; }
    }
}
