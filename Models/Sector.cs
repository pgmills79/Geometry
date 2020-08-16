using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Geometry.Models
{
    public class Sector
    {

        public string Results { get; set; }


        [JsonIgnore]
        public Dictionary<int, int> XCoords { get; set; }

        [JsonIgnore]
        public Dictionary<string, int> YCoords { get; set; }


        public Sector()
        {
            //initalize our sectors

            XCoords = new Dictionary<int, int>();
          
            //first x coordinates
            XCoords.Add(1, 0);
            XCoords.Add(2, 10);
            XCoords.Add(3, 10);
            XCoords.Add(4, 20);
            XCoords.Add(5, 20);
            XCoords.Add(6, 30);
            XCoords.Add(7, 30);
            XCoords.Add(8, 40);
            XCoords.Add(9, 40);
            XCoords.Add(10, 50);
            XCoords.Add(11, 50);
            XCoords.Add(12, 60);

            YCoords = new Dictionary<string, int>();

            //second y coordinates
            YCoords.Add("F1", 0);
            YCoords.Add("F2", 10);
            YCoords.Add("E1", 10);
            YCoords.Add("E2", 20);
            YCoords.Add("D1", 20);
            YCoords.Add("D2", 30);
            YCoords.Add("C1", 30);
            YCoords.Add("C2", 40);
            YCoords.Add("B1", 40);
            YCoords.Add("B2", 50);
            YCoords.Add("A1", 50);
            YCoords.Add("A2", 60);

        }


    }
}
