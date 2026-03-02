using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Extensions
{
    public static class GeoLocationExtensions
    {

        public static double GetDistance(double originLatitude, 
            double originLongitude, 
            double destinationLatitude, 
            double destinationLongitude)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d;
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2); 
            return 12745.6 * Math.Asin(Math.Sqrt(havf(destinationLatitude - originLatitude) + 
                Math.Cos(rad(originLatitude)) * Math.Cos(rad(destinationLatitude)) 
                * havf(destinationLongitude - originLongitude))); 
        }
    }
}
