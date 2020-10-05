
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // category_specification
    
    public class category_specification
    {
        public int category_specification_id { get; set; } // category_specification_id (Primary key)
        public int? category_id { get; set; } // category_id
        public int? sub_specification_id { get; set; } // sub_specification_id

        // Foreign keys

        /// <summary>
        /// Parent category pointed by [category_specification].([category_id]) (FK_category_specification_category_specification)
        /// </summary>
        public virtual category category { get; set; } // FK_category_specification_category_specification

        /// <summary>
        /// Parent sub_specification pointed by [category_specification].([sub_specification_id]) (FK_category_specification_sub_specification)
        /// </summary>
        public virtual sub_specification sub_specification { get; set; } // FK_category_specification_sub_specification
    }

}

