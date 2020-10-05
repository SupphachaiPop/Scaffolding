using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Data
{
    public interface IDBHelper
    {
        object CheckNull(string value);
        object CheckNull(object value);

        TABLETYPE_STRUCTURE ConvertToTableType_IntList(List<int> param);
        TABLETYPE_STRUCTURE ConvertToTableType_StringList(List<string> param);
        TABLETYPE_STRUCTURE ConvertToTableType_KeyValueList(IDictionary<string, object> param);
        //TABLETYPE_STRUCTURE ConvertToTableType_KeyValueRangeList(IDictionary<string, ValueTuple<object, object>> param);
    }
}
