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
    public struct PointF
    {
        private static PointF _Empty = new PointF(float.MinValue, float.MinValue);
        public static PointF Empty
        {
            get { return _Empty; }
        }

        public float X;
        public float Y;

        public PointF(Point p)
            : this(p.X, p.Y)
        {
        }

        public PointF(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is PointF))
                return false;

            PointF p = (PointF)obj;
            return this.X == p.X && this.Y == p.Y;
        }

        public override int GetHashCode()
        {
            return 0x34283a3e ^ this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}
