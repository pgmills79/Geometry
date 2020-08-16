using System.Collections.Generic;

namespace Geometry.Services
{
    public interface IGeometryServices
    {      

        Dictionary<string, int> GetCoordsRightAngle(string userInput);
        Dictionary<string, int> GetCoordsHorizontalA(string userInput);
        Dictionary<string, int> GetCoordsVerticalB(string userInput);
        string GetTriangleSector(string userInput);

    }
}
