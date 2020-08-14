using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Services
{
    public class GeometryServices : IGeometryServices
    {


        public int GetXCordinates(string input) 
        {

            int _numberChosen = Convert.ToInt16(input.Substring(1, input.Length - 1));
            int _xCord = 0;

            //if this is divisible by 2 then its hypotenus on the bottom
            if (_numberChosen % 2 == 0)
            {
                _xCord = (_numberChosen / 2) * 10;  //10 pixels over to get to the point
                return _xCord;
            }


            //this is the reverse so we need to do some sort of mapping to get the x cordinates
            Dictionary<int, int> _xMapping = new Dictionary<int, int>();
            _xMapping.Add(1, 0);
            _xMapping.Add(3, 10);
            _xMapping.Add(5, 20);
            _xMapping.Add(7, 30);
            _xMapping.Add(9, 40);
            _xMapping.Add(11, 50);

            return _xMapping[_numberChosen];

           
        }

        public int GetYCordinates(string input)
        {

            Dictionary<string, int> _yMapping = new Dictionary<string, int>();
            _yMapping.Add("A", 60);
            _yMapping.Add("B", 50);
            _yMapping.Add("C", 40);
            _yMapping.Add("D", 30);
            _yMapping.Add("E", 20);
            _yMapping.Add("F", 10);

            int _numberChosen = Convert.ToInt16(input.Substring(1, input.Length - 1));
            string _letterChosen = input.Substring(0, 1);
            
            int _yCord = 0;

            //if this is divisible by 2 then its hypotenus on the bottom
            if (_numberChosen % 2 == 0)
            {
                _yCord = (Convert.ToInt16(_yMapping[_letterChosen]));

                return _yCord;
            }

            //this is the reverse right triangle then....
            

            return 0;
        }
    }
}
