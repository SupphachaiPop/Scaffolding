
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // promotion_image
    
    public class promotion_image
    {
        public int promotion_image_id { get; set; } // promotion_image_id (Primary key)
        public string image_file_name { get; set; } // image_file_name (length: 500)
        public string image_url { get; set; } // image_url (length: 500)
        public System.DateTime created_date { get; set; } // created_date
        public int created_by { get; set; } // created_by
        public System.DateTime? modified_date { get; set; } // modified_date
        public int? modified_by { get; set; } // modified_by
        public bool is_active { get; set; } // is_active
        public bool is_deleted { get; set; } // is_deleted
    }

}

