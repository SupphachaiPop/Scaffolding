
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // product_image
    
    public class product_image
    {
        public int product_image_id { get; set; } // product_image_id (Primary key)
        public int? product_id { get; set; } // product_id
        public string url { get; set; } // url
        public bool? is_delete { get; set; } // is_delete

        // Foreign keys

        /// <summary>
        /// Parent product pointed by [product_image].([product_id]) (FK_product_image_product)
        /// </summary>
        public virtual product product { get; set; } // FK_product_image_product
    }

}

