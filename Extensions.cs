using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Geometry
{
    public static class Extensions
    {

        public static bool isCorrectXYInput(this string input ) 
        {

            string _pattern = @"^[A-F]([1-9]|10|11)$";
            string _query = input;
           
            List<Match> _matches = Regex.Matches(_query, _pattern).ToList();

            //return our value of if user input is correct
            return (_matches.Count() == 1);

         
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
