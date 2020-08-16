using System.Collections.Generic;

namespace Geometry.Services
{
    public interface IGeometryServices
    {      

        Dictionary<string, int> GetCoordsRightAngle(string input);
        Dictionary<string, int> GetCoordsHorizontalA(string input);
        Dictionary<string, int> GetCoordsVerticalB(string input);
        string GetTriangleSector(string input);

    }
}
