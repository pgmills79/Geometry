using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Geometry.Models
{
    public class Coordinates
    {
        [JsonIgnore]
        public int XCord { get; set; }
        [JsonIgnore]
        public int YCord { get; set; }
        public string Results { get; set; }
        public Dictionary<string, int> RightAngle { get; set; }        
        public Dictionary<string, int> HorizontalPointA { get; set; }
        public Dictionary<string, int> VerticalPointB { get; set; }

    }
}
