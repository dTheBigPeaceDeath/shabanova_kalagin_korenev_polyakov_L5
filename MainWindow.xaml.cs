using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Graphics;

namespace shabanova_kalagin_korenev_polyakov_L5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Exercise current_ex;
        public MainWindow()
        {
            InitializeComponent();

            lbx_exercises.DisplayMemberPath = "Name";
            lbx_exercises.ItemsSource = new List<Exercise>()
            {
                new Exercise1(grd_ex1, new CPFrequencyPolygon(cvs_polygon, "Xi", "Ni"), new CPEmpiricalFunction(cvs_empirical, "Xi", "F*(x)"))
            };

            foreach(Exercise ex in lbx_exercises.Items)
            {
                ex.Load();
            }
        }
        private void lbx_exercises_SelectionChanged(object _sender, SelectionChangedEventArgs _e)
        {
            ListBox lbx_this = _sender as ListBox;

            if (current_ex != null)
            {
                current_ex.IsActive = false;
            }

            current_ex = lbx_this.SelectedItem as Exercise;

            if (current_ex != null)
            {
                current_ex.IsActive = true;
                current_ex.Show();
            }
        }
    }
}
