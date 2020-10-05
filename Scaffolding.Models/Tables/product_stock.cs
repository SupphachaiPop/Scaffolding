
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // product_stock
    
    public class product_stock
    {
        public int product_stock_id { get; set; } // product_stock_id (Primary key)
        public int product_id { get; set; } // product_id
        public int? symptom_id { get; set; } // symptom_id
        public string serial { get; set; } // serial (length: 100)
        public string imei1 { get; set; } // imei1 (length: 100)
        public string imei2 { get; set; } // imei2 (length: 100)
        public string cosmetic { get; set; } // cosmetic (length: 300)
        public string accessory { get; set; } // accessory (length: 100)
        public string grade { get; set; } // grade (length: 20)
        public decimal? cost_of_purchase { get; set; } // cost_of_purchase
        public decimal? cost_of_repairs { get; set; } // cost_of_repairs
        public decimal? min_price { get; set; } // min_price
        public decimal? sale_price { get; set; } // sale_price
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int? create_by { get; set; } // create_by
        public System.DateTime? create_date { get; set; } // create_date
        public int? modify_by { get; set; } // modify_by
        public System.DateTime? modify_date { get; set; } // modify_date

        // Reverse navigation

        /// <summary>
        /// Child carts where [cart].[product_stock_id] point to this entity (FK_cart_product_stock)
        /// </summary>
        public virtual ICollection<cart> carts { get; set; } // cart.FK_cart_product_stock
        /// <summary>
        /// Child product_stock_images where [product_stock_image].[product_stock_id] point to this entity (FK_product_stock_image_product_stock)
        /// </summary>
        public virtual ICollection<product_stock_image> product_stock_images { get; set; } // product_stock_image.FK_product_stock_image_product_stock
        /// <summary>
        /// Child sale_order_items where [sale_order_item].[product_stock_id] point to this entity (FK_sale_order_item_product_stock)
        /// </summary>
        public virtual ICollection<sale_order_item> sale_order_items { get; set; } // sale_order_item.FK_sale_order_item_product_stock

        // Foreign keys

        /// <summary>
        /// Parent product pointed by [product_stock].([product_id]) (FK_product_stock_product)
        /// </summary>
        public virtual product product { get; set; } // FK_product_stock_product

        /// <summary>
        /// Parent symptom pointed by [product_stock].([symptom_id]) (FK_product_stock_symptom)
        /// </summary>
        public virtual symptom symptom { get; set; } // FK_product_stock_symptom

        public product_stock()
        {
            carts = new List<cart>();
            product_stock_images = new List<product_stock_image>();
            sale_order_items = new List<sale_order_item>();
        }
    }

}

