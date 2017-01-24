using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _45.Db;

namespace _45
{
    public class LoadAtributes
    {
        public static Attribute GetAttribute()
        {
            DataBase database;

            DataTable tb = ID3Sample.getDataTable();
            List<string> nameColumns = new List<string>();

            foreach (DataColumn column in tb.Columns)
            {
                nameColumns.Add(column.ColumnName);
            }
  
            nameColumns.ToArray();


            var tab = tb.AsEnumerable().Select(x => x[1].ToString()).Distinct().ToArray();

            Attribute attr = new Attribute(nameColumns[1].ToString(),tab);

            return attr;
        }
        
    }
}
