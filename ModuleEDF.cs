using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using shabanova_kalagin_korenev_polyakov_L5.Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleEDF : Module // Импирическая функция распределения
    {
        public ModuleEDF(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }   
        public override void Calculate()
        {
            Canvas canvas = new Canvas()
            {
                Width = 1000,
                Height = 500
            };
            CPEmpirical efunction = new CPEmpirical(canvas, "xi", "F*(xi)");

            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach (KeyValuePair<double, double> di in Row.efunction)
            {
                efunction.AddPoint(di.Key, di.Value);
            }

            efunction.proections = true;
            efunction.ShowCoordinatePlane();
        }
    }
}
