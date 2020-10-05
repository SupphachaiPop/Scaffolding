
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // cart
    
    public class cart
    {
        public int cart_id { get; set; } // cart_id (Primary key)
        public int customer_id { get; set; } // customer_id
        public int product_stock_id { get; set; } // product_stock_id
        public bool is_in_order { get; set; } // is_in_order
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Reverse navigation

        /// <summary>
        /// Child sale_order_items where [sale_order_item].[cart_id] point to this entity (FK_sale_order_item_cart)
        /// </summary>
        public virtual ICollection<sale_order_item> sale_order_items { get; set; } // sale_order_item.FK_sale_order_item_cart

        // Foreign keys

        /// <summary>
        /// Parent customer pointed by [cart].([customer_id]) (FK_cart_customer)
        /// </summary>
        public virtual customer customer { get; set; } // FK_cart_customer

        /// <summary>
        /// Parent product_stock pointed by [cart].([product_stock_id]) (FK_cart_product_stock)
        /// </summary>
        public virtual product_stock product_stock { get; set; } // FK_cart_product_stock

        public cart()
        {
            sale_order_items = new List<sale_order_item>();
        }
    }

}

