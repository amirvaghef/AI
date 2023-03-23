<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterpolation
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInterpolation))
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.btPolygon = New System.Windows.Forms.ToolStripButton
      Me.btSpline = New System.Windows.Forms.ToolStripButton
      Me.btBezier = New System.Windows.Forms.ToolStripButton
      Me.btBezierPathPoints = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.lbPointer = New System.Windows.Forms.ToolStripLabel
      Me.picCanvas = New System.Windows.Forms.PictureBox
      Me.ToolStrip1.SuspendLayout()
      CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btPolygon, Me.btSpline, Me.btBezier, Me.btBezierPathPoints, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.lbPointer})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.ShowItemToolTips = False
      Me.ToolStrip1.Size = New System.Drawing.Size(664, 25)
      Me.ToolStrip1.TabIndex = 0
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'btPolygon
      '
      Me.btPolygon.CheckOnClick = True
      Me.btPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.btPolygon.Image = CType(resources.GetObject("btPolygon.Image"), System.Drawing.Image)
      Me.btPolygon.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btPolygon.Name = "btPolygon"
      Me.btPolygon.Size = New System.Drawing.Size(49, 22)
      Me.btPolygon.Text = "Polygon"
      '
      'btSpline
      '
      Me.btSpline.CheckOnClick = True
      Me.btSpline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.btSpline.Image = CType(resources.GetObject("btSpline.Image"), System.Drawing.Image)
      Me.btSpline.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btSpline.Name = "btSpline"
      Me.btSpline.Size = New System.Drawing.Size(65, 22)
      Me.btSpline.Text = "CubicSpline"
      '
      'btBezier
      '
      Me.btBezier.CheckOnClick = True
      Me.btBezier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.btBezier.Image = CType(resources.GetObject("btBezier.Image"), System.Drawing.Image)
      Me.btBezier.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btBezier.Name = "btBezier"
      Me.btBezier.Size = New System.Drawing.Size(68, 22)
      Me.btBezier.Text = "BezierSpline"
      '
      'btBezierPathPoints
      '
      Me.btBezierPathPoints.CheckOnClick = True
      Me.btBezierPathPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.btBezierPathPoints.Enabled = False
      Me.btBezierPathPoints.Image = CType(resources.GetObject("btBezierPathPoints.Image"), System.Drawing.Image)
      Me.btBezierPathPoints.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btBezierPathPoints.Name = "btBezierPathPoints"
      Me.btBezierPathPoints.Size = New System.Drawing.Size(91, 22)
      Me.btBezierPathPoints.Text = "BezierPathPoints"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(78, 22)
      Me.ToolStripLabel1.Text = "Curve-Pointer:"
      '
      'lbPointer
      '
      Me.lbPointer.BackColor = System.Drawing.Color.White
      Me.lbPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.lbPointer.Name = "lbPointer"
      Me.lbPointer.Size = New System.Drawing.Size(49, 22)
      Me.lbPointer.Text = "lbPointer"
      '
      'picCanvas
      '
      Me.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill
      Me.picCanvas.Location = New System.Drawing.Point(0, 25)
      Me.picCanvas.Name = "picCanvas"
      Me.picCanvas.Size = New System.Drawing.Size(664, 349)
      Me.picCanvas.TabIndex = 1
      Me.picCanvas.TabStop = False
      '
      'frmInterpolation
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(664, 374)
      Me.Controls.Add(Me.picCanvas)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Name = "frmInterpolation"
      Me.Text = "Interpolation"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents btBezierPathPoints As System.Windows.Forms.ToolStripButton
   Friend WithEvents lbPointer As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents picCanvas As PictureBox
   Friend WithEvents btPolygon As System.Windows.Forms.ToolStripButton
   Friend WithEvents btSpline As System.Windows.Forms.ToolStripButton
   Friend WithEvents btBezier As System.Windows.Forms.ToolStripButton

End Class
