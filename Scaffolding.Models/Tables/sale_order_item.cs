
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // sale_order_item
    
    public class sale_order_item
    {
        public int sale_order_item_ { get; set; } // sale_order_item (Primary key)
        public int cart_id { get; set; } // cart_id
        public int sale_order_id { get; set; } // sale_order_id
        public int product_stock_id { get; set; } // product_stock_id
        public decimal price { get; set; } // price
        public int qty { get; set; } // qty
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Foreign keys

        /// <summary>
        /// Parent cart pointed by [sale_order_item].([cart_id]) (FK_sale_order_item_cart)
        /// </summary>
        public virtual cart cart { get; set; } // FK_sale_order_item_cart

        /// <summary>
        /// Parent product_stock pointed by [sale_order_item].([product_stock_id]) (FK_sale_order_item_product_stock)
        /// </summary>
        public virtual product_stock product_stock { get; set; } // FK_sale_order_item_product_stock

        /// <summary>
        /// Parent sale_order pointed by [sale_order_item].([sale_order_id]) (FK_sale_order_item_sale_order)
        /// </summary>
        public virtual sale_order sale_order { get; set; } // FK_sale_order_item_sale_order
    }

}

