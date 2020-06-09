using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Controls;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    abstract class Module
    {
        protected CheckBox activity;
        private StackPanel panel;
        protected Grid module_grid;
        public Module(StackPanel _panel, CheckBox _activity)
        {
            panel = _panel;
            activity = _activity;
        }
        public abstract void Calculate();
        public void Run()
        {
            if(activity.IsChecked == true)
            {
                Show();
            }
        }
        public void Show()
        {
            TextBlock tbx_name = new TextBlock();

            module_grid = new Grid();
            module_grid.RowDefinitions.Add(new RowDefinition());
            module_grid.RowDefinitions.Add(new RowDefinition());

            tbx_name.Text = activity.Content.ToString();
            module_grid.Children.Add(tbx_name);
            Grid.SetRow(tbx_name, 0);
            panel.Children.Add(module_grid);

            Calculate();
        }
    }
}
