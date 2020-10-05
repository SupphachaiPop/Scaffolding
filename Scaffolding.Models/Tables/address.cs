
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // address
    
    public class address
    {
        public int address_id { get; set; } // address_id (Primary key)
        public string address_ { get; set; } // address
        public int? customer_id { get; set; } // customer_id
        public int? province_id { get; set; } // province_id
        public int? district_id { get; set; } // district_id
        public int? sub_district_id { get; set; } // sub_district_id
        public string postalcode { get; set; } // postalcode (length: 10)

        // Foreign keys

        /// <summary>
        /// Parent customer pointed by [address].([customer_id]) (FK_address_address)
        /// </summary>
        public virtual customer customer { get; set; } // FK_address_address

        /// <summary>
        /// Parent district pointed by [address].([district_id]) (FK_address_District)
        /// </summary>
        public virtual district district { get; set; } // FK_address_District

        /// <summary>
        /// Parent province pointed by [address].([province_id]) (FK_address_province)
        /// </summary>
        public virtual province province { get; set; } // FK_address_province

        /// <summary>
        /// Parent sub_district pointed by [address].([sub_district_id]) (FK_address_sub_district)
        /// </summary>
        public virtual sub_district sub_district { get; set; } // FK_address_sub_district
    }

}

