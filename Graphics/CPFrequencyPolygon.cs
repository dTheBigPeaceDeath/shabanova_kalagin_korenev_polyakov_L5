using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics
{
    class CPFrequencyPolygon : CoordinatePlane
    {
        public Brush connection_color;
        public CPFrequencyPolygon(Canvas _canvas, string _axis_x_name, string _axis_y_name) : base(_canvas, _axis_x_name, _axis_y_name)
        {
            connection_color = Brushes.Black;
        }
        public override void ShowAdditioanal()
        {
            int c1;

            points.Sort();

            for(c1 = 0; c1 < points.Count; c1++)
            {
                if(c1 != points.Count - 1)
                {
                    ConnectPoints(points[c1], points[c1 + 1]);
                }
            }
        }
        private void ConnectPoints(Point _p1, Point _p2)
        {
            Line connection = new Line();

            connection.X1 = _p1.label_x.CoordValue;
            connection.Y1 = _p1.label_y.CoordValue;
            connection.X2 = _p2.label_x.CoordValue;
            connection.Y2 = _p2.label_y.CoordValue;

            connection.StrokeThickness = 1.0;
            connection.Stroke = connection_color;

            canvas.Children.Add(connection);
        }
    }
}
