
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // brand
    
    public class brand
    {
        public int brand_id { get; set; } // brand_id (Primary key)
        public string brand_name { get; set; } // brand_name

        // Reverse navigation

        /// <summary>
        /// Child products where [product].[brand_id] point to this entity (FK_product_brand)
        /// </summary>
        public virtual ICollection<product> products { get; set; } // product.FK_product_brand

        public brand()
        {
            products = new List<product>();
        }
    }

}

