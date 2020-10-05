
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // customer
    
    public class customer
    {
        public int customer_id { get; set; } // customer_id (Primary key)
        public string salutation { get; set; } // salutation (length: 10)
        public string firstname { get; set; } // firstname
        public string lastname { get; set; } // lastname
        public string gender { get; set; } // gender (length: 10)
        public System.DateTime? dateofbirth { get; set; } // dateofbirth
        public int? shipping_address_id { get; set; } // shipping_address_id
        public int? billing_address_id { get; set; } // billing_address_id
        public string phone { get; set; } // phone (length: 10)
        public string email { get; set; } // email (length: 50)
        public string picture { get; set; } // picture
        public string tax_id_number { get; set; } // tax_id_number (length: 30)
        public string password { get; set; } // password (length: 100)
        public bool? is_active { get; set; } // is_active
        public bool? is_delete { get; set; } // is_delete
        public System.DateTime? create_date { get; set; } // create_date
        public System.DateTime? modify_date { get; set; } // modify_date
        public int? type { get; set; } // type
        public bool? is_person { get; set; } // is_person

        // Reverse navigation

        /// <summary>
        /// Child addresses where [address].[customer_id] point to this entity (FK_address_address)
        /// </summary>
        public virtual ICollection<address> addresses { get; set; } // address.FK_address_address
        /// <summary>
        /// Child carts where [cart].[customer_id] point to this entity (FK_cart_customer)
        /// </summary>
        public virtual ICollection<cart> carts { get; set; } // cart.FK_cart_customer

        public customer()
        {
            addresses = new List<address>();
            carts = new List<cart>();
        }
    }

}

