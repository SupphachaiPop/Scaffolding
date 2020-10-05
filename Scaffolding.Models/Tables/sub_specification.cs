
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // sub_specification
    
    public class sub_specification
    {
        public int sub_specification_id { get; set; } // sub_specification_id (Primary key)
        public int? specification_id { get; set; } // specification_id
        public string sub_specification_name { get; set; } // sub_specification_name
        public System.DateTime? create_date { get; set; } // create_date
        public int? create_by { get; set; } // create_by
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? modify_by { get; set; } // modify_by
        public bool? is_delete { get; set; } // is_delete

        // Reverse navigation

        /// <summary>
        /// Child category_specifications where [category_specification].[sub_specification_id] point to this entity (FK_category_specification_sub_specification)
        /// </summary>
        public virtual ICollection<category_specification> category_specifications { get; set; } // category_specification.FK_category_specification_sub_specification
        /// <summary>
        /// Child product_specifications where [product_specification].[sub_specification_id] point to this entity (FK_product_specification_product)
        /// </summary>
        public virtual ICollection<product_specification> product_specifications { get; set; } // product_specification.FK_product_specification_product

        // Foreign keys

        /// <summary>
        /// Parent specification pointed by [sub_specification].([specification_id]) (FK_sub_specification_specification)
        /// </summary>
        public virtual specification specification { get; set; } // FK_sub_specification_specification

        public sub_specification()
        {
            category_specifications = new List<category_specification>();
            product_specifications = new List<product_specification>();
        }
    }

}

