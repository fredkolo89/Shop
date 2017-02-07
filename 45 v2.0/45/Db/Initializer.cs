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
            data1.ForEach(r => context.Data1.AddOrUpdate(r));

            List<Data2> data2 = new List<Data2>()
            {
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "brak",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "mezczyzna",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "brak_doswiadczenia",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = false},
                new Data2() { studia = "1_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
                new Data2() { studia = "1_stopień",doswiadczenie = "wysokie_doswiadczenie",znajomoscAngielskiego = "nie",plec = "kobieta",rezultat = true},
                new Data2() { studia = "2_stopień",doswiadczenie = "srednie_doswiadczenie",znajomoscAngielskiego = "tak",plec = "mezczyzna",rezultat = true},
            };
            data2.ForEach(r => context.Data2.AddOrUpdate(r));


            List<Data3> data3 = new List<Data3>()
            {
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "duza",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "duza",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "duza",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "duza",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "duza",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "duza",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "duza",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "duza",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "duze",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = false},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "mala",wielkosc_ubostwa = "srednie",stan_zdrowotny = "dobry",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "duze",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "srednie",wielkosc_rodziny = "duza",wielkosc_ubostwa = "srednie",stan_zdrowotny = "zly",rezultat = true},
                new Data3() { bezrobocie = "male",wielkosc_rodziny = "srednia",wielkosc_ubostwa = "male",stan_zdrowotny = "dobry",rezultat = false},


            };
            data3.ForEach(r => context.Data3.AddOrUpdate(r));

            List<Data4> data4 = new List<Data4>()
            {

                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "ospa", samopoczucie = "zle", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "ospa", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "dobre", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "srednie", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "srednie", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "swinka", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "ospa", samopoczucie = "srednie", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "srednia", samopoczucie = "male", goraczka = "tak", rezultat = false },
                          new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "ospa", samopoczucie = "zle", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "ospa", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "dobry", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "rozyczka", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "dobre", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "rozyczka", samopoczucie = "srednie", goraczka = "tak", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "srednie", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "swinka", samopoczucie = "srednie", goraczka = "nie", rezultat = false },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "swinka", samopoczucie = "dobre", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "sredni", choroba_na_oddziale = "ospa", samopoczucie = "srednie", goraczka = "nie", rezultat = true },
                new Data4() { stan_ogolny = "zly", choroba_na_oddziale = "srednia", samopoczucie = "male", goraczka = "tak", rezultat = false },
            
            
            };
            data4.ForEach(r => context.Data4.AddOrUpdate(r));
            context.SaveChanges();
        }


    }
}
