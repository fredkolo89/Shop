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

            var OutLookEntropy = playFootballs.GetEntropyAttribute(new Outlook(), playFootballs.ListOfPlayFootballs.
                 Select(a => new Attribute { Atr = a.Outlook.ToString(), Decision = a.Decision }).ToList());
            var temperatureEntropy = playFootballs.GetEntropyAttribute(new Temperature(), playFootballs.ListOfPlayFootballs.
                  Select(a => new Attribute { Atr = a.Temperature.ToString(), Decision = a.Decision }).ToList());

            var HumidityEntropy = playFootballs.GetEntropyAttribute(new Humidity(),  playFootballs.ListOfPlayFootballs.
             Select(a => new Attribute { Atr = a.Humidity.ToString(), Decision = a.Decision }).ToList());

            var WindyEntropy = playFootballs.GetEntropyAttribute(new Windy (), playFootballs.ListOfPlayFootballs.
                Select(a => new Attribute { Atr = a.Windy.ToString(), Decision = a.Decision }).ToList());


            Console.WriteLine(" ss");


        }


    }
}
