using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.ViewModels
{
    public class VMRESPONSE_STATUS
    {
        public VMRESPONSE_STATUS()
        {   // Default
            this.IS_SUCCESS = false;
            this.CODE = 0;
            this.MESSAGE = string.Empty;
            this.RESULT = null;
            this.OUTPUT_ID = 0;
        }

        public bool IS_SUCCESS { get; set; }
        public int CODE { get; set; }
        public int OUTPUT_ID { get; set; }
        public string MESSAGE { get; set; }
        public object RESULT { get; set; }
    }
}
