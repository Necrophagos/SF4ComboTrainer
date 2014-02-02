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
using SF4ComboTrainerViewModel;

namespace SF4ComboTrainerView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();


            TimeLineItemViewModel prs = new TimeLineItemViewModel( );
            prs.Direction_Down = true;
            prs.Light_Kick = true;

            TimeLineListView.Items.Add(prs);
        }

        private void btn_PressInput_Click(object sender, RoutedEventArgs e)
        {
            TimeLineItemViewModel prs = new TimeLineItemViewModel();
            TimeLineListView.Items.Add(prs);
        }
 
    }
}
