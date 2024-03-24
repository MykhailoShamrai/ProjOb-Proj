using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal static class MathFunctions
    {
        /// <summary>
        /// Method for finding value of function in point x using linear interpolation method.
        /// </summary>
        /// <param name="x0">Left bound of the interval</param>
        /// <param name="x1">Right bound of the interval</param>
        /// <param name="y0">Known value of a function in a x0 point</param>
        /// <param name="y1">Known value of a function in a x1 point</param>
        /// <param name="x">A point where value of a function is required</param>
        /// <returns></returns>
        static public double LinearInterpolation (double x0, double x1, double y0, double y1, double x)
        {
            return (y0 * (x1 - x) + y1 * (x - x0)) / (x1 - x0);
        }
    }
}
