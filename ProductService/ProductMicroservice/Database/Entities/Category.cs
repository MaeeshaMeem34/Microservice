using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Database.Entities
{
    public class Category
    {
        public Guid categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
