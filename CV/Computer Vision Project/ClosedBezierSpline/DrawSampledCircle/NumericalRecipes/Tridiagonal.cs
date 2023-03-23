using System;

namespace NumericalRecipes
{
	/// <summary>
	/// Tridiagonal system solution.
	/// </summary>
	public static class Tridiagonal
	{
		/// <summary>
		/// Solves a tridiagonal system.
		/// </summary>
		/// <remarks>
		/// All vectors have size of n although some elements are not used.
		/// </remarks>
		/// <param name="a">Lower diagonal vector; a[0] not used.</param>
		/// <param name="b">Main diagonal vector.</param>
		/// <param name="c">Upper diagonal vector; c[n-1] not used.</param>
		/// <param name="rhs">Right hand side vector</param>
		/// <returns>system solution vector</returns>
		public static double[] Solve(double[] a, double[] b, double[] c, double[] rhs)
		{
			// a, b, c and rhs vectors must have the same size.
			if (a.Length != b.Length || c.Length != b.Length || rhs.Length != b.Length)
				throw new ArgumentException("Diagonal and rhs vectors must have the same size.");
			if (b[0] == 0.0)
				throw new InvalidOperationException("Singular matrix.");
            // If this happens then you should rewrite your equations as a set of 
			// order N - 1, with u2 trivially eliminated.

	        ulong n = Convert.ToUInt64(rhs.Length);
			double[] u = new Double[n];
            double[] gam = new Double[n]; // One vector of workspace, gam is needed.
			
			double bet = b[0];
			u[0] = rhs[0] / bet;
			for (ulong j = 1;j < n;j++) // Decomposition and forward substitution.
			{
			    gam[j] = c[j-1] / bet;
                bet = b[j] - a[j] * gam[j];
				if (bet == 0.0)  
					// Algorithm fails.
					throw new InvalidOperationException("Singular matrix.");
               u[j] = (rhs[j] - a[j] * u[j - 1]) / bet;
            }
            for (ulong j = 1;j < n;j++) 
				u[n - j - 1] -= gam[n - j] * u[n - j]; // Backsubstitution.

			return u;
		}
	}
}
