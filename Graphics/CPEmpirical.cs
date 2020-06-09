using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace shabanova_kalagin_korenev_polyakov_L5.Graphics
{
    class CPEmpirical : CoordinatePlane
    {
        public Brush ha_color;
        public double ha_thickness;
        public CPEmpirical(Canvas _canvas, string _axis_x_name, string _axis_y_name) : base(_canvas, _axis_x_name, _axis_y_name)
        {
            d_y = 0;

            ha_color = Brushes.Aquamarine;
            ha_thickness = 2.0;
        }
        public override void ShowCoordinatePlane()
        {
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

            foreach(Point p in points)
            {
                CreateHorizontalArrow(p);
            }
            CreateHorizontalArrowFromInfinity(points[points.Count - 1]);
        }
        public void CreateHorizontalArrow(Point _p)
        {
            CreateLine(new Vector2(_p.label_x.axis_value, _p.label_y.axis_value),
                new Vector2(_p.label_x.axis_value - ((axis_x.Length * 0.9) / axis_x.LabelsCount), _p.label_y.axis_value),
                ha_thickness, ha_color);
            CreateArrow(new Vector2(_p.label_x.axis_value - ((axis_x.Length * 0.9) / axis_x.LabelsCount), _p.label_y.axis_value),
                Position.Horizontal, -10, 5, ha_thickness, ha_color);
        }
        public void CreateHorizontalArrowFromInfinity(Point _p)
        {
            CreateLine(new Vector2(_p.label_x.axis_value, axis_y.Length),
                new Vector2(axis_x.Length, axis_y.Length),
                ha_thickness, ha_color);
            CreateArrow(new Vector2(_p.label_x.axis_value, axis_y.Length),
                Position.Horizontal, -10, 5, ha_thickness, ha_color);
        }
    }
}
