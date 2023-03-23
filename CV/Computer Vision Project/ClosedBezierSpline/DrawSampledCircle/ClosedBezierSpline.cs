using System.Windows;
using NumericalRecipes;

namespace ovp
{
	/// <summary>
	/// Closed Bezier Spline Control Points calculation.
	/// </summary>
	public static class ClosedBezierSpline
	{
		/// <summary>
		/// Get Closed Bezier Spline Control Points.
		/// </summary>
		/// <param name="knots">Input Knot Bezier spline points.</param>
		/// <param name="firstControlPoints">Output First Control points array of the same 
		/// length as the <paramref name="knots"/> array.</param>
		/// <param name="secondControlPoints">Output Second Control points array of of the same
		/// length as the <paramref name="knots"/> array.</param>
		public static void GetCurveControlPoints(Point[] knots, out Point[] firstControlPoints, out Point[] secondControlPoints)
		{
			int n = knots.Length;
			if (n <= 2)
			{
				firstControlPoints = new Point[0];
				secondControlPoints = new Point[0];
				return;
			}

			// Calculate first Bezier control points

			// The matrix.
			double[] a = new double[n], b = new double[n], c = new double[n];
			for (int i = 0; i < n; ++i)
			{
				a[i] = 1;
				b[i] = 4;
				c[i] = 1;
			}

			// Right hand side vector for points X coordinates.
			double[] rhs = new double[n];
			for (int i = 0; i < n; ++i)
			{
				int j = (i == n - 1) ? 0 : i + 1;
				rhs[i] = 4 * knots[i].X + 2 * knots[j].X;
			}
			// Solve the system for X.
			double[] x = Cyclic.Solve(a, b, c, 1, 1, rhs);

			// Right hand side vector for points Y coordinates.
			for (int i = 0; i < n; ++i)
			{
				int j = (i == n - 1) ? 0 : i + 1;
				rhs[i] = 4 * knots[i].Y + 2 * knots[j].Y;
			}
			// Solve the system for Y.
			double[] y = Cyclic.Solve(a, b, c, 1, 1, rhs);

			// Fill output arrays.
			firstControlPoints = new Point[n];
			secondControlPoints = new Point[n];
			for (int i = 0; i < n; ++i)
			{
				// First control point.
				firstControlPoints[i] = new Point(x[i], y[i]);
				// Second control point.
				secondControlPoints[i] = new Point(2 * knots[i].X - x[i], 2 * knots[i].Y - y[i]);
			}
		}
	}
}
