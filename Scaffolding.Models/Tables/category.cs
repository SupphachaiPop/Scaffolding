
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // category
    
    public class category
    {
        public int category_id { get; set; } // category_id (Primary key)
        public string category_name { get; set; } // category_name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child category_specifications where [category_specification].[category_id] point to this entity (FK_category_specification_category_specification)
        /// </summary>
        public virtual ICollection<category_specification> category_specifications { get; set; } // category_specification.FK_category_specification_category_specification
        /// <summary>
        /// Child products where [product].[category_id] point to this entity (FK_product_category)
        /// </summary>
        public virtual ICollection<product> products { get; set; } // product.FK_product_category

        public category()
        {
            category_specifications = new List<category_specification>();
            products = new List<product>();
        }
    }

}

