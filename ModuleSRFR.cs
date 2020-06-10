using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class ModuleSRFR : Module
    {
        public ModuleSRFR(StackPanel _panel, CheckBox _activity) : base(_panel, _activity)
        {

        }
        public override void Calculate()
        {
            int c1;
            Grid sfr_table = new Grid();
            TextBlock tbx_temp;

            sfr_table.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(100)
            });

            for (c1 = 0; c1 < 2; c1++)
            {
                sfr_table.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(20)
                });
            }

            tbx_temp = new TextBlock();
            tbx_temp.Text = "xi";
            tbx_temp.HorizontalAlignment = HorizontalAlignment.Right;
            tbx_temp.VerticalAlignment = VerticalAlignment.Center;
            sfr_table.Children.Add(tbx_temp);
            Grid.SetColumn(tbx_temp, 0);
            Grid.SetRow(tbx_temp, 0);

            tbx_temp = new TextBlock();
            tbx_temp.Text = "wi";
            tbx_temp.HorizontalAlignment = HorizontalAlignment.Right;
            tbx_temp.VerticalAlignment = VerticalAlignment.Center;
            sfr_table.Children.Add(tbx_temp);
            Grid.SetColumn(tbx_temp, 0);
            Grid.SetRow(tbx_temp, 1);

            c1 = 1;
            foreach (KeyValuePair<double, double> dd in Row.statistical_relative_row)
            {
                sfr_table.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(50)
                });

                tbx_temp = new TextBlock();
                tbx_temp.Text = dd.Key.ToString("0.##");
                tbx_temp.HorizontalAlignment = HorizontalAlignment.Center;
                tbx_temp.VerticalAlignment = VerticalAlignment.Center;
                sfr_table.Children.Add(tbx_temp);
                Grid.SetColumn(tbx_temp, c1);
                Grid.SetRow(tbx_temp, 0);

                tbx_temp = new TextBlock();
                tbx_temp.Text = dd.Value.ToString("0.##");
                tbx_temp.HorizontalAlignment = HorizontalAlignment.Center;
                tbx_temp.VerticalAlignment = VerticalAlignment.Center;
                sfr_table.Children.Add(tbx_temp);
                Grid.SetColumn(tbx_temp, c1);
                Grid.SetRow(tbx_temp, 1);

                c1++;
            }

            module_grid.Children.Add(sfr_table);
            Grid.SetRow(sfr_table, 1);
        }
    }
}
