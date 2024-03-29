using SportBar_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SportBar_0.MVVM.View
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Page 
    {
        public Setting()
        {
            InitializeComponent();
          
            p1Input.Text = Settings1.Default.price1.ToString();
            p2Input.Text = Settings1.Default.price2.ToString();
            p3Input.Text = Settings1.Default.price3.ToString();
            p4Input.Text = Settings1.Default.price4.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


          //  int p1 = 0;
            //Settings1.Default.price1;
           // int p2 = 0;
            //Settings1.Default.price2;
           // int p3 = 0;
            //Settings1.Default.price3;
           // int p4 = 0;
            //Settings1.Default.price4;

            HoursCalc calc = new HoursCalc();
            if(int.Parse(p1Input.Text.ToString()) != null && int.Parse(p2Input.Text.ToString())!=null && int.Parse(p3Input.Text.ToString()) != null && int.Parse(p4Input.Text.ToString()) != null)
                 calc.PriceChenge(int.Parse(p1Input.Text.ToString()), int.Parse(p2Input.Text.ToString()), int.Parse(p3Input.Text.ToString()), int.Parse(p4Input.Text.ToString()));
            // int.Parse(p2Input.Text) != null &&
            //int.Parse(p3Input.Text)
            //int.Parse(p4Input.Text))
          //  if(p1 != 0 && p2 != 0 && p3 !=0 && p4 !=0)
          //  else
          //  {
          //      MessageBox.Show("השדות אינם יכולים להיות ריקים");
          //  }


            Settings1.Default.price1 = int.Parse(p1Input.Text.ToString());
            Settings1.Default.price2 = int.Parse(p2Input.Text.ToString());
            Settings1.Default.price3 = int.Parse(p3Input.Text.ToString());
            Settings1.Default.price4 = int.Parse(p4Input.Text.ToString());
            Settings1.Default.Save();
        }


        private void txt_preview(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+");

            if (e.Text.ToString() == ".")
                e.Handled = false;
            else
                e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
