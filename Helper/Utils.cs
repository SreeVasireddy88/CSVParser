using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvWebParser.Helper
{
    public static class Utils
    {
        public static double ConvertToDouble(Object input)
        {
            try
            {
                double value = Convert.ToDouble(input);
                value = value < 0 || value > 100 ? 0 : value;
                return value;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static decimal ConvertToDecimal(Object input)
        {
            try
            {
                decimal value = Convert.ToDecimal(input);
                value = value < 0 ? 0 : value;
                return value;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static string ConvertToString(Object input)
        {
            try
            {
                return Convert.ToString(input);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}