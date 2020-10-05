
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // refund_reference
    
    public class refund_reference
    {
        public int refund_id { get; set; } // refund_id (Primary key)
        public string refund_no { get; set; } // refund_no (length: 100)
        public int sale_order_id { get; set; } // sale_order_id
        public int receipt_id { get; set; } // receipt_id
        public int bank_account_id { get; set; } // bank_account_id
        public int customer_id { get; set; } // customer_id
        public int cust_bank_id { get; set; } // cust_bank_id
        public string cust_account_no { get; set; } // cust_account_no (length: 100)
        public System.DateTime payment_date { get; set; } // payment_date
        public decimal payment_amount { get; set; } // payment_amount
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
        /// Parent bank pointed by [refund_reference].([cust_bank_id]) (FK_refund_reference_bank)
        /// </summary>
        public virtual bank bank { get; set; } // FK_refund_reference_bank
    }

}

