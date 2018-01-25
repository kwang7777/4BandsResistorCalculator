using ResistorCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResistorCalculator.Services
{
    public class IOhmResistorCalculatorService : IOhmResistorCalculatorInterface
    {
        public List<string> CalculateOhmValue(string firstBandColor, string secondBandColor, string thirdBandColor, string fourthBandColor)
        {

            List<string> results = new List<string>();
            double resultLower = 0;
            double resultUpper = 0;

            IDictionary<string, double> firstBand = new Dictionary<string, double>();
            firstBand.Add(new KeyValuePair<string, double>("BLACK", 0));
            firstBand.Add(new KeyValuePair<string, double>("BROWN", 1));
            firstBand.Add(new KeyValuePair<string, double>("RED", 2));
            firstBand.Add(new KeyValuePair<string, double>("ORANGE", 3));
            firstBand.Add(new KeyValuePair<string, double>("YELLOW", 4));
            firstBand.Add(new KeyValuePair<string, double>("GREEN", 5));
            firstBand.Add(new KeyValuePair<string, double>("BLUE", 6));
            firstBand.Add(new KeyValuePair<string, double>("VIOLET", 7));
            firstBand.Add(new KeyValuePair<string, double>("GRAY", 8));
            firstBand.Add(new KeyValuePair<string, double>("WHITE", 9));

            IDictionary<string, double> secondBand = new Dictionary<string, double>();
            secondBand.Add(new KeyValuePair<string, double>("BLACK", 0));
            secondBand.Add(new KeyValuePair<string, double>("BROWN", 1));
            secondBand.Add(new KeyValuePair<string, double>("RED", 2));
            secondBand.Add(new KeyValuePair<string, double>("ORANGE", 3));
            secondBand.Add(new KeyValuePair<string, double>("YELLOW", 4));
            secondBand.Add(new KeyValuePair<string, double>("GREEN", 5));
            secondBand.Add(new KeyValuePair<string, double>("BLUE", 6));
            secondBand.Add(new KeyValuePair<string, double>("VIOLET", 7));
            secondBand.Add(new KeyValuePair<string, double>("GRAY", 8));
            secondBand.Add(new KeyValuePair<string, double>("WHITE", 9));

            IDictionary<string, double> thirdBand = new Dictionary<string, double>();
            thirdBand.Add(new KeyValuePair<string, double>("BLACK", 0));
            thirdBand.Add(new KeyValuePair<string, double>("BROWN", 1));
            thirdBand.Add(new KeyValuePair<string, double>("RED", 2));
            thirdBand.Add(new KeyValuePair<string, double>("ORANGE", 3));
            thirdBand.Add(new KeyValuePair<string, double>("YELLOW", 4));
            thirdBand.Add(new KeyValuePair<string, double>("GREEN", 5));
            thirdBand.Add(new KeyValuePair<string, double>("BLUE", 6));
            thirdBand.Add(new KeyValuePair<string, double>("VIOLET", 7));
            thirdBand.Add(new KeyValuePair<string, double>("GRAY", 8));
            thirdBand.Add(new KeyValuePair<string, double>("WHITE", 9));
            thirdBand.Add(new KeyValuePair<string, double>("GOLD", -1));
            thirdBand.Add(new KeyValuePair<string, double>("SILVER", -2));

            IDictionary<string, double> fourthBand = new Dictionary<string, double>();
            fourthBand.Add(new KeyValuePair<string, double>("BROWN", 0.01));
            fourthBand.Add(new KeyValuePair<string, double>("RED", 0.02));
            fourthBand.Add(new KeyValuePair<string, double>("YELLOW", 0.05));
            fourthBand.Add(new KeyValuePair<string, double>("GREEN", 0.005));
            fourthBand.Add(new KeyValuePair<string, double>("BLUE", 0.0025));
            fourthBand.Add(new KeyValuePair<string, double>("VIOLET", 0.001));
            fourthBand.Add(new KeyValuePair<string, double>("GRAY", 0.0005));
            fourthBand.Add(new KeyValuePair<string, double>("GOLD", 0.05));
            fourthBand.Add(new KeyValuePair<string, double>("SILVER", 0.1));
            fourthBand.Add(new KeyValuePair<string, double>("NONE", 0.2));

            double value;
            if (!firstBand.TryGetValue(firstBandColor, out value)
                || !secondBand.TryGetValue(secondBandColor, out value)
                || !thirdBand.TryGetValue(thirdBandColor, out value))
            {
                resultLower = 0;
                resultUpper = 0;
            }
            else
            {
                if (fourthBand.TryGetValue(fourthBandColor, out value))
                {
                    resultLower = (firstBand[firstBandColor] * 10 + secondBand[secondBandColor]) * Math.Pow(10, thirdBand[thirdBandColor]) * (1 - fourthBand[fourthBandColor]);
                    resultUpper = (firstBand[firstBandColor] * 10 + secondBand[secondBandColor]) * Math.Pow(10, thirdBand[thirdBandColor]) * (1 + fourthBand[fourthBandColor]);
                }
                else
                {
                    resultLower = (firstBand[firstBandColor] * 10 + secondBand[secondBandColor]) * Math.Pow(10, thirdBand[thirdBandColor]);
                    resultUpper = (firstBand[firstBandColor] * 10 + secondBand[secondBandColor]) * Math.Pow(10, thirdBand[thirdBandColor]);
                }
            }

            results.Add(resultLower.ToString());
            results.Add(resultUpper.ToString());
            return results;
        }
    }
}