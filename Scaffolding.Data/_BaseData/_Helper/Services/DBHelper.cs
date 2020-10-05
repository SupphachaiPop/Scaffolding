using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Scaffolding.Data
{
    public class DBHelper : IDBHelper
    {
        public const string sqlDatetimeFormat = "yyyy-MM-dd HH:mm:ss";

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

        /// <summary>
        /// CREATE TYPE [dbo].[INT_LIST] AS TABLE(
        ///     [VALUE] [INT] NOT NULL
        /// )
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public TABLETYPE_STRUCTURE ConvertToTableType_IntList(List<int> param)
        {   // This function required: User-Defined Table Types
            // Table type name: INT_LIST
            // Table type column: [VALUE]
            // User with SqlDbType.Structured

            TABLETYPE_STRUCTURE result = new TABLETYPE_STRUCTURE();
            result.TYPE_NAME = "dbo.INT_LIST";
            result.VALUE.Columns.Add("VALUE", type: typeof(int));
            if (param != null && param.Count() > 0)
            {
                foreach (int p in param)
                {
                    DataRow r = result.VALUE.NewRow();
                    r["VALUE"] = p;
                    result.VALUE.Rows.Add(r);
                }
            }
            return result;
        }

        /// <summary>
        /// CREATE TYPE [dbo].[STRING_LIST] AS TABLE(
        ///     [VALUE] [VARCHAR] (100) NOT NULL
        /// )
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public TABLETYPE_STRUCTURE ConvertToTableType_StringList(List<string> param)
        {   // This function required: User-Defined Table Types
            // Table type name: STRING_LIST
            // Table type column: [VALUE]
            // User with SqlDbType.Structured
            TABLETYPE_STRUCTURE result = new TABLETYPE_STRUCTURE();
            result.TYPE_NAME = "dbo.STRING_LIST";
            result.VALUE.Columns.Add("VALUE", type: typeof(string));
            if (param != null && param.Count() > 0)
            {
                foreach (string p in param)
                {
                    DataRow r = result.VALUE.NewRow();
                    r["VALUE"] = p;
                    result.VALUE.Rows.Add(r);
                }
            }
            return result;
        }

        /// <summary>
        /// CREATE TYPE [dbo].[KEY_VALUE_LIST] AS TABLE(
        ///     [KEY] [VARCHAR] (100) NOT NULL,   
        ///     [VALUE] [VARCHAR] (100) NULL,
        ///     PRIMARY KEY CLUSTERED([KEY] ASC)
        /// )
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public TABLETYPE_STRUCTURE ConvertToTableType_KeyValueList(IDictionary<string, object> param)
        {   // This function required: User-Defined Table Types
            // Table type name: KEY_VALUE_LIST
            // Table type column: [KEY], [VALUE]
            // User with SqlDbType.Structured
            TABLETYPE_STRUCTURE result = new TABLETYPE_STRUCTURE();
            result.TYPE_NAME = "dbo.KEY_VALUE_LIST";
            result.VALUE.Columns.Add("KEY", type: typeof(string));
            result.VALUE.Columns.Add("VALUE", type: typeof(string));

            if (param != null && param.Count() > 0)
            {
                foreach (var p in param)
                {
                    DataRow r = result.VALUE.NewRow();
                    r["KEY"] = p.Key;

                    DateTime item1Datetime = DateTime.Now;
                    if (p.Value is DateTime)
                    {
                        r["VALUE"] = ((DateTime)p.Value).ToString(sqlDatetimeFormat);
                    }
                    else if (p.Value != null &&
                             p.Value is string &&
                             DateTime.TryParse(s: p.Value.ToString(), result: out item1Datetime))
                    {
                        r["VALUE"] = item1Datetime.ToString(sqlDatetimeFormat);
                    }
                    else
                    {
                        r["VALUE"] = p.Value?.ToString();
                    }


                    result.VALUE.Rows.Add(r);
                }
            }
            return result;
        }

        /// <summary>
        /// CREATE TYPE [dbo].[KEY_VALUE_RANGE_LIST] AS TABLE(
        ///     [KEY] [VARCHAR] (100) NOT NULL,   
        ///     [FROM_VALUE] [VARCHAR] (100) NULL,
        ///     [TO_VALUE] [VARCHAR] (100) NULL,
        ///     PRIMARY KEY CLUSTERED([KEY] ASC)
        /// )
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        //public TABLETYPE_STRUCTURE ConvertToTableType_KeyValueRangeList(IDictionary<string, ValueTuple<object, object>> param)
        //{   // This function required: User-Defined Table Types
        //    // Table type name: KEY_VALUE_LIST
        //    // Table type column: [KEY], [VALUE]
        //    // User with SqlDbType.Structured
        //    TABLETYPE_STRUCTURE result = new TABLETYPE_STRUCTURE();
        //    result.TYPE_NAME = "dbo.KEY_VALUE_RANGE_LIST";
        //    result.VALUE.Columns.Add("KEY", type: typeof(string));
        //    result.VALUE.Columns.Add("FROM_VALUE", type: typeof(string));
        //    result.VALUE.Columns.Add("TO_VALUE", type: typeof(string));

        //    if (param != null && param.Count() > 0)
        //    {
        //        foreach (var p in param)
        //        {
        //            DataRow r = result.VALUE.NewRow();
        //            r["KEY"] = p.Key;

        //            DateTime item1Datetime = DateTime.Now;
        //            if (p.Value.Item1 is DateTime)
        //            {
        //                r["FROM_VALUE"] = ((DateTime)p.Value.Item1).ToString(sqlDatetimeFormat);
        //            }
        //            else if (p.Value.Item1 != null &&
        //                     p.Value.Item1 is string && 
        //                     DateTime.TryParse(s: p.Value.Item1.ToString(), result: out item1Datetime))
        //            {
        //                r["FROM_VALUE"] = item1Datetime.ToString(sqlDatetimeFormat);
        //            }
        //            else
        //            {
        //                r["FROM_VALUE"] = p.Value.Item1?.ToString();
        //            }

        //            DateTime item2Datetime = DateTime.Now;
        //            if (p.Value.Item2 is DateTime)
        //            {
        //                r["TO_VALUE"] = ((DateTime)p.Value.Item2).ToString(sqlDatetimeFormat);
        //            }
        //            else if(p.Value.Item2 != null &&
        //                    p.Value.Item2 is string &&
        //                    DateTime.TryParse(s: p.Value.Item2.ToString(), result: out item2Datetime))
        //            {
        //                r["TO_VALUE"] = item2Datetime.ToString(sqlDatetimeFormat);
        //            }
        //            else
        //            {
        //                r["TO_VALUE"] = p.Value.Item2?.ToString();
        //            }

        //            result.VALUE.Rows.Add(r);
        //        }
        //    }
        //    return result;
        //}
    }

    public class TABLETYPE_STRUCTURE
    {
        public DataTable VALUE { get; set; }
        public string TYPE_NAME { get; set; }
        public SqlDbType DB_TYPE { get; set; }

        public TABLETYPE_STRUCTURE()
        {
            this.VALUE = new DataTable();
            this.TYPE_NAME = string.Empty;
            this.DB_TYPE = SqlDbType.Structured;
        }
    }
}
