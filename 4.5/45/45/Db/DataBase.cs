using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _45.Db.Models;

namespace _45.Db
{
    public class DataBase :DbContext
    {
         public DataBase()
            : base("ConnectionString")
            {

            }

         static DataBase()
            {

                Database.SetInitializer<DataBase>(new Initializer());
            }

        public DbSet<Data1> Data1 { get; set; }
    }
}
