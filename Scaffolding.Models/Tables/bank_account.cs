
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // bank_account
    
    public class bank_account
    {
        public int bank_account_id { get; set; } // bank_account_id (Primary key)
        public int bank_id { get; set; } // bank_id
        public string account_no { get; set; } // account_no (length: 100)
        public string account_name { get; set; } // account_name (length: 200)
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Reverse navigation

        /// <summary>
        /// Child receipt_references where [receipt_reference].[bank_account_id] point to this entity (FK_receipt_reference_bank_account)
        /// </summary>
        public virtual ICollection<receipt_reference> receipt_references { get; set; } // receipt_reference.FK_receipt_reference_bank_account

        // Foreign keys

        /// <summary>
        /// Parent bank pointed by [bank_account].([bank_id]) (FK_bank_account_bank)
        /// </summary>
        public virtual bank bank { get; set; } // FK_bank_account_bank

        public bank_account()
        {
            receipt_references = new List<receipt_reference>();
        }
    }

}

