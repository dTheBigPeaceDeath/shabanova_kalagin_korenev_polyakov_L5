using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace shabanova_kalagin_korenev_polyakov_L5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UIElement> variable_enabled;
        List<Module> modules;
        public MainWindow()
        {
            InitializeComponent();

            variable_enabled = new List<UIElement>()
            {
                btn_calculate,
                chb_sf_row,
                chb_sf_polygon,
                chb_srf_row,
                chb_srf_polygon,
                chb_edf,
                chb_X,
                chb_D,
                chb_O,
                chb_S,
            };

            modules = new List<Module>()
            {
                new ModuleSFR(spl_modules, chb_sf_row),
                new ModuleSFP(spl_modules, chb_sf_polygon),
                new ModuleSRFR(spl_modules, chb_srf_row),
                new ModuleSRFP(spl_modules, chb_srf_polygon),
                new ModuleEDF(spl_modules, chb_edf),
                new ModuleX(spl_modules, chb_X),
                new ModuleD(spl_modules, chb_D),
                new ModuleO(spl_modules, chb_O),
                new ModuleS(spl_modules, chb_S),
                new ModuleISFR(spl_modules, chb_i_sf_row),
                new ModuleISFH(spl_modules, chb_i_sf_gist),
                new ModuleISRFR(spl_modules, chb_i_srf_row),
                new ModuleISRFH(spl_modules, chb_i_srf_gist),
                new ModuleIEDF(spl_modules, chb_i_edf),
            };

            tbx_path.TextChanged += tbx_path_TextChanged;
        }

        private void btn_find_Click(object _sender, RoutedEventArgs _e)
        {
            OpenFileDialog row_dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Выберите файл",
                Filter = "Вариационный ряд (*.row)|*.row"
            };

            if (row_dialog.ShowDialog() == true)
            {
                tbx_path.Text = row_dialog.FileName;
            }
        }

        private void tbx_path_TextChanged(object _sender, TextChangedEventArgs _e)
        {
            bool is_exist = false;

            if(tbx_path.Text != "")
            {
                is_exist = new FileInfo(tbx_path.Text).Exists;
            }

            foreach (UIElement uie in variable_enabled)
            {
                uie.IsEnabled = is_exist;
            }
        }

        private void btn_calculate_Click(object _sender, RoutedEventArgs _e)
        {
            Row.LoadRow(tbx_path.Text);

            spl_modules.Children.Clear();

            foreach(Module module in modules)
            {
                module.Run();
            }
        }
    }
}
