
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // product_specification
    
    public class product_specification
    {
        public int product_specification_id { get; set; } // product_specification_id (Primary key)
        public int? sub_specification_id { get; set; } // sub_specification_id
        public int? product_id { get; set; } // product_id
        public string value { get; set; } // value
        public System.DateTime? create_date { get; set; } // create_date
        public int? create_by { get; set; } // create_by
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? modify_by { get; set; } // modify_by
        public bool? is_delete { get; set; } // is_delete

        // Foreign keys

        /// <summary>
        /// Parent product pointed by [product_specification].([product_id]) (FK_product_specification_product1)
        /// </summary>
        public virtual product product { get; set; } // FK_product_specification_product1

        /// <summary>
        /// Parent sub_specification pointed by [product_specification].([sub_specification_id]) (FK_product_specification_product)
        /// </summary>
        public virtual sub_specification sub_specification { get; set; } // FK_product_specification_product
    }

}

