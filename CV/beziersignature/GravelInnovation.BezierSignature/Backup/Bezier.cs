using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GravelInnovation.BezierSignature
{
    public static class Bezier
    {
        /// <summary>
        /// Return the points of flattened curve interpolated from the sampled 
        /// points received in parameter.
        /// </summary>
        /// <remarks>The method returns an array of Point to accomodate the
        /// Graphics.DrawLines method limitation in the .Net compact 
        /// framework. PointF doesn't exist in this library so no overload 
        /// could take a PointF array as parameter. If it was not of this 
        /// limitation, a PointF array would have been returned.</remarks>
        /// <param name="nbPoints">The number of points of the returned point 
        /// array</param>
        /// <param name="points">Points samples to be flattened.</param>
        /// <returns>A point array of nbPoints size. Contains the flattened 
        /// curve interpolated from the points received in parameter.
        /// </returns>
        public static Point[] Interpolate(int nbPoints, PointF[] points)
        {
            float step = 1.0f / (nbPoints - 1);
            Point[] retPoints = new Point[nbPoints];
            int i = 0;
            for (float t = 0; t < 1.0f; t += step)
            {
                PointF interpolatedPoint = InterpolatePoint(t, points)[0];
                retPoints[i] = new Point(
                    (int)Math.Round(interpolatedPoint.X), 
                    (int)Math.Round(interpolatedPoint.Y));
                i++;
            }

            PointF lastPoint = points[points.Length - 1];
            retPoints[retPoints.Length - 1] = new Point(
                (int)lastPoint.X, 
                (int)lastPoint.Y);

            return retPoints;
        }

        private static PointF[] InterpolatePoint(float t, params PointF[] points)
        {
            // There is only two points, return a simple linear interpolation.
            if (points.Length == 2)
                return new PointF[] {new PointF(
                    t * (points[1].X - points[0].X) + points[0].X, 
                    t * (points[1].Y - points[0].Y) + points[0].Y)};

            // For more than two points, recursively call the Interpolate 
            // method to reduce the number of points.
            PointF[] newPoints = new PointF[points.Length - 1];
            for (int i = 0; i < points.Length - 1; i++)
                newPoints[i] = InterpolatePoint(t, points[i], points[i + 1])[0];

            // This is where the recursion magic occurs
            return InterpolatePoint(t, newPoints);
        }
    }
}
