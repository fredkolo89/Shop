using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using _45.Db.Models;

namespace _45.Db
{
    public class Initializer : DropCreateDatabaseAlways<DataBase>
    {
        private Random _rand;

        protected override void Seed(DataBase context)
        {
            SeedData(context);
            base.Seed(context);
        }

        public void SeedData(DataBase context)
        {
            List<Data1> data1 = new List<Data1>()
            {
                new Data1() { pogoda = "slonecznie",temperatura = "niska",zachmurzenie = "wysokie",wiatr = "nie",rezultat = false},
                new Data1() { pogoda = "slonecznie",temperatura = "wysoka",zachmurzenie = "wysokie",wiatr = "tak",rezultat = false},
                new Data1() { pogoda = "pochmurnie",temperatura = "niska",zachmurzenie = "wysokie",wiatr = "nie",rezultat = true},
                new Data1() { pogoda = "slonecznie",temperatura = "wysoka",zachmurzenie = "wysokie",wiatr = "nie",rezultat = true},
                new Data1() { pogoda = "deszczowo",temperatura = "niska",zachmurzenie = "umiarkowane",wiatr = "nie",rezultat = true},
                new Data1() { pogoda = "deszczowo",temperatura = "niska",zachmurzenie = "umiarkowane",wiatr = "tak",rezultat = false},
                new Data1() { pogoda = "pochmurnie",temperatura = "niska",zachmurzenie = "umiarkowane",wiatr = "tak",rezultat = true},
                new Data1() { pogoda = "slonecznie",temperatura = "umiarkowana",zachmurzenie = "wysokie",wiatr = "nie",rezultat = false},
                new Data1() { pogoda = "slonecznie",temperatura = "niska",zachmurzenie = "umiarkowane",wiatr = "nie",rezultat = true},
               new Data1() { pogoda = "slonecznie",temperatura = "umiarkowana",zachmurzenie = "umiarkowane",wiatr = "nie",rezultat = true},
                new Data1() { pogoda = "slonecznie",temperatura = "umiarkowana",zachmurzenie = "umiarkowane",wiatr = "nie",rezultat = true},
                 new Data1() { pogoda = "pochmurnie",temperatura = "umiarkowana",zachmurzenie = "wysokie",wiatr = "tak",rezultat = true},
                new Data1() { pogoda = "pochmurnie",temperatura = "wysoka",zachmurzenie = "umiarkowane",wiatr = "nie",rezultat = true},
                new Data1() { pogoda = "slonecznie",temperatura = "umiarkowana",zachmurzenie = "wysokie",wiatr = "tak",rezultat = false},

            };

            data1.ForEach(r=>context.Data1.AddOrUpdate(r));

            //result.Rows.Add(new object[] { "slonecznie", "niska", "wysokie", "nie", false });
            //result.Rows.Add(new object[] { "slonecznie", "wysoka", "wysokie", "tak", false });
            //result.Rows.Add(new object[] { "pochmurnie", "niska", "wysokie", "nie", true });
            //result.Rows.Add(new object[] { "slonecznie", "wysoka", "wysokie", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "niska", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "niska", "umiarkowane", "tak", false });
            //result.Rows.Add(new object[] { "pochmurnie", "niska", "umiarkowane", "tak", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "wysokie", "nie", false });
            //result.Rows.Add(new object[] { "slonecznie", "niska", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "pochmurnie", "umiarkowana", "wysokie", "tak", true });
            //result.Rows.Add(new object[] { "pochmurnie", "wysoka", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "wysokie", "tak", false });




            context.SaveChanges();
        }


    }
}
