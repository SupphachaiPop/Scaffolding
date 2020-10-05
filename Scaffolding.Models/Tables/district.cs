
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // district
    
    public class district
    {
        public int district_id { get; set; } // district_id (Primary key)
        public string name { get; set; } // name
        public string name_en { get; set; } // name_en
        public int? province_id { get; set; } // province_id

        // Reverse navigation

        /// <summary>
        /// Child addresses where [address].[district_id] point to this entity (FK_address_District)
        /// </summary>
        public virtual ICollection<address> addresses { get; set; } // address.FK_address_District
        /// <summary>
        /// Child sub_districts where [sub_district].[district_id] point to this entity (FK_sub_district_sub_district)
        /// </summary>
        public virtual ICollection<sub_district> sub_districts { get; set; } // sub_district.FK_sub_district_sub_district

        // Foreign keys

        /// <summary>
        /// Parent province pointed by [district].([province_id]) (FK_District_province)
        /// </summary>
        public virtual province province { get; set; } // FK_District_province

        public district()
        {
            addresses = new List<address>();
            sub_districts = new List<sub_district>();
        }
    }

}

