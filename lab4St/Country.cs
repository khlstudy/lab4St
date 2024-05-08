using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4St
{
    internal class Country
    {
        public string CountryName;
        public string Continent;
        public string CapitalCity;
        public double Population;
        public double Area;
        public double LifeExpectancy;
        public bool IsInEU;
        public bool IsInNATO;

        public double CalculatePopulationDensity()
        {
            return Population / Area;
        }
        public bool IsPopulationDensityAboveAverage()
        {
            double averagePopulationDensity = 40; // середня густота населення Землі
            return CalculatePopulationDensity() > averagePopulationDensity;
        }
    }

}
