using _45.Db;
using _45.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45
{
    public class Helpers
    {

        public DataTable getDataTable(int number)
        {
            DataTable result = new DataTable("samples");
            DataBase database;

            using (database = new DataBase())
            {
                switch (number)
                {
                    case 0:
                        List<Data1> data1 = database.Data1.Select(s => s).ToList();
                        result = ToDataTable(data1);
                        break;
                    case 1:
                        List<Data2> data2 = database.Data2.Select(s => s).ToList();
                        result = ToDataTable(data2);
                        break;
                    case 2:
                        List<Data3> data3 = database.Data3.Select(s => s).ToList();
                        result = ToDataTable(data3);
                        break;
                    case 3:
                        List<Data4> data4 = database.Data4.Select(s => s).ToList();
                        result = ToDataTable(data4);
                        break;
                }

            }

            return result;

        }

        public List<Attribute> GetListOfAttribute(DataTable dt)
        {
            List<Attribute> list = new List<Attribute>();
            List<string> nameColumns = GetNameColumns(dt);
            for (int i = 1; i < nameColumns.Count - 1; i++)
            {
                list.Add(Attribute.GetAttribute(i, dt, nameColumns));
            }
            return list;
        }


        private DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

       


        private List<string> GetNameColumns(DataTable dt)
        {
            List<string> list = new List<string>();
            foreach (DataColumn column in dt.Columns)
            {
                list.Add(column.ColumnName);
            }
            return list;
        }
    }
}
