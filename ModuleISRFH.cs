using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using shabanova_kalagin_korenev_polyakov_L5.Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleISRFH : Module
    {
        public ModuleISRFH(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            Canvas canvas = new Canvas()
            {
                Width = 1000,
                Height = 500
            };
            CPHistogram histogram = new CPHistogram(canvas, "ni", "xi");

            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach (KeyValuePair<Tuple<double, double>, double> di in Row.i_statistical_relative_row)
            {
                histogram.AddPoint(di.Key.Item1, di.Value);
                histogram.AddPoint(di.Key.Item2, di.Value);
            }

            histogram.ShowCoordinatePlane();
        }
    }
}
