using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.ViewModels
{
    public class VMJQDT_SERVERSIDE_PARAMS
    {
        public VMJQDT_SERVERSIDE_PARAMS()
        {
            this.order = new List<VMJQDT_COLUMN_ORDER>();
            this.columns = new List<VMJQDT_COLUMN>();
        }

        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }

        public List<VMJQDT_COLUMN_ORDER> order { get; set; }
        public List<VMJQDT_COLUMN> columns { get; set; }
    }

    public enum JQDT_COLUMN_ORDER_DIRECTION
    {
        asc, desc
    }

    public class VMJQDT_COLUMN_ORDER
    {
        public int column { get; set; }
        public JQDT_COLUMN_ORDER_DIRECTION dir { get; set; }
    }

    public class VMJQDT_COLUMN
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool orderable { get; set; }
    }
}
