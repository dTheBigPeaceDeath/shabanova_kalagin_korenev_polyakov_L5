using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class Exercise1 : Exercise
    {
        private List<double> row;
        private Dictionary<double, double> statistical_row;
        private Dictionary<double, double> statistical_relative_row;
        private CPFrequencyPolygon polygon;
        private CPEmpiricalFunction efunction;
        public Exercise1(Grid _ex_grid, CPFrequencyPolygon _polygon, CPEmpiricalFunction _efunction) : base(_ex_grid, "Задача №1")
        {
            polygon = _polygon;
            polygon.text_color = Brushes.Black;
            polygon.connection_color = Brushes.Red;
            polygon.label_color = Brushes.Black;

            efunction = _efunction;
            efunction.first_multiplier_x = 0;
            efunction.first_multiplier_y = 0;
            efunction.text_color = Brushes.Black;
            efunction.connection_color = Brushes.Red;
            efunction.proection_color = Brushes.Blue;
            efunction.label_color = Brushes.Black;
        }
        public override void Load()
        {
            List<List<string>> data = LoadData("row2.txt");
            double frequency_value = 0.0;

            row = new List<double>();
            statistical_row = new Dictionary<double, double>();
            statistical_relative_row = new Dictionary<double, double>();

            foreach (List<string> str_list in data)
            {
                foreach (string str in str_list)
                {
                    row.Add(Convert.ToDouble(str));
                }
            }

            foreach(double value in row)
            {
                if(statistical_row.ContainsKey(value))
                {
                    statistical_row[value] += 1.0;
                }
                else
                {
                    statistical_row.Add(value, 1.0);
                }
            }

            foreach(KeyValuePair<double, double> ddpair in statistical_row)
            {
                statistical_relative_row.Add(ddpair.Key, ddpair.Value / (double)row.Count);
                polygon.AddPoint(ddpair.Key, ddpair.Value);
            }

            foreach (KeyValuePair<double, double> ddpair in statistical_relative_row.OrderBy(ddpair => ddpair.Key))
            {
                efunction.AddPoint(ddpair.Key, frequency_value);
                frequency_value += ddpair.Value;
            }
        }
        public override void Show()
        {
            polygon.Show();
            efunction.Show();
        }
    }
}
