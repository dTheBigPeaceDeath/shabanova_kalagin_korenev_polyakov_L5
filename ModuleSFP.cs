using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using shabanova_kalagin_korenev_polyakov_L5.Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleSFP : Module // ...Полигон
    {
        public ModuleSFP(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            Canvas canvas = new Canvas()
            {
                Width = 1000,
                Height = 500
            };
            CPPolygon polygon = new CPPolygon(canvas, "ni", "xi");

            module_grid.Children.Add(canvas);
            Grid.SetRow(canvas, 1);

            foreach(KeyValuePair<double, int> di in Row.statistical_row)
            {
                polygon.AddPoint(di.Key, di.Value);
            }

            polygon.proections = true;
            polygon.ShowCoordinatePlane();
        }
    }
}
