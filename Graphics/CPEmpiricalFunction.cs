using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics
{
    class CPEmpiricalFunction : CoordinatePlane
    {
        public Brush connection_color;
        public Brush proection_color;
        public CPEmpiricalFunction(Canvas _canvas, string _axis_x_name, string _axis_y_name) : base(_canvas, _axis_x_name, _axis_y_name)
        {
            connection_color = Brushes.Black;
            proection_color = Brushes.Red;
        }
        public override void ShowPreview()
        {
            axis_x.labels.Insert(0, new Label(axis_x, 0));
        }
        public override void ShowAdditioanal()
        {
            int c1;

            NullPoint.label_x = axis_x.labels[0];
            NullPoint.label_y = axis_y.labels[0];

            for (c1 = 0; c1 < points.Count; c1++)
            {
                if (c1 == 0)
                {
                    ConnectPointsHorizontal(points[c1], NullPoint);
                }
                else
                {
                    ConnectPointsHorizontal(points[c1], points[c1 - 1]);
                }
            }
        }
        private void ConnectPointsHorizontal(Point _p1, Point _p2)
        {
            Line connection = new Line();
            Line proection = new Line();

            connection.X1 = _p1.label_x.CoordValue;
            connection.Y1 = _p1.label_y.CoordValue;
            connection.X2 = _p2.label_x.CoordValue;
            connection.Y2 = _p1.label_y.CoordValue;

            connection.StrokeThickness = 2.0;
            connection.Stroke = connection_color;

            proection.X1 = _p2.label_x.CoordValue;
            proection.Y1 = _p1.label_y.CoordValue;
            proection.X2 = _p2.label_x.CoordValue;
            proection.Y2 = NullPoint.value_y;

            proection.StrokeThickness = 1.0;
            proection.Stroke = proection_color;
            proection.StrokeDashArray = new DoubleCollection
            {
                4,
                2
            };

            CreateArrow(Position.Horizontal, new Point(_p2.label_x.CoordValue, _p1.label_y.CoordValue), new Point(10.0, 5.0), 1.0, connection_color);

            canvas.Children.Add(connection);
            canvas.Children.Add(proection);
        }
    }
}
