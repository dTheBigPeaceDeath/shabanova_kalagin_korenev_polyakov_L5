using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    static class Row
    {
        public static List<double> row;
        public static Dictionary<double, int> statistical_row;
        public static Dictionary<double, double> statistical_relative_row;
        public static Dictionary<double, double> efunction;
        public static double X;
        public static double D;
        public static double O;
        public static double S;
        public static void LoadRow(string _path)
        {
            double first_value = 0.0;
            List<List<string>> data = LoadTextData(_path);

            row = new List<double>();

            foreach(List<string> str_list in data)
            {
                foreach(string str in str_list)
                {
                    char point = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0];
                    string str2 = str.Replace(',', point);
                    row.Add(Convert.ToDouble(str2));
                }
            }

            row.Sort();

            statistical_row = new Dictionary<double, int>();

            foreach(double d in row)
            {
                if(statistical_row.ContainsKey(d))
                {
                    statistical_row[d]++;
                }
                else
                {
                    statistical_row.Add(d, 1);
                }
            }

            statistical_relative_row = new Dictionary<double, double>();
            foreach (KeyValuePair<double, int> di in statistical_row)
            {
                statistical_relative_row.Add(di.Key, (double)di.Value / row.Count);
            }

            efunction = new Dictionary<double, double>();
            foreach (KeyValuePair<double, double> dd in statistical_relative_row)
            {
                efunction.Add(dd.Key, first_value);
                first_value += dd.Value;
            }

            //X
            foreach (KeyValuePair<double, int> di in Row.statistical_row)
            {
                X += di.Key * di.Value;
            }
            X /= Row.statistical_row.Count;

            //D
            foreach (KeyValuePair<double, int> di in Row.statistical_row)
            {
                D += di.Value * Math.Pow(di.Key - X, 2);
            }
            D /= Row.statistical_row.Count;

            //O
            O = Math.Sqrt(D);

            //S доделать
            S = 0;
        }
        public static List<List<string>> LoadTextData(string _path)
        {
            List<List<string>> R = new List<List<string>>();
            StreamReader reader = new StreamReader(new FileStream(_path, FileMode.Open));

            while(!reader.EndOfStream)
            {
                R.Add(reader.ReadLine().Split(new char[] { ' ' }).ToList<string>());
            }

            reader.Close();

            return R;
        }
    }
}
