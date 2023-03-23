/****************************************************************************
 * Copyright 2011 Jean-Philippe Gravel, p. eng.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GravelInnovation.BezierSignature
{
    public class Graph
    {
        public static double Distance(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        public static Point Mean(params Point[] points)
        {
            int x = 0;
            int y = 0;
            foreach (Point p in points)
            {
                x += p.X;
                y += p.Y;
            }
            return new Point(x / points.Length, y / points.Length);
        }
    }
}
