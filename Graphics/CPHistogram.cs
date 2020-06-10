using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    class CPHistogram : CoordinatePlane
    {
        public Brush pillar_color;
        public double pillar_thickness;
        public CPHistogram(Canvas _canvas, string _axis_x_name, string _axis_y_name) : base(_canvas, _axis_x_name, _axis_y_name)
        {
            pillar_color = Brushes.Chocolate;
            pillar_thickness = 4.0;
            d_y = 0;
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

            for(c1 = 1; c1 < points.Count; c1++)
            {
                CreatePillar(new Vector2(points[c1].label_x.axis_value, points[c1].label_y.axis_value),
                    new Vector2(points[c1 - 1].label_x.axis_value, points[c1 - 1].label_y.axis_value));
            }
        }
        public void CreatePillar(Vector2 _coords_p1, Vector2 _coords_p2)
        {
            CreateLine(_coords_p1, new Vector2(_coords_p1.x, 0), pillar_thickness, pillar_color);
            CreateLine(_coords_p1, _coords_p2, pillar_thickness, pillar_color);
            CreateLine(_coords_p2, new Vector2(_coords_p2.x, 0), pillar_thickness, pillar_color);
        }
    }
}
