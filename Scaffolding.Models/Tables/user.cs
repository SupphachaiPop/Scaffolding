
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // users
    
    public class user
    {
        public int user_id { get; set; } // user_id (Primary key)
        public string email { get; set; } // email (length: 50)
        public string firstname { get; set; } // firstname (length: 50)
        public string lastname { get; set; } // lastname (length: 50)
        public string nickname { get; set; } // nickname (length: 50)
        public string password { get; set; } // password (length: 50)
        public string phone_number { get; set; } // phone_number (length: 50)
        public bool? is_active { get; set; } // is_active
        public System.DateTime? create_date { get; set; } // create_date
        public int? create_by { get; set; } // create_by
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? modify_by { get; set; } // modify_by
    }

}

