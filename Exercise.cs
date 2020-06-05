using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    class Exercise
    {
        protected Grid ex_grid;
        protected bool is_active;
        public string Name { get; private set; }
        public bool IsActive
        {
            get
            {
                return is_active;
            }
            set
            {
                if(value)
                {
                    ex_grid.Visibility = Visibility.Visible;
                }
                else
                {
                    ex_grid.Visibility = Visibility.Collapsed;
                }

                is_active = value;
            }
        }
        protected Exercise(Grid _ex_grid, string _name)
        {
            ex_grid = _ex_grid;
            Name = _name;

            is_active = false;
        }
        public virtual void Load()
        {

        }
        public virtual void Show()
        {

        }
        public static List<List<string>> LoadData(string _path)
        {
            StreamReader reader = new StreamReader(new FileStream(_path, FileMode.Open));
            List<List<string>> R = new List<List<string>>();

            while(!reader.EndOfStream)
            {
                R.Add(reader.ReadLine().Split(new char[] { ' ' }).ToList<string>());
            }

            reader.Close();

            return R;
        }
    }
}
