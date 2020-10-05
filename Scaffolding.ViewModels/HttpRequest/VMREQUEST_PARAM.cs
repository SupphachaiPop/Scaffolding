using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.ViewModels
{
    // Test Request param
    public class VMREQUEST_PARAM
    {
        public VMREQUEST_PARAM()
        {   // Default
            this.ID = 0;
            this.BOOL_PARAM = false;
            this.STRING_PARAM = string.Empty;
            this.DECIMAL_PARAM = 0;
            this.OBJ_PARAM = null;
        }

        public int ID { get; set; }
        public bool BOOL_PARAM { get; set; }
        public string STRING_PARAM { get; set; }
        public decimal DECIMAL_PARAM { get; set; }
        public object OBJ_PARAM { get; set; }
    }
}
