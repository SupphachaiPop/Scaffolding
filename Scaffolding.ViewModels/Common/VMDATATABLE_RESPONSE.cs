using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.ViewModels
{
    public class VMDATATABLE_RESPONSE<T>
    {   // Required field in lowerCase
        public VMDATATABLE_RESPONSE()
        {
            this.data = new List<T>();
        }

        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
    }
}
