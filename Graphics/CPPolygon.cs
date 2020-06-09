using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    class CPPolygon : CoordinatePlane
    {
        public Brush connection_color;
        public double connection_thickness;
        public CPPolygon(Canvas _canvas, string _axis_x_name, string _axis_y_name) : base(_canvas, _axis_x_name, _axis_y_name)
        {
            connection_thickness = 1.0;
            connection_color = Brushes.BlueViolet;
        }
        public override void ShowCoordinatePlane()
        {
            int c1;

            axis_x.Show();
            axis_y.Show();

            foreach (Point p in points)
            {
                CreatePoint(p);
                if (proections)
                {
                    CreateProections(p);
                }
            }

            for(c1 = 0; c1 < points.Count - 1; c1++)
            {
                ConnectPoints(points[c1], points[c1 + 1]);
            }
        }
        private void ConnectPoints(Point _p1, Point _p2)
        {
            CreateLine(new Vector2(_p1.label_x.axis_value, _p1.label_y.axis_value),
                new Vector2(_p2.label_x.axis_value, _p2.label_y.axis_value),
                connection_thickness, connection_color);
        }
    }
}
