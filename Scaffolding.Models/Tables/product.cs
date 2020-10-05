
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // product
    
    public class product
    {
        public int product_id { get; set; } // product_id (Primary key)
        public string sku { get; set; } // sku (length: 50)
        public string product_name { get; set; } // product_name
        public string overview { get; set; } // overview
        public string description { get; set; } // description
        public decimal? cost { get; set; } // cost
        public decimal? retail_price { get; set; } // retail_price
        public decimal? web_price { get; set; } // web_price
        public int? feature_picture { get; set; } // feature_picture
        public int? brand_id { get; set; } // brand_id
        public int? category_id { get; set; } // category_id
        public System.DateTime? create_date { get; set; } // create_date
        public int? create_by { get; set; } // create_by
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? modify_by { get; set; } // modify_by
        public bool? is_active { get; set; } // is_active
        public bool? is_delete { get; set; } // is_delete

        // Reverse navigation

        /// <summary>
        /// Child product_images where [product_image].[product_id] point to this entity (FK_product_image_product)
        /// </summary>
        public virtual ICollection<product_image> product_images { get; set; } // product_image.FK_product_image_product
        /// <summary>
        /// Child product_specifications where [product_specification].[product_id] point to this entity (FK_product_specification_product1)
        /// </summary>
        public virtual ICollection<product_specification> product_specifications { get; set; } // product_specification.FK_product_specification_product1
        /// <summary>
        /// Child product_stocks where [product_stock].[product_id] point to this entity (FK_product_stock_product)
        /// </summary>
        public virtual ICollection<product_stock> product_stocks { get; set; } // product_stock.FK_product_stock_product

        // Foreign keys

        /// <summary>
        /// Parent brand pointed by [product].([brand_id]) (FK_product_brand)
        /// </summary>
        public virtual brand brand { get; set; } // FK_product_brand

        /// <summary>
        /// Parent category pointed by [product].([category_id]) (FK_product_category)
        /// </summary>
        public virtual category category { get; set; } // FK_product_category

        public product()
        {
            product_images = new List<product_image>();
            product_specifications = new List<product_specification>();
            product_stocks = new List<product_stock>();
        }
    }

}

