using System;
using System.Collections.Generic;
using System.Windows.Controls;
using shabanova_kalagin_korenev_polyakov_L5.Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleSRFP : Module // Относительный ряд
    {
        public ModuleSRFP(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            Canvas canvas = new Canvas()
            {
                Width = 1000,
                Height = 500
            };
            CPPolygon polygon = new CPPolygon(canvas, "wi", "xi");

            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach (KeyValuePair<double, double> di in Row.statistical_relative_row)
            {
                polygon.AddPoint(di.Key, di.Value);
            }

            polygon.proections = true;
            polygon.ShowCoordinatePlane();
        }
    }
}
