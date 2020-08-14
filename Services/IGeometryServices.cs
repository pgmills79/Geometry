using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Services
{
    public interface IGeometryServices
    {

        int GetXCordinates(string input);

        int GetYCordinates(string input);
    }
}
