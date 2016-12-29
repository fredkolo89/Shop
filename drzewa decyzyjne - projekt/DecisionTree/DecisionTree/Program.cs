using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayFootballs playFootballs = new PlayFootballs();
            List<double> ListOfEntropy = new List<double>();

            var OutLookEntropy = playFootballs.GetEntropyAttribute(new Outlook(), playFootballs.ListOfPlayFootballs.
                 Select(a => new Attribute { Atr = a.Outlook.ToString(), Decision = a.Decision }).ToList());
            ListOfEntropy.Add(OutLookEntropy);

            var temperatureEntropy = playFootballs.GetEntropyAttribute(new Temperature(), playFootballs.ListOfPlayFootballs.
                  Select(a => new Attribute { Atr = a.Temperature.ToString(), Decision = a.Decision }).ToList());
            ListOfEntropy.Add(temperatureEntropy);

            var HumidityEntropy = playFootballs.GetEntropyAttribute(new Humidity(), playFootballs.ListOfPlayFootballs.
             Select(a => new Attribute { Atr = a.Humidity.ToString(), Decision = a.Decision }).ToList());
            ListOfEntropy.Add(HumidityEntropy);

            var WindyEntropy = playFootballs.GetEntropyAttribute(new Windy(), playFootballs.ListOfPlayFootballs.
                Select(a => new Attribute { Atr = a.Windy.ToString(), Decision = a.Decision }).ToList());
            ListOfEntropy.Add(WindyEntropy);

            var MainEntropy = playFootballs.GetEntropy(playFootballs.ListOfPlayFootballs);


            var bigEnthropy = playFootballs.getBigEnthropy(MainEntropy, ListOfEntropy);

                        
            Console.WriteLine(" ss");


        }


    }
}
