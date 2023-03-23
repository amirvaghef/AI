using System.ComponentModel;

namespace DrawSampledCircle
{
	/// <summary>
	/// Window1 DataView 
	/// </summary>
	public class Window1DataView : INotifyPropertyChanged
	{
		int pointCount = 10;
		/// <summary>
		/// Gets or sets the point count.
		/// </summary>
		public int PointCount
		{
			get { return pointCount; }
			set
			{
				if (pointCount != value)
				{
					pointCount = value;
					Notify("PointCount");
				}
			}
		}

		double radius = 100;
		/// <summary>
		/// Gets or sets the radius.
		/// </summary>
		public double Radius
		{
			get { return radius; }
			set
			{
				if (radius != value)
				{
					radius = value;
					Notify("Radius");
				}
			}
		}

		bool showControlPoints = true;
		/// <summary>
		/// Gets or sets a value indicating whether to show control points markers.
		/// </summary>
		/// <value><c>true</c> to show control points; otherwise, <c>false</c>.</value>
		public bool ShowControlPoints
		{
			get { return showControlPoints; }
			set
			{
				if (showControlPoints != value)
				{
					showControlPoints = value;
					Notify("ShowControlPoints");
				}
			}
		}

		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		void Notify(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanged Members
	}
}
