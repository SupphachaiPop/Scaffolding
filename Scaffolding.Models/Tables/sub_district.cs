
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // sub_district
    
    public class sub_district
    {
        public int sub_district_id { get; set; } // sub_district_id (Primary key)
        public string name { get; set; } // name
        public string name_en { get; set; } // name_en
        public int district_id { get; set; } // district_id

        // Reverse navigation

        /// <summary>
        /// Child addresses where [address].[sub_district_id] point to this entity (FK_address_sub_district)
        /// </summary>
        public virtual ICollection<address> addresses { get; set; } // address.FK_address_sub_district

        // Foreign keys

        /// <summary>
        /// Parent district pointed by [sub_district].([district_id]) (FK_sub_district_sub_district)
        /// </summary>
        public virtual district district { get; set; } // FK_sub_district_sub_district

        public sub_district()
        {
            addresses = new List<address>();
        }
    }

}

