
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // sale_order
    
    public class sale_order
    {
        public int sale_order_id { get; set; } // sale_order_id (Primary key)
        public string sale_order_no { get; set; } // sale_order_no (length: 100)
        public System.DateTime sale_order_date { get; set; } // sale_order_date
        public decimal sub_total { get; set; } // sub_total
        public decimal? discount { get; set; } // discount
        public decimal grand_total { get; set; } // grand_total
        public int customer_id { get; set; } // customer_id
        public string shipping_address { get; set; } // shipping_address (length: 500)
        public string billing_address { get; set; } // billing_address (length: 500)
        public int status { get; set; } // status
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Reverse navigation

        /// <summary>
        /// Child receipt_references where [receipt_reference].[sale_order_id] point to this entity (FK_receipt_reference_sale_order)
        /// </summary>
        public virtual ICollection<receipt_reference> receipt_references { get; set; } // receipt_reference.FK_receipt_reference_sale_order
        /// <summary>
        /// Child sale_order_items where [sale_order_item].[sale_order_id] point to this entity (FK_sale_order_item_sale_order)
        /// </summary>
        public virtual ICollection<sale_order_item> sale_order_items { get; set; } // sale_order_item.FK_sale_order_item_sale_order

        public sale_order()
        {
            receipt_references = new List<receipt_reference>();
            sale_order_items = new List<sale_order_item>();
        }
    }

}

