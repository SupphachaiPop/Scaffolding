
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // bank
    
    public class bank
    {
        public int bank_id { get; set; } // bank_id (Primary key)
        public string bank_name { get; set; } // bank_name (length: 200)
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Reverse navigation

        /// <summary>
        /// Child bank_accounts where [bank_account].[bank_id] point to this entity (FK_bank_account_bank)
        /// </summary>
        public virtual ICollection<bank_account> bank_accounts { get; set; } // bank_account.FK_bank_account_bank
        /// <summary>
        /// Child receipt_references where [receipt_reference].[source_bank_id] point to this entity (FK_receipt_reference_bank)
        /// </summary>
        public virtual ICollection<receipt_reference> receipt_references { get; set; } // receipt_reference.FK_receipt_reference_bank
        /// <summary>
        /// Child refund_references where [refund_reference].[cust_bank_id] point to this entity (FK_refund_reference_bank)
        /// </summary>
        public virtual ICollection<refund_reference> refund_references { get; set; } // refund_reference.FK_refund_reference_bank

        public bank()
        {
            bank_accounts = new List<bank_account>();
            receipt_references = new List<receipt_reference>();
            refund_references = new List<refund_reference>();
        }
    }

}

