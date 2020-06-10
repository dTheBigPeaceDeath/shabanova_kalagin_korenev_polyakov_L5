using System;
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
            empirical.proections = true;
            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach (KeyValuePair<double, double> di in Row.i_efunction)
            {   
                empirical.AddPoint(di.Key, di.Value);
            }

            empirical.ShowCoordinatePlane();
        }
    }
}
