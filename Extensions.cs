using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static bool isCorrectVertexInput(this string input)
        {

            string _pattern = @"^([[\(|\[]([0-5]?[0-9]|60)[,]([0-5]?[0-9]|60)[\)|\]]){3}$";
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
       
    }
}
