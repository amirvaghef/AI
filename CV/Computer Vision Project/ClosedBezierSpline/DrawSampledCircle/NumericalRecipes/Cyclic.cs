using System;

namespace NumericalRecipes
{
	
	public static class Cyclic
	{
	    public static double[] Solve(double[] a, double[] b, double[] c, double alpha, double beta, double[] rhs)
		{
			// a, b, c and rhs vectors must have the same size.
			if (a.Length != b.Length || c.Length != b.Length || rhs.Length != b.Length)
				throw new ArgumentException("Diagonal and rhs vectors must have the same size.");
			int n = b.Length;
			if (n <= 2) 
				throw new ArgumentException("n too small in Cyclic; must be greater than 2.");

			double gamma = -b[0]; // Avoid subtraction error in forming bb[0].
			// Set up the diagonal of the modified tridiagonal system.
			double[] bb = new Double[n];
			bb[0] = b[0] - gamma;
			bb[n-1] = b[n - 1] - alpha * beta / gamma;
			for (int i = 1; i < n - 1; ++i)
				bb[i] = b[i];
			// Solve A · x = rhs.
			double[] solution = Tridiagonal.Solve(a, bb, c, rhs);
			double[] x = new Double[n];
			for (int k = 0; k < n; ++k)
				x[k] = solution[k];

			// Set up the vector u.
			double[] u = new Double[n];
			u[0] = gamma;
			u[n-1] = alpha;
			for (int i = 1; i < n - 1; ++i) 
				u[i] = 0.0;
			// Solve A · z = u.
			solution = Tridiagonal.Solve(a, bb, c, u);
			double[] z = new Double[n];
			for (int k = 0; k < n; ++k)
				z[k] = solution[k];

			// Form v · x/(1 + v · z).
			double fact = (x[0] + beta * x[n - 1] / gamma)
				/ (1.0 + z[0] + beta * z[n - 1] / gamma);

			// Now get the solution vector x.
			for (int i = 0; i < n; ++i) 
				x[i] -= fact * z[i];
			return x;
		} 
	}
}
        /*
        private void button1_Click(object sender, System.EventArgs e)
		{
			double[] a = new Double[4];
			double[] b = new Double[4];
    		double[] c = new Double[4];
			double[] r = new Double[4];
			double[] x = new Double[4];
			
			a[0] = 1.0;
			a[1] = 2.0;
			a[2] = 3.0;
			a[3] = 4.0;

			b[0] = 1.0;
			b[1] = 2.0;
			b[2] = 3.0;
			b[3] = 4.0;

			c[0] = 1.0;
			c[1] = 2.0;
			c[2] = 3.0;
			c[3] = 4.0;

			r[0] = 1.0;
			r[1] = 2.0;
			r[2] = 3.0;
			r[3] = 4.0;

			double alpha = 1.0;
			double beta = 1.0;
	
			
			
			NR.SolutionOfLinearAlgebraicEquations.Cyclic ob = 
				new NR.SolutionOfLinearAlgebraicEquations.Cyclic();
			
			ob.cyclic(a,b,c,alpha,beta,r,x,4);

			for(int i = 0; i < 4; i++)
        		textBox1.Text += Convert.ToString(x[i]) + "\r\n"; 
    	}  
		*/