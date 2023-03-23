using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CNRInterpolation
{
	/// <summary>
	
	/// </summary>
	public class InterpolationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton radioAdd;
		private System.Windows.Forms.RadioButton radioMove;
		private System.Windows.Forms.RadioButton radioDelete;
		private System.Windows.Forms.GroupBox groupBoxActions;
		private System.Windows.Forms.GroupBox groupBoxInterpolationMode;
		private System.Windows.Forms.RadioButton radioButtonSpline;
		private System.Windows.Forms.RadioButton radioButtonPolynomial;
		/// <summary>
	
		/// </summary>
		private System.ComponentModel.Container components = null;

		public enum InterpolationMode 
		{
			POLY = 0,
			NAT_SPL = 1,
			NAK_SPL = 2
		}
		public enum Actions 
		{
			ADD = 0,
			MOVE = 1,
			DELETE = 2
		}
		public enum MouseEvents 
		{
			MOUSE_DOWN = 0,
			MOUSE_UP,
			MOUSE_DRAG,
			WINDOW_DESTROY
		}
		private int moving_point;
		private int precision = 10;
		
		private ArrayList points = new ArrayList();

		private InterpolationMode mode = InterpolationMode.POLY;
		private System.Windows.Forms.Button buttonClear;
		private Actions action = Actions.ADD;
		private System.Windows.Forms.CheckBox checkBoxShowCoords;
		private System.Windows.Forms.Panel graphPanel;

		public InterpolationForm()
		{
			InitializeComponent();
		}

		/// <summary>
		
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Codice generato da Progettazione Windows Form
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxActions = new System.Windows.Forms.GroupBox();
			this.radioDelete = new System.Windows.Forms.RadioButton();
			this.radioMove = new System.Windows.Forms.RadioButton();
			this.radioAdd = new System.Windows.Forms.RadioButton();
			this.graphPanel = new System.Windows.Forms.Panel();
			this.groupBoxInterpolationMode = new System.Windows.Forms.GroupBox();
			this.radioButtonSpline = new System.Windows.Forms.RadioButton();
			this.radioButtonPolynomial = new System.Windows.Forms.RadioButton();
			this.buttonClear = new System.Windows.Forms.Button();
			this.checkBoxShowCoords = new System.Windows.Forms.CheckBox();
			this.groupBoxActions.SuspendLayout();
			this.groupBoxInterpolationMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxActions
			// 
			this.groupBoxActions.Controls.Add(this.radioDelete);
			this.groupBoxActions.Controls.Add(this.radioMove);
			this.groupBoxActions.Controls.Add(this.radioAdd);
			this.groupBoxActions.Location = new System.Drawing.Point(184, 296);
			this.groupBoxActions.Name = "groupBoxActions";
			this.groupBoxActions.Size = new System.Drawing.Size(320, 56);
			this.groupBoxActions.TabIndex = 0;
			this.groupBoxActions.TabStop = false;
			this.groupBoxActions.Text = "Actions";
			this.groupBoxActions.Validated += new System.EventHandler(this.groupBoxActions_Validated);
			// 
			// radioDelete
			// 
			this.radioDelete.Location = new System.Drawing.Point(208, 24);
			this.radioDelete.Name = "radioDelete";
			this.radioDelete.TabIndex = 2;
			this.radioDelete.Text = "Delete point";
			this.radioDelete.Click += new System.EventHandler(this.radioDelete_Click);
			// 
			// radioMove
			// 
			this.radioMove.Location = new System.Drawing.Point(112, 24);
			this.radioMove.Name = "radioMove";
			this.radioMove.TabIndex = 1;
			this.radioMove.Text = "Move point";
			this.radioMove.Click += new System.EventHandler(this.radioMove_Click);
			// 
			// radioAdd
			// 
			this.radioAdd.Checked = true;
			this.radioAdd.Location = new System.Drawing.Point(16, 24);
			this.radioAdd.Name = "radioAdd";
			this.radioAdd.TabIndex = 0;
			this.radioAdd.TabStop = true;
			this.radioAdd.Text = "Add point";
			this.radioAdd.Click += new System.EventHandler(this.radioAdd_Click);
			this.radioAdd.CheckedChanged += new System.EventHandler(this.radioAdd_CheckedChanged);
			// 
			// graphPanel
			// 
			this.graphPanel.BackColor = System.Drawing.SystemColors.Window;
			this.graphPanel.Location = new System.Drawing.Point(16, 56);
			this.graphPanel.Name = "graphPanel";
			this.graphPanel.Size = new System.Drawing.Size(504, 232);
			this.graphPanel.TabIndex = 2;
			this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseUp);
			this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
			this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseMove);
			this.graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseDown);
			// 
			// groupBoxInterpolationMode
			// 
			this.groupBoxInterpolationMode.Controls.Add(this.radioButtonSpline);
			this.groupBoxInterpolationMode.Controls.Add(this.radioButtonPolynomial);
			this.groupBoxInterpolationMode.Location = new System.Drawing.Point(80, 8);
			this.groupBoxInterpolationMode.Name = "groupBoxInterpolationMode";
			this.groupBoxInterpolationMode.Size = new System.Drawing.Size(320, 40);
			this.groupBoxInterpolationMode.TabIndex = 3;
			this.groupBoxInterpolationMode.TabStop = false;
			this.groupBoxInterpolationMode.Text = "Interpolation";
			// 
			// radioButtonSpline
			// 
			this.radioButtonSpline.Location = new System.Drawing.Point(168, 12);
			this.radioButtonSpline.Name = "radioButtonSpline";
			this.radioButtonSpline.TabIndex = 1;
			this.radioButtonSpline.Text = "Cubic Spline";
			this.radioButtonSpline.Click += new System.EventHandler(this.radioButtonSpline_Click);
			// 
			// radioButtonPolynomial
			// 
			this.radioButtonPolynomial.Checked = true;
			this.radioButtonPolynomial.Location = new System.Drawing.Point(48, 12);
			this.radioButtonPolynomial.Name = "radioButtonPolynomial";
			this.radioButtonPolynomial.TabIndex = 0;
			this.radioButtonPolynomial.TabStop = true;
			this.radioButtonPolynomial.Text = "Polinomial";
			this.radioButtonPolynomial.Click += new System.EventHandler(this.radioButtonPolynomial_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(16, 320);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(104, 23);
			this.buttonClear.TabIndex = 1;
			this.buttonClear.Text = "Clear points";
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// checkBoxShowCoords
			// 
			this.checkBoxShowCoords.Checked = true;
			this.checkBoxShowCoords.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxShowCoords.Location = new System.Drawing.Point(408, 8);
			this.checkBoxShowCoords.Name = "checkBoxShowCoords";
			this.checkBoxShowCoords.Size = new System.Drawing.Size(104, 32);
			this.checkBoxShowCoords.TabIndex = 4;
			this.checkBoxShowCoords.Text = "Show Coordinates";
			this.checkBoxShowCoords.CheckedChanged += new System.EventHandler(this.checkBoxShowCoords_CheckedChanged);
			// 
			// InterpolationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 366);
			this.Controls.Add(this.checkBoxShowCoords);
			this.Controls.Add(this.groupBoxInterpolationMode);
			this.Controls.Add(this.graphPanel);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.groupBoxActions);
			this.Name = "InterpolationForm";
			this.Text = "Interpolation Sample";
			this.groupBoxActions.ResumeLayout(false);
			this.groupBoxInterpolationMode.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new InterpolationForm());
		}

		private void groupBoxActions_Validated(object sender, System.EventArgs e)
		{
		}

		private void radioAdd_CheckedChanged(object sender, System.EventArgs e)
		{

		}

		private void radioAdd_Click(object sender, System.EventArgs e)
		{
			ApplyActionChanges();
		}

		private void radioMove_Click(object sender, System.EventArgs e)
		{
			ApplyActionChanges();
		}

		private void radioDelete_Click(object sender, System.EventArgs e)
		{
			ApplyActionChanges();
		}
		private void ApplyActionChanges()
		{
			if (radioAdd.Checked)    action = Actions.ADD;
			if (radioMove.Checked)   action = Actions.MOVE;
			if (radioDelete.Checked) action = Actions.DELETE;
		}
		private void ApplyInterpolationChanges()
		{
			if (radioButtonPolynomial.Checked)    mode = InterpolationMode.POLY;
			if (radioButtonSpline.Checked)   mode = InterpolationMode.NAT_SPL;

			this.graphPanel.Invalidate();
		}
		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			ClearPoints();
		}
		private void ClearPoints()
		{
		
			points.Clear();
			
			this.graphPanel.Invalidate();
		
			radioAdd.Checked = true;
		}

		private void radioButtonPolynomial_Click(object sender, System.EventArgs e)
		{
			ApplyInterpolationChanges();
		}

		private void radioButtonSpline_Click(object sender, System.EventArgs e)
		{
			ApplyInterpolationChanges();
		}
		private int findPoint(int a, int b) 
		{
			
			int max = points.Count;

			for(int i = 0; i < max; i++) 
			{
				ControlPoint pnt = (ControlPoint)points[i];
				if (pnt.within(a,b)) 
				{
					return i;
				}
			}
			return -1;
		}
		public bool handleEvent(MouseEvents e, int x, int y) 
		{
			switch (e) 
			{
				case MouseEvents.MOUSE_DOWN:
					// How we handle a MOUSE_DOWN depends on the action mode
				switch (action) 
				{
					case Actions.ADD:
						// Add a new control point at the specified location
						int np=points.Count;
						ControlPoint pnt;
						// keep points sorted by x: insert in correct place
						int i;
						for (i=0;
							i<=np-1 && ((ControlPoint) points[i]).x<x;i++) 
						{ }
						pnt = new ControlPoint(x,y);
						if (i<=np-1) 
						{
							points.Insert(i, pnt);
						} 
						else 
						{
							points.Add(pnt);
						} 
						this.graphPanel.Invalidate();
						break;
					case Actions.MOVE:
						// Attempt to select the point at the location specified.
						// If there is no point at the location, findPoint returns
						// -1 (i.e. there is no point to be moved)
						moving_point = findPoint(x, y);
						break;
					case Actions.DELETE:
						// Delete a point if one has been clicked
						int delete_pt = findPoint(x, y);
						if(delete_pt >= 0) 
						{
							points.RemoveAt(delete_pt);
							this.graphPanel.Invalidate();
						}
						break;
					default:
						throw new ArgumentException();
				}
					return true;
				case MouseEvents.MOUSE_UP:
					// We only care about MOUSE_UP's if we've been moving a control
					// point.  If so, drop the control point.
					if (moving_point >=0) 
					{
						moving_point = -1;
						this.graphPanel.Invalidate();
					}
					return true;
				case MouseEvents.MOUSE_DRAG:
					// We only care about MOUSE_DRAG's while we are moving a control
					// point.  Otherwise, do nothing.
					if (moving_point >=0) 
					{
						int np=points.Count;
						// test if e.x is between x of points.elementAt(moving_point+1)
						//                         and  points.elementAt(moving_point-1)
						if ( (moving_point==np-1 || 
							x<=((ControlPoint)points[moving_point+1]).x) &&
							(moving_point==0 ||
							x>=((ControlPoint)points[moving_point-1]).x) )
						{    
							ControlPoint pnt = (ControlPoint) points[moving_point];
							pnt.x = x;
							pnt.y = y;
						} 
						else 
						{
							// otherwise find correct slot (or just always do this?)
							points.RemoveAt(moving_point);
							int i;
							for (i=0;
								i<=np-2 && ((ControlPoint) points[i]).x<x;i++) 
							{ }
							ControlPoint pnt2 = new ControlPoint(x,y);
							if (i<=np-1) 
							{
								points.Insert(i,pnt2);
							} 
							else 
							{
								points.Add(pnt2);
							}
							moving_point=i;
						}
						this.graphPanel.Invalidate();
					}
					return true;
				case MouseEvents.WINDOW_DESTROY:
					this.Close();
					return true;
				default:
					return false;
			}
		}
  
		private void solveTridiag(float[] sub, float[] diag, float[] sup, ref float[] b, int n)
		{
			/*                  solve linear system with tridiagonal n by n matrix a
								using Gaussian elimination *without* pivoting
								where   a(i,i-1) = sub[i]  for 2<=i<=n
										a(i,i)   = diag[i] for 1<=i<=n
										a(i,i+1) = sup[i]  for 1<=i<=n-1
								(the values sub[1], sup[n] are ignored)
								right hand side vector b[1:n] is overwritten with solution 
								NOTE: 1...n is used in all arrays, 0 is unused */
			int i;
			/*                  factorization and forward substitution */
			for(i=2; i<=n; i++)
			{
				sub[i] = sub[i]/diag[i-1];
				diag[i] = diag[i] - sub[i]*sup[i-1];
				b[i] = b[i] - sub[i]*b[i-1];
			}
			b[n] = b[n]/diag[n];
			for(i=n-1;i>=1;i--)
			{
				b[i] = (b[i] - sup[i]*b[i+1])/diag[i];
			}
		}

		private void RefreshGraph(System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			Pen pointsPen = new Pen(Color.Red);

			Pen linePen1 = new Pen(Color.Red, 1);
			Pen linePen2 = new Pen(Color.Green, 1);
			Pen lastPen = null;
			Pen linePen = linePen1;
 
			int np = points.Count;           // number of points
			float[] yCoords = new float[np];        // Newton form coefficients
			float[] xCoords = new float[np];        // x-coordinates of nodes
			float y;
			float x;
			float oldy=0;
			float oldx=0;

			int npp = np*precision ;          // number of points used for drawing
			
			// draw a border around the canvas
			//g.DrawRectangle(0,0, size().width-1, size().height-1);
			if (np>0) 
			{
				// draw the control points
				for (int i=0; i < np; i++) 
				{
					ControlPoint p = (ControlPoint)points[i];
					xCoords[i]=p.x;
					yCoords[i]=p.y;
					g.DrawRectangle(pointsPen, p.x-p.PT_SIZE, p.y-p.PT_SIZE,p.PT_SIZE*2,p.PT_SIZE*2); 

					if (this.checkBoxShowCoords.Checked)
						g.DrawString((new Point(p.x, p.y)).ToString(), new Font("Verdana", 6), Brushes.Black, p.x + p.PT_SIZE + 1, p.y + p.PT_SIZE + 1); 
				}
				switch (mode)
				{ 
					case(InterpolationMode.POLY):
						// use divided difference algorithm to compute Newton form coefficients
						for (int k=1; k<=np-1; k++) 
						{
							for (int i=0; i<=np-1-k; i++) 
							{
								yCoords[i]=(yCoords[i+1]-yCoords[i])/(xCoords[i+k]-xCoords[i]);
							}
						}
						
						// for equidistant points along x-axis evaluate polynomial and draw line
						float dt = ((float) this.graphPanel.Width-1)/npp;
						for (int k=0; k<=npp; k++) 
						{
							x=k*dt;
							// evaluate polynomial at t
							y = yCoords[0];
							for (int i=1; i<=np-1; i++) 
							{   
								y=y*(x-xCoords[i])+yCoords[i];
							}
							// draw line
							try
							{
								g.DrawLine(linePen, (int)oldx,(int)oldy,(int)x,(int)y);
							}
							catch(Exception ex)
							{
								Console.WriteLine(ex.Message + " x1={0} y1={1} x2={2} y2={3}", oldx, oldy, x, y);
							}
							oldx=x;
							oldy=y;
						}
						break;
					case(InterpolationMode.NAT_SPL): 
						if (np>1)
						{  
							float[] a = new float[np];
							float x1;
							float x2;
							float[] h = new float[np];
							for (int i=1; i<=np-1; i++)
							{
								h[i] = xCoords[i] - xCoords[i-1];
							}
							if (np>2)
							{
								float[] sub = new float[np-1];
								float[] diag = new float[np-1];
								float[] sup = new float[np-1];
            
								for (int i=1; i<=np-2; i++)
								{
									diag[i] = (h[i] + h[i+1])/3;
									sup[i] = h[i+1]/6;
									sub[i] = h[i]/6;
									a[i] = (yCoords[i+1]-yCoords[i])/h[i+1]-(yCoords[i]-yCoords[i-1])/h[i];
								}
								solveTridiag(sub,diag,sup,ref a,np-2);
							}
							// note that a[0]=a[np-1]=0
							// draw

							oldx=xCoords[0];
							oldy=yCoords[0];

							try
							{
								g.DrawLine(linePen, (int)oldx,(int)oldy,(int)oldx,(int)oldy);
							}
							catch(Exception ex)
							{
								Console.WriteLine(ex.Message + " x1={0} y1={1} x2={0} y2={1}", oldx, oldy);
							}
							
							for (int i=1; i<=np-1; i++) 
							{   // loop over intervals between nodes
								for (int j=1; j<=precision; j++)
								{
									x1 = (h[i]*j)/precision;
									x2 = h[i] - x1;
									y = ((-a[i-1]/6*(x2+h[i])*x1+yCoords[i-1])*x2 +
										(-a[i]/6*(x1+h[i])*x2+yCoords[i])*x1)/h[i];
									x=xCoords[i-1]+x1;

									if ((lastPen == null) || (lastPen == linePen2))
										linePen = linePen1;
									else
										linePen = linePen2;
									lastPen = linePen;
									
									try
									{
										g.DrawLine(linePen, (int)oldx,(int)oldy,(int)x,(int)y);
									}
									catch(Exception ex)
									{
										Console.WriteLine(ex.Message + " x1={0} y1={1} x2={2} y2={3}", oldx, oldy, x, y);
									}
									
									oldx=x;
									oldy=y;
								}
							}
						}
						break;
				}
			}
		}
		private void graphPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			handleEvent(MouseEvents.MOUSE_DOWN, e.X, e.Y);
		}

		private void graphPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			handleEvent(MouseEvents.MOUSE_UP, e.X, e.Y);
		}

		private void graphPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// stò spostando il mouse con il tasto sinistro premuto. suppongo sia un MOVE
			if (e.Button == MouseButtons.Left)
				handleEvent(MouseEvents.MOUSE_DRAG, e.X, e.Y);
		}

		private void graphPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.RefreshGraph(e);
		}

		private void checkBoxShowCoords_CheckedChanged(object sender, System.EventArgs e)
		{
			this.graphPanel.Invalidate();
		}
	}   
}
