using System;

namespace CNRInterpolation
{
	/// <summary>
	/// Descrizione di riepilogo per ControlPoint.
	/// </summary>
	public class ControlPoint
	{
		public int x;
		public int y;
		public int PT_SIZE = 4;

		public ControlPoint(int a, int b) 
		{
			x = a;
			y = b;
		}

		public bool within(int a, int b) 
		{
			if (a >= x - PT_SIZE && 
				b >= y - PT_SIZE &&
				a <= x + PT_SIZE && 
				b <= y + PT_SIZE)
				return true;
			else
				return false;
		}
		public ControlPoint()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
	}
}
