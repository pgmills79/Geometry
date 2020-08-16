using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Geometry
{
    public static class Extensions
    {

        public static bool isCorrectXYInput(this string input ) 
        {
            //no empy or null values allowed...
            if (string.IsNullOrEmpty(input))             
                return false;         

            //the length on this is incorrect, should be atleast 2 and no more than 3
            if (input.Length < 2 || input.Length > 3)
                return false;

            
            int n;

            //make sure first characeter is a letter
            if (int.TryParse(input.Substring(0, 1), out n))
                return false;

            //make sure everything after first character is not a number
            if (!int.TryParse(input.Substring(1, (input.Length - 1)), out n))
                return false;

            //cant go lower than 1 on the lower range
            if (Convert.ToInt16(input.Substring(1, (input.Length - 1))) < 1)
                return false;

            //cant go higher than 12 on upper range
            if (Convert.ToInt16(input.Substring(1, (input.Length - 1))) > 12)
                return false;

            //everything passed so we are good to go....
            return true;
        }

        public static bool isEvenNumber(this string input)
        {

            int _numberChosen = Convert.ToInt16(input[1..]);

            if (_numberChosen % 2 == 0)
                return true;

            //everything passed so we are good to go....
            return false;
        }

        public static bool isBottomTriangle(this string input)
        {            

            string _vector1 = input.Split('(', ')')[1];
            string _vector2 = input.Split('(', ')')[3];

            if (Convert.ToInt16(_vector2.Split(',')[1]) > Convert.ToInt16(_vector1.Split(',')[1]))
                return true;


            //this is NOT a bottom trianlge since it didnt bounce out above
            return false;
        
        }
    }
}
