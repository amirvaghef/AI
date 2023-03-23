To interpolate Bezier-Spline-Segments as an Y = f(X) - function is mathematically incorrect.
Although I keep the support-points ordered "from left to right" a Segment can take forms, where it shows more than one Y-Value on certain X-positions.
My "interpolation" ignores such, and simply returns the first found Y-Value.
The failure lets itself be seen by some parts of the curve, which cannot be reached by interpolation.

Mathematically correct is to interpolate CubicSplines.
They are mathematically undefined only if two support-points set on the same X-position.

Point of interest
The project deals with several ownerdraw-requirements:
move- and highlight-able points, polygons, bezier-splines, cubic-splines, and a caption

I collected them into a little hierarchy of classes:
        
               ControlCaption
              / 
DrawObjectBase---DrawPoint
              \
               \         BezierSpline
                \       /
                 Polygon
                        \
                         CubicSpline
                         
You see: programmically I consider a spline as a polygon with a different way to draw and interpolate the line between two support-points. And if there are only two support-points - they display the same straight line.

To understand the program you can start with looking at the DrawObjectBase.
Then descend the class-hierarchy to Polygon and BezierSpline.
            
VB9
Eine interpolierbare Kurve erstellen durch Hinzufügen, Verschieben, Löschen von Stützpunkten.
Auf einen Bereich der Kurve zeigen, und das Interpolations-Ergebnis ablesen.
3 Arten von Kurven im Angebot: Polygon, kubische Splines, Bezier-Splines