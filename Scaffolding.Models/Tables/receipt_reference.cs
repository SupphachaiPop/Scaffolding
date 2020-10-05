
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // receipt_reference
    
    public class receipt_reference
    {
        public int receipt_id { get; set; } // receipt_id (Primary key)
        public string receipt_no { get; set; } // receipt_no (length: 100)
        public int sale_order_id { get; set; } // sale_order_id
        public int customer_id { get; set; } // customer_id
        public System.DateTime receipt_date { get; set; } // receipt_date
        public System.DateTime transfer_date { get; set; } // transfer_date
        public System.TimeSpan transfer_time { get; set; } // transfer_time
        public decimal transfer_amount { get; set; } // transfer_amount
        public int bank_account_id { get; set; } // bank_account_id
        public int source_bank_id { get; set; } // source_bank_id
        public string remark { get; set; } // remark (length: 300)
        public int admin_id { get; set; } // admin_id
        public int status { get; set; } // status
        public bool is_active { get; set; } // is_active
        public bool is_delete { get; set; } // is_delete
        public int create_by { get; set; } // create_by
        public System.DateTime create_date { get; set; } // create_date
        public int modify_by { get; set; } // modify_by
        public System.DateTime modify_date { get; set; } // modify_date

        // Foreign keys

        /// <summary>
        /// Parent bank pointed by [receipt_reference].([source_bank_id]) (FK_receipt_reference_bank)
        /// </summary>
        public virtual bank bank { get; set; } // FK_receipt_reference_bank

        /// <summary>
        /// Parent bank_account pointed by [receipt_reference].([bank_account_id]) (FK_receipt_reference_bank_account)
        /// </summary>
        public virtual bank_account bank_account { get; set; } // FK_receipt_reference_bank_account

        /// <summary>
        /// Parent sale_order pointed by [receipt_reference].([sale_order_id]) (FK_receipt_reference_sale_order)
        /// </summary>
        public virtual sale_order sale_order { get; set; } // FK_receipt_reference_sale_order
    }

}

