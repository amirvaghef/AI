using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawSampledCircle
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		/// <summary>
		/// This Window DataView.
		/// </summary>
		Window1DataView dataView = new Window1DataView();

		/// <summary>
		/// Initializes a new instance of the <see cref="Window1"/> class.
		/// </summary>
		public Window1()
		{
			InitializeComponent();

			dataView.PropertyChanged += dataView_PropertyChanged;
			DataContext = dataView;
		}

		/// <summary>
		/// Handles the Loaded event of the Window control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			draw();
		}

		/// <summary>
		/// Handles the PropertyChanged event of the dataView.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
		void dataView_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			draw();
		}

		/// <summary>
		/// Draws the circle.
		/// </summary>
		private void draw()
		{
			canvas.Children.Clear();

			Point[] points = new Point[dataView.PointCount];
			double angleStep = 2 * Math.PI / dataView.PointCount;
			for (int i = 0; i < dataView.PointCount; ++i)
			{
				double angle = i * angleStep;
				points[i] = new Point(dataView.Radius * (Math.Sin(angle) + 1)
					, dataView.Radius * (Math.Cos(angle) + 1));
			}

			const double markerSize = 5;
			// Draw Curve points (Black)
			for (int i = 0; i < points.Length; ++i)
			{
				Rectangle rect = new Rectangle()
				{
					Stroke = Brushes.Black,
					Fill = Brushes.Black,
					Height = markerSize,
					Width = markerSize
				};
				Canvas.SetLeft(rect, points[i].X - markerSize / 2);
				Canvas.SetTop(rect, points[i].Y - markerSize / 2);
				canvas.Children.Add(rect);
			}

			// Get Bezier Spline Control Points.
			Point[] cp1, cp2;
			ovp.ClosedBezierSpline.GetCurveControlPoints(points, out cp1, out cp2);

			// Draw curve by Bezier.
			PathSegmentCollection segments = new PathSegmentCollection();
			for (int i = 1; i < cp1.Length; ++i)
			{
				segments.Add(new BezierSegment(cp1[i - 1], cp2[i], points[i], true));
			}
			segments.Add(new BezierSegment(cp1[cp1.Length - 1], cp2[0], points[0], true));
			PathFigure f = new PathFigure(points[0], segments, false);
			PathGeometry g = new PathGeometry(new PathFigure[] { f });
			Path path = new Path() { Stroke = Brushes.Red, StrokeThickness = 1, Data = g };
			canvas.Children.Add(path);

			if (dataView.ShowControlPoints)
			{ // Draw Bezier control points markers
				for (int i = 0; i < cp1.Length; ++i)
				{
					// First control point (Blue)
					Ellipse marker = new Ellipse()
					{
						Stroke = Brushes.Blue,
						Fill = Brushes.Blue,
						Height = markerSize,
						Width = markerSize
					};
					Canvas.SetLeft(marker, cp1[i].X - markerSize / 2);
					Canvas.SetTop(marker, cp1[i].Y - markerSize / 2);
					canvas.Children.Add(marker);

					// Second control point (Green)
					marker = new Ellipse()
					{
						Stroke = Brushes.Green,
						Fill = Brushes.Green,
						Height = markerSize,
						Width = markerSize
					};
					Canvas.SetLeft(marker, cp2[i].X - markerSize / 2);
					Canvas.SetTop(marker, cp2[i].Y - markerSize / 2);
					canvas.Children.Add(marker);
				}
			}
		}
	}
}
