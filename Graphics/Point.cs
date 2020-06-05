using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics
{
    class Point : IComparable<Point>
    {
        public double value_x;
        public double value_y;
        public Label label_x;
        public Label label_y;
        public CoordinatePlane ParentPlane { get; private set; }
        public Point(double _value_x, double _value_y)
        {
            value_x = _value_x;
            value_y = _value_y;

            label_x = null;
            label_y = null;
        }
        public Point(CoordinatePlane _parent_plane, double _value_x, double _value_y) : this(_value_x, _value_y)
        {
            ParentPlane = _parent_plane;
        }
        public int CompareTo(Point _point)
        {
            return value_x.CompareTo(_point.value_x);
        }
        public void Show()
        {
            Ellipse ellipse_point = new Ellipse();

            ellipse_point.Width = ParentPlane.point_size;
            ellipse_point.Height = ParentPlane.point_size;
            ellipse_point.Fill = ParentPlane.point_color;
            ParentPlane.canvas.Children.Add(ellipse_point);

            Canvas.SetLeft(ellipse_point, label_x.CoordValue - (ellipse_point.Width / 2));
            Canvas.SetTop(ellipse_point, label_y.CoordValue - (ellipse_point.Height / 2));
        }
    }
}
