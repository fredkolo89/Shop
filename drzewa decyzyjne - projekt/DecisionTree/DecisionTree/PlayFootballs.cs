using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace DecisionTree
{
    public class PlayFootballs
    {
        public List<PlayFootball> ListOfPlayFootballs = new List<PlayFootball>
            {
                new PlayFootball{ Outlook = Outlook.Sunny, Temperature = Temperature.Hot, Humidity = Humidity.High ,Windy = Windy.Weak ,Decision = false},
                new PlayFootball{ Outlook = Outlook.Sunny, Temperature = Temperature.Hot, Humidity = Humidity.High ,Windy = Windy.Strong ,Decision = false},
                new PlayFootball{ Outlook = Outlook.Overcats, Temperature = Temperature.Hot, Humidity = Humidity.High ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Rainy, Temperature = Temperature.Mild, Humidity = Humidity.High ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Rainy, Temperature = Temperature.Cold, Humidity = Humidity.Normal ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Rainy, Temperature = Temperature.Cold, Humidity = Humidity.Normal ,Windy = Windy.Strong ,Decision = false},
                new PlayFootball{ Outlook = Outlook.Overcats, Temperature = Temperature.Cold, Humidity = Humidity.Normal ,Windy = Windy.Strong ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Sunny, Temperature = Temperature.Mild, Humidity = Humidity.High ,Windy = Windy.Weak ,Decision = false},
                new PlayFootball{ Outlook = Outlook.Sunny, Temperature = Temperature.Cold, Humidity = Humidity.Normal ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Rainy, Temperature = Temperature.Mild, Humidity = Humidity.Normal ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Sunny, Temperature = Temperature.Mild, Humidity = Humidity.Normal ,Windy = Windy.Strong ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Overcats, Temperature = Temperature.Mild, Humidity = Humidity.High ,Windy = Windy.Strong ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Overcats, Temperature = Temperature.Hot, Humidity = Humidity.Normal ,Windy = Windy.Weak ,Decision = true},
                new PlayFootball{ Outlook = Outlook.Rainy, Temperature = Temperature.Mild, Humidity = Humidity.High ,Windy = Windy.Strong ,Decision = false},

            };



        public double GetEntropyAttribute(Enum attribute, IEnumerable<Attribute> list)
        {
            double result = 0.0;
            foreach (var item in Enum.GetNames(attribute.GetType())){

                result += (double)list.Count(c => c.Atr == item)/list.Count()*(GetEntropy(list.Where(c => c.Atr == item).ToList()));
                }
            return result;
        }

        public double GetEntropy(IEnumerable<PlayFootball> list)
        {
          
            var result = -((double) getTrueDecision(list)/list.Count()*Math.Log((double) getTrueDecision(list)/list.Count(), 2))
                   -((double) getFalseDecision(list)/list.Count()*Math.Log((double) getFalseDecision(list)/list.Count(), 2));
            
            return result > 0 ? result : 0;
        }

        private int getTrueDecision(IEnumerable<PlayFootball> list)
        {
            return Enumerable.Where(list, c => c.Decision == true).Count();

        }
        private int getFalseDecision(IEnumerable<PlayFootball> list)
        {
            return Enumerable.Where(list, c => c.Decision == false).Count();

        }

        public double GetEntropy(IEnumerable<Attribute> list)
        {
            var result = -((double) getTrueDecision(list)/list.Count()*
                           Math.Log((double) getTrueDecision(list)/list.Count(), 2))
                         -
                         ((double) getFalseDecision(list)/list.Count()*
                          Math.Log((double) getFalseDecision(list)/list.Count(), 2));
            
            return result>0?result:0;
        }

        private int getTrueDecision(IEnumerable<Attribute> list)
        {
            return Enumerable.Where(list, c => c.Decision == true).Count();

        }
        private int getFalseDecision(IEnumerable<Attribute> list)
        {
            return Enumerable.Where(list, c => c.Decision == false).Count();

        }

        public double getBigEnthropy(double MainEntropy, List<double> list)
        {
            double result=0;

            foreach(var ent in list )
            {
                if (result < MainEntropy - ent)
                {
                    result = MainEntropy - ent;
                }
           }
             return result;
        }
    }
}