using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleD : Module
    {
        public ModuleD(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            TextBlock tbx_temp = new TextBlock();
            Grid sfr_table = new Grid();
            tbx_temp.Text = Convert.ToString(Row.D);
            tbx_temp.HorizontalAlignment = HorizontalAlignment.Left;
            tbx_temp.VerticalAlignment = VerticalAlignment.Center;
            sfr_table.Children.Add(tbx_temp);
            Grid.SetColumn(tbx_temp, 0);
            Grid.SetRow(tbx_temp, 0);

            module_grid.Children.Add(sfr_table);
            Grid.SetRow(sfr_table, 1);
        }
    }

}
