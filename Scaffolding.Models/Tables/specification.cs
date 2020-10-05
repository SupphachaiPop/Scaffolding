
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // specification
    
    public class specification
    {
        public int specification_id { get; set; } // specification_id (Primary key)
        public string specification_name { get; set; } // specification_name
        public System.DateTime? create_date { get; set; } // create_date
        public int? create_by { get; set; } // create_by
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? modify_by { get; set; } // modify_by
        public bool? is_delete { get; set; } // is_delete

        // Reverse navigation

        /// <summary>
        /// Child sub_specifications where [sub_specification].[specification_id] point to this entity (FK_sub_specification_specification)
        /// </summary>
        public virtual ICollection<sub_specification> sub_specifications { get; set; } // sub_specification.FK_sub_specification_specification

        public specification()
        {
            sub_specifications = new List<sub_specification>();
        }
    }

}

