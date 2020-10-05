
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // province
    
    public class province
    {
        public int province_id { get; set; } // province_id (Primary key)
        public string name { get; set; } // name
        public string name_en { get; set; } // name_en

        // Reverse navigation

        /// <summary>
        /// Child addresses where [address].[province_id] point to this entity (FK_address_province)
        /// </summary>
        public virtual ICollection<address> addresses { get; set; } // address.FK_address_province
        /// <summary>
        /// Child districts where [district].[province_id] point to this entity (FK_District_province)
        /// </summary>
        public virtual ICollection<district> districts { get; set; } // district.FK_District_province

        public province()
        {
            addresses = new List<address>();
            districts = new List<district>();
        }
    }

}

