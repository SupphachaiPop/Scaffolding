
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // product_stock_image
    
    public class product_stock_image
    {
        public int product_stock_image_id { get; set; } // product_stock_image_id (Primary key)
        public int product_stock_id { get; set; } // product_stock_id
        public int order_image { get; set; } // order_image
        public string image_url { get; set; } // image_url (length: 100)
        public bool is_delete { get; set; } // is_delete
        public bool is_active { get; set; } // is_active
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int? modify_by { get; set; } // modify_by
        public System.DateTime? modify_date { get; set; } // modify_date

        // Foreign keys

        /// <summary>
        /// Parent product_stock pointed by [product_stock_image].([product_stock_id]) (FK_product_stock_image_product_stock)
        /// </summary>
        public virtual product_stock product_stock { get; set; } // FK_product_stock_image_product_stock
    }

}

