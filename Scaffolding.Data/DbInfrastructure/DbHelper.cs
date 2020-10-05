using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data.DbInfrastructure
{
    public class DbHelper : IDbHelper
    {
        public object CheckNull(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public object CheckNull(object value)
        {
            if (value != null)
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }
    }


    public interface IDbHelper
    {
        object CheckNull(string value);
        object CheckNull(object value);
    }
}
