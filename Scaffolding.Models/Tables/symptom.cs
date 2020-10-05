
using System.Collections.Generic;
namespace Scaffolding.Models
{

    // symptom
    
    public class symptom
    {
        public int symptom_id { get; set; } // symptom_id (Primary key)
        public string symptom_code { get; set; } // symptom_code (length: 50)
        public string symptom_name { get; set; } // symptom_name (length: 300)
        public string comment { get; set; } // comment (length: 500)
        public int created_by { get; set; } // created_by
        public System.DateTime created_date { get; set; } // created_date
        public int modified_by { get; set; } // modified_by
        public System.DateTime modified_date { get; set; } // modified_date
        public bool is_active { get; set; } // is_active
        public bool is_deleted { get; set; } // is_deleted

        // Reverse navigation

        /// <summary>
        /// Child product_stocks where [product_stock].[symptom_id] point to this entity (FK_product_stock_symptom)
        /// </summary>
        public virtual ICollection<product_stock> product_stocks { get; set; } // product_stock.FK_product_stock_symptom

        public symptom()
        {
            product_stocks = new List<product_stock>();
        }
    }

}

