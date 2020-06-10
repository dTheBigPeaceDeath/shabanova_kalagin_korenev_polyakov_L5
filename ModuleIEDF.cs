﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using shabanova_kalagin_korenev_polyakov_L5.Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleIEDF : Module
    {
        public ModuleIEDF(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            Canvas canvas = new Canvas()
            {
                Width = 1000,
                Height = 500
            };
            CPEmpirical empirical = new CPEmpirical(canvas, "wi", "xi");

            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach (KeyValuePair<Tuple<double, double>, double> di in Row.i_statistical_relative_row)
            {
                empirical.AddPoint(di.Key.Item1, di.Value);
                empirical.AddPoint(di.Key.Item2, di.Value);
            }

            empirical.d_y = 1;
            empirical.ShowCoordinatePlane();
        }
    }
}
