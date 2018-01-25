using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResistorCalculator.Interfaces
{
    public interface IOhmResistorCalculatorInterface
    {
        /// <summary>

        /// Calculates the Ohm value of a resistor based on the band colors.

        /// </summary>

        /// <param name="bandAColor">The color of the first figure of component value band.</param>

        /// <param name="bandBColor">The color of the second significant figure band.</param>

        /// <param name="bandCColor">The color of the decimal multiplier band.</param>

        /// <param name="bandDColor">The color of the tolerance value band.</param>

        List<string> CalculateOhmValue(string firstBandColor, string secondBandColor, string thirdBandColor, string fourthBandColor);
    }
}