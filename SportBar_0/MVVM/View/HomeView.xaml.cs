using SportBar_0.Core;
using System;
using IronPdf;
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
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Windows.Threading;

namespace SportBar_0.MVVM.View
{

    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>

    public partial class HomeView
    {


        HoursCalc[] HoursCalcs = new HoursCalc[15];


        // HoursCalc temp = new HoursCalc();
        bool restorable = true;
        public float x = 0;
        //  int sum = 0;
        string a = "";


        HoursCalc tempf;


        bool flag = false;


        public HomeView()
        {
            InitializeComponent();

            Calc.Visibility = Visibility.Hidden;
            Calc2.Visibility = Visibility.Hidden;
            Calc3.Visibility = Visibility.Hidden;
            Calc4.Visibility = Visibility.Hidden;
            Calc5.Visibility = Visibility.Hidden;
            Calc6.Visibility = Visibility.Hidden;
            Calc7.Visibility = Visibility.Hidden;
            Calc8.Visibility = Visibility.Hidden;
            Calc9.Visibility = Visibility.Hidden;
            Calc10.Visibility = Visibility.Hidden;
            Calc11.Visibility = Visibility.Hidden;
            Calc12.Visibility = Visibility.Hidden;
            Calc13.Visibility = Visibility.Hidden;
            Calc14.Visibility = Visibility.Hidden;
            Calc15.Visibility = Visibility.Hidden;






            dayInput.Visibility = Visibility.Hidden;
            mountInput.Visibility = Visibility.Hidden;
            yearInput.Visibility = Visibility.Hidden;
            hourInput.Visibility = Visibility.Hidden;
            minuteInput.Visibility = Visibility.Hidden;
            timesign.Visibility = Visibility.Hidden;
            Format.Visibility = Visibility.Hidden;
            cleardates.Visibility = Visibility.Hidden;
            MonthIsEnable.Visibility = Visibility.Hidden;
            dayIsEnable.Visibility = Visibility.Hidden;
            yearIsEnable.Visibility = Visibility.Hidden;


            HoursCalcs[0] = new HoursCalc();
            HoursCalcs[1] = new HoursCalc();
            HoursCalcs[2] = new HoursCalc();
            HoursCalcs[3] = new HoursCalc();
            HoursCalcs[4] = new HoursCalc();
            HoursCalcs[5] = new HoursCalc();
            HoursCalcs[6] = new HoursCalc();
            HoursCalcs[7] = new HoursCalc();
            HoursCalcs[8] = new HoursCalc();
            HoursCalcs[9] = new HoursCalc();
            HoursCalcs[10] = new HoursCalc();
            HoursCalcs[11] = new HoursCalc();
            HoursCalcs[12] = new HoursCalc();
            HoursCalcs[13] = new HoursCalc();
            HoursCalcs[14] = new HoursCalc();


            tempf = HoursCalc.LoadFromFile("data.xml");







        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {


            if (manually_chk.IsChecked == true)
            {
                if ((minuteInput.Text == "" || hourInput.Text == "" || yearInput.Text == "" || mountInput.Text == "" || dayInput.Text == ""))
                {
                    minuteInput.Clear();
                    hourInput.Clear();
                    //  mountInput.Clear();
                    // dayInput.Clear();
                    MessageBox.Show("שדות הזמן והתאריך אינם יכולים להיות ריקים", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

                }

                else

                {
                    if (int.Parse(minuteInput.Text.ToString()) > 59 || int.Parse(minuteInput.Text.ToString()) < 0)
                    {
                        minuteInput.Clear();
                        // hourInput.Clear();
                        //mountInput.Clear();
                        //dayInput.Clear();
                        MessageBox.Show("בבקשה הכנס דקת בפורמט נכון", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    if (int.Parse(hourInput.Text.ToString()) > 23 || int.Parse(hourInput.Text.ToString()) < 0)
                    {
                        // minuteInput.Clear();
                        hourInput.Clear();
                        // mountInput.Clear();
                        // dayInput.Clear();
                        MessageBox.Show("בבקשה הכנס שעה בפורמט נכון", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    if (int.Parse(mountInput.Text.ToString()) > 13 || int.Parse(mountInput.Text.ToString()) < 1)
                    {
                        mountInput.Clear();
                        MessageBox.Show("בבקשה הכנס חודש בפורמט נכון", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    if (int.Parse(dayInput.Text.ToString()) > 31 || int.Parse(dayInput.Text.ToString()) < 1)
                    {


                        dayInput.Clear();
                        MessageBox.Show("בבקשה הכנס יום בפורמט נכון", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    if (int.Parse(yearInput.Text.ToString()) > 3000 || int.Parse(yearInput.Text.ToString()) < 1980)
                    {


                        yearInput.Clear();
                        MessageBox.Show("בבקשה הכנס שנה בין 1980 לבין 3000", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }



                    DateTime time = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    DateTime CurrentTime = DateTime.Now;
                    if (time > CurrentTime)
                    {
                        hourInput.Clear();
                        mountInput.Clear();
                        dayInput.Clear();
                        minuteInput.Clear();
                        hourInput.Clear();
                        mountInput.Clear();
                        dayInput.Clear();
                        yearInput.Clear();
                        MessageBox.Show("הזמן שהוכנס צריך להיות בעבר", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }



                }


            }


            ///Check if the time is not the future
            ///






            CheckBox tem = sender as CheckBox;

            string n = tem.Name;

            switch (n)
            {
                case "chk":
                    Calc.Visibility = Visibility.Visible;
                    open.Visibility = Visibility.Hidden;

                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[0].DateStart[0] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[0].DateStart[0] = DateTime.Now;
                    clock.Content = HoursCalcs[0].DateStart[0];
                    HoursCalcs[0].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet1 = (bool)chk.IsChecked;
                    Settings1.Default.clockSet1 = tempf.DateStart[0];
                    Settings1.Default.Save();

                    break;
                case "chk2":
                    Calc2.Visibility = Visibility.Visible;
                    open2.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[1].DateStart[1] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[1].DateStart[1] = DateTime.Now;
                    clock2.Content = HoursCalcs[1].DateStart[1];
                    HoursCalcs[1].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet2 = (bool)chk2.IsChecked;
                    Settings1.Default.clockSet2 = tempf.DateStart[1];
                    Settings1.Default.Save();

                    break;
                case "chk3":
                    Calc3.Visibility = Visibility.Visible;
                    open3.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[2].DateStart[2] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[2].DateStart[2] = DateTime.Now;
                    clock3.Content = HoursCalcs[2].DateStart[2];
                    HoursCalcs[2].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet3 = (bool)chk3.IsChecked;
                    Settings1.Default.clockSet3 = tempf.DateStart[2];
                    Settings1.Default.Save();
                    break;
                case "chk4":
                    Calc4.Visibility = Visibility.Visible;
                    open4.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[3].DateStart[3] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[3].DateStart[3] = DateTime.Now;
                    clock4.Content = HoursCalcs[3].DateStart[3];
                    HoursCalcs[3].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet4 = (bool)chk4.IsChecked;
                    Settings1.Default.clockSet4 = tempf.DateStart[3];
                    Settings1.Default.Save();

                    break;
                case "chk5":
                    Calc5.Visibility = Visibility.Visible;
                    open5.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[4].DateStart[4] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[4].DateStart[4] = DateTime.Now;
                    clock5.Content = HoursCalcs[4].DateStart[4];
                    HoursCalcs[4].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet5 = (bool)chk5.IsChecked;
                    Settings1.Default.clockSet5 = tempf.DateStart[4];
                    Settings1.Default.Save();
                    break;
                case "chk6":
                    Calc6.Visibility = Visibility.Visible;
                    open6.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[5].DateStart[5] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[5].DateStart[5] = DateTime.Now;
                    clock6.Content = HoursCalcs[5].DateStart[5];
                    HoursCalcs[5].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet6 = (bool)chk6.IsChecked;
                    Settings1.Default.clockSet6 = tempf.DateStart[5];
                    Settings1.Default.Save();
                    break;
                case "chk7":
                    Calc7.Visibility = Visibility.Visible;
                    open7.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[6].DateStart[6] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[6].DateStart[6] = DateTime.Now;
                    clock7.Content = HoursCalcs[6].DateStart[6];
                    HoursCalcs[6].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet7 = (bool)chk7.IsChecked;
                    Settings1.Default.clockSet7 = tempf.DateStart[6];
                    Settings1.Default.Save();
                    break;
                case "chk8":
                    Calc8.Visibility = Visibility.Visible;
                    open8.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[7].DateStart[7] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[7].DateStart[7] = DateTime.Now;
                    clock8.Content = HoursCalcs[7].DateStart[7];
                    HoursCalcs[7].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet8 = (bool)chk8.IsChecked;
                    Settings1.Default.clockSet8 = tempf.DateStart[7];
                    Settings1.Default.Save();
                    break;

                case "chk9":
                    Calc9.Visibility = Visibility.Visible;
                    open9.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[8].DateStart[8] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[8].DateStart[8] = DateTime.Now;
                    clock9.Content = HoursCalcs[8].DateStart[8];
                    HoursCalcs[8].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet9 = (bool)chk9.IsChecked;
                    Settings1.Default.clockSet9 = tempf.DateStart[8];
                    Settings1.Default.Save();
                    break;

                case "chk10":
                    Calc10.Visibility = Visibility.Visible;
                    open10.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[9].DateStart[9] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[9].DateStart[9] = DateTime.Now;
                    clock10.Content = HoursCalcs[9].DateStart[9];
                    HoursCalcs[9].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet10 = (bool)chk10.IsChecked;
                    Settings1.Default.clockSet10 = tempf.DateStart[9];
                    Settings1.Default.Save();
                    break;

                case "chk11":
                    Calc11.Visibility = Visibility.Visible;
                    open11.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[10].DateStart[10] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[10].DateStart[10] = DateTime.Now;
                    clock11.Content = HoursCalcs[10].DateStart[10];
                    HoursCalcs[10].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet11 = (bool)chk11.IsChecked;
                    Settings1.Default.clockSet11 = tempf.DateStart[10];
                    Settings1.Default.Save();
                    break;

                case "chk12":
                    Calc12.Visibility = Visibility.Visible;
                    open12.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[11].DateStart[11] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[11].DateStart[11] = DateTime.Now;
                    clock12.Content = HoursCalcs[11].DateStart[11];
                    HoursCalcs[11].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet12 = (bool)chk12.IsChecked;
                    Settings1.Default.clockSet12 = tempf.DateStart[11];
                    Settings1.Default.Save();
                    break;

                case "chk13":
                    Calc13.Visibility = Visibility.Visible;
                    open13.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[12].DateStart[12] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[12].DateStart[12] = DateTime.Now;
                    clock13.Content = HoursCalcs[12].DateStart[12];
                    HoursCalcs[12].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet13 = (bool)chk13.IsChecked;
                    Settings1.Default.clockSet13 = tempf.DateStart[12];
                    Settings1.Default.Save();
                    break;

                case "chk14":
                    Calc14.Visibility = Visibility.Visible;
                    open14.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[13].DateStart[13] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[13].DateStart[13] = DateTime.Now;
                    clock14.Content = HoursCalcs[13].DateStart[13];
                    HoursCalcs[13].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet14 = (bool)chk14.IsChecked;
                    Settings1.Default.clockSet14 = tempf.DateStart[13];
                    Settings1.Default.Save();
                    break;





                case "chk15":
                    Calc15.Visibility = Visibility.Visible;
                    open15.Visibility = Visibility.Hidden;
                    if (minuteInput.Text != "" && hourInput.Text != "" && yearInput.Text != "" && mountInput.Text != "" && dayInput.Text != "" && manually_chk.IsChecked == true)
                        HoursCalcs[14].DateStart[14] = new DateTime(int.Parse(yearInput.Text), int.Parse(mountInput.Text), int.Parse(dayInput.Text), int.Parse(hourInput.Text), int.Parse(minuteInput.Text), 00);
                    else
                        HoursCalcs[14].DateStart[14] = DateTime.Now;
                    clock15.Content = HoursCalcs[14].DateStart[14];
                    HoursCalcs[14].Save("data.xml");
                    if (restorable == false)
                        return;
                    Settings1.Default.chkSet15 = (bool)chk15.IsChecked;
                    Settings1.Default.clockSet15 = tempf.DateStart[14];
                    Settings1.Default.Save();
                    break;


                default: break;
            }






        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {

            CheckBox tem = sender as CheckBox;

            string n = tem.Name;

            switch (n)
            {

                case "chk":
                    txt.Visibility = Visibility.Visible;
                    add1.Visibility = Visibility.Visible;
                    sub1.Visibility = Visibility.Visible;
                    open.Visibility = Visibility.Visible;
                    Calc.Visibility = Visibility.Hidden;
                    tot.Content = 0;
                    HoursCalcs[0].Sum[0] = 0;
                    clock.Content = DateTime.Today;
                    HoursCalcs[0].Save("data.xml");
                    Calc.IsEnabled = true;
                    Settings1.Default.calsSet1 = true;
                    Settings1.Default.chkSet1 = (bool)chk.IsChecked;
                    Settings1.Default.Save();
                    break;
                case "chk2":
                    txt2.Visibility = Visibility.Visible;
                    add2.Visibility = Visibility.Visible;
                    sub2.Visibility = Visibility.Visible;
                    open2.Visibility = Visibility.Visible;
                    Calc2.Visibility = Visibility.Hidden;
                    tot2.Content = 0;
                    HoursCalcs[1].Sum[1] = 0;
                    clock2.Content = DateTime.Today;
                    HoursCalcs[1].Save("data.xml");
                    Calc2.IsEnabled = true;
                    Settings1.Default.calsSet2 = true;
                    Settings1.Default.chkSet2 = (bool)chk2.IsChecked;
                    Settings1.Default.Save();


                    // Settings1.Default.Save();

                    break;
                case "chk3":
                    txt3.Visibility = Visibility.Visible;
                    add3.Visibility = Visibility.Visible;
                    sub3.Visibility = Visibility.Visible;
                    open3.Visibility = Visibility.Visible;
                    Calc3.Visibility = Visibility.Hidden;
                    tot3.Content = 0;
                    HoursCalcs[2].Sum[2] = 0;
                    clock3.Content = DateTime.Today;
                    HoursCalcs[2].Save("data.xml");
                    Calc3.IsEnabled = true;
                    Settings1.Default.calsSet3 = true;
                    Settings1.Default.chkSet3 = (bool)chk3.IsChecked;

                    Settings1.Default.Save();

                    break;
                case "chk4":
                    txt4.Visibility = Visibility.Visible;
                    add4.Visibility = Visibility.Visible;
                    sub4.Visibility = Visibility.Visible;
                    open4.Visibility = Visibility.Visible;
                    Calc4.Visibility = Visibility.Hidden;
                    tot4.Content = 0;
                    HoursCalcs[3].Sum[3] = 0;
                    clock4.Content = DateTime.Today;
                    HoursCalcs[3].Save("data.xml");
                    Calc4.IsEnabled = true;
                    Settings1.Default.calsSet4 = true;
                    Settings1.Default.chkSet4 = (bool)chk4.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk5":
                    txt5.Visibility = Visibility.Visible;
                    add5.Visibility = Visibility.Visible;
                    sub5.Visibility = Visibility.Visible;
                    open5.Visibility = Visibility.Visible;
                    Calc5.Visibility = Visibility.Hidden;
                    tot5.Content = 0;
                    HoursCalcs[4].Sum[4] = 0;
                    clock5.Content = DateTime.Today;
                    HoursCalcs[4].Save("data.xml");
                    Calc5.IsEnabled = true;
                    Settings1.Default.calsSet5 = true;
                    Settings1.Default.chkSet5 = (bool)chk5.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk6":
                    txt6.Visibility = Visibility.Visible;
                    add6.Visibility = Visibility.Visible;
                    sub6.Visibility = Visibility.Visible;
                    open6.Visibility = Visibility.Visible;
                    Calc6.Visibility = Visibility.Hidden;
                    tot6.Content = 0;
                    HoursCalcs[5].Sum[5] = 0;
                    clock6.Content = DateTime.Today;
                    HoursCalcs[5].Save("data.xml");
                    Calc6.IsEnabled = true;
                    Settings1.Default.calsSet6 = true;
                    Settings1.Default.chkSet6 = (bool)chk6.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk7":
                    txt7.Visibility = Visibility.Visible;
                    add7.Visibility = Visibility.Visible;
                    sub7.Visibility = Visibility.Visible;
                    open7.Visibility = Visibility.Visible;
                    Calc7.Visibility = Visibility.Hidden;
                    tot7.Content = 0;
                    HoursCalcs[6].Sum[6] = 0;
                    clock7.Content = DateTime.Today;
                    HoursCalcs[6].Save("data.xml");
                    Calc7.IsEnabled = true;
                    Settings1.Default.calsSet7 = true;
                    Settings1.Default.chkSet7 = (bool)chk7.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk8":
                    txt8.Visibility = Visibility.Visible;
                    add8.Visibility = Visibility.Visible;
                    sub8.Visibility = Visibility.Visible;
                    open8.Visibility = Visibility.Visible;
                    Calc8.Visibility = Visibility.Hidden;
                    tot8.Content = 0;
                    HoursCalcs[7].Sum[7] = 0;
                    clock8.Content = DateTime.Today;
                    HoursCalcs[7].Save("data.xml");
                    Calc8.IsEnabled = true;
                    Settings1.Default.calsSet8 = true;
                    Settings1.Default.chkSet8 = (bool)chk8.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk9":
                    txt9.Visibility = Visibility.Visible;
                    add9.Visibility = Visibility.Visible;
                    sub9.Visibility = Visibility.Visible;
                    open9.Visibility = Visibility.Visible;
                    Calc9.Visibility = Visibility.Hidden;
                    tot9.Content = 0;
                    HoursCalcs[8].Sum[8] = 0;
                    clock9.Content = DateTime.Today;
                    HoursCalcs[8].Save("data.xml");
                    Calc9.IsEnabled = true;
                    Settings1.Default.calsSet9 = true;
                    Settings1.Default.chkSet9 = (bool)chk9.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk10":
                    txt10.Visibility = Visibility.Visible;
                    add10.Visibility = Visibility.Visible;
                    sub10.Visibility = Visibility.Visible;
                    open10.Visibility = Visibility.Visible;
                    Calc10.Visibility = Visibility.Hidden;
                    tot10.Content = 0;
                    HoursCalcs[9].Sum[9] = 0;
                    clock10.Content = DateTime.Today;
                    HoursCalcs[9].Save("data.xml");
                    Calc10.IsEnabled = true;
                    Settings1.Default.calsSet10 = true;
                    Settings1.Default.chkSet10 = (bool)chk10.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk11":
                    txt11.Visibility = Visibility.Visible;
                    add11.Visibility = Visibility.Visible;
                    sub11.Visibility = Visibility.Visible;
                    open11.Visibility = Visibility.Visible;
                    Calc11.Visibility = Visibility.Hidden;
                    tot11.Content = 0;
                    HoursCalcs[10].Sum[10] = 0;
                    clock11.Content = DateTime.Today;
                    HoursCalcs[10].Save("data.xml");
                    Calc11.IsEnabled = true;
                    Settings1.Default.calsSet11 = true;
                    Settings1.Default.chkSet11 = (bool)chk11.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk12":
                    txt12.Visibility = Visibility.Visible;
                    add12.Visibility = Visibility.Visible;
                    sub12.Visibility = Visibility.Visible;
                    open12.Visibility = Visibility.Visible;
                    Calc12.Visibility = Visibility.Hidden;
                    tot12.Content = 0;
                    HoursCalcs[11].Sum[11] = 0;
                    clock12.Content = DateTime.Today;
                    HoursCalcs[11].Save("data.xml");
                    Calc12.IsEnabled = true;
                    Settings1.Default.calsSet12 = true;
                    Settings1.Default.chkSet12 = (bool)chk12.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk13":
                    txt13.Visibility = Visibility.Visible;
                    add13.Visibility = Visibility.Visible;
                    sub13.Visibility = Visibility.Visible;
                    open13.Visibility = Visibility.Visible;
                    Calc13.Visibility = Visibility.Hidden;
                    tot13.Content = 0;
                    HoursCalcs[12].Sum[12] = 0;
                    clock13.Content = DateTime.Today;
                    HoursCalcs[12].Save("data.xml");
                    Calc13.IsEnabled = true;
                    Settings1.Default.calsSet13 = true;
                    Settings1.Default.chkSet13 = (bool)chk13.IsChecked;
                    Settings1.Default.Save();

                    break;
                case "chk14":
                    txt14.Visibility = Visibility.Visible;
                    add14.Visibility = Visibility.Visible;
                    sub14.Visibility = Visibility.Visible;
                    open14.Visibility = Visibility.Visible;
                    Calc14.Visibility = Visibility.Hidden;
                    tot14.Content = 0;
                    HoursCalcs[13].Sum[13] = 0;
                    clock14.Content = DateTime.Today;
                    HoursCalcs[13].Save("data.xml");
                    Calc14.IsEnabled = true;
                    Settings1.Default.calsSet14 = true;
                    Settings1.Default.chkSet14 = (bool)chk14.IsChecked;
                    Settings1.Default.Save();
                    break;

                case "chk15":
                    txt15.Visibility = Visibility.Visible;
                    add15.Visibility = Visibility.Visible;
                    sub15.Visibility = Visibility.Visible;
                    open15.Visibility = Visibility.Visible;
                    Calc15.Visibility = Visibility.Hidden;
                    tot15.Content = 0;
                    HoursCalcs[14].Sum[14] = 0;
                    clock15.Content = DateTime.Today;
                    HoursCalcs[14].Save("data.xml");
                    Calc15.IsEnabled = true;
                    Settings1.Default.calsSet15 = true;
                    Settings1.Default.chkSet15 = (bool)chk15.IsChecked;
                    Settings1.Default.Save();
                    break;

                default: break;
            }
            Settings1.Default.Save();






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // temp.DateEnd = DateTime.Now;


            Button tem = sender as Button;

            string n = tem.Name;

            switch (n)
            {

                case "Calc":

                    HoursCalcs[0].DateEnd[0] = DateTime.Now;
                    tot.Content = HoursCalc.Func1(HoursCalcs[0].DateStart[0], HoursCalcs[0].DateEnd[0]) + HoursCalcs[0].Sum[0];
                    HoursCalcs[0].Sum[0] = (float)tot.Content;
                    txt.Visibility = Visibility.Hidden;
                    add1.Visibility = Visibility.Hidden;
                    sub1.Visibility = Visibility.Hidden;
                    Calc.Visibility = Visibility.Hidden;
                    HoursCalcs[0].Save("data.xml");
                    Settings1.Default.calsSet1 = false;
                    HoursCalcs[0].Sum[0] = 0;

                    break;
                case "Calc2":
                    txt2.Visibility = Visibility.Hidden;
                    add2.Visibility = Visibility.Hidden;
                    HoursCalcs[1].DateEnd[1] = DateTime.Now;
                    tot2.Content = HoursCalc.Func1(HoursCalcs[1].DateStart[1], HoursCalcs[1].DateEnd[1]) + HoursCalcs[1].Sum[1];
                    HoursCalcs[1].Sum[1] = (float)tot2.Content;
                    sub2.Visibility = Visibility.Hidden;
                    Calc2.Visibility = Visibility.Hidden;
                    HoursCalcs[1].Save("data.xml");
                    Settings1.Default.calsSet2 = false;
                    HoursCalcs[1].Sum[1] = 0;

                    break;
                case "Calc3":
                    txt3.Visibility = Visibility.Hidden;
                    add3.Visibility = Visibility.Hidden;
                    HoursCalcs[2].DateEnd[2] = DateTime.Now;
                    tot3.Content = HoursCalc.Func1(HoursCalcs[2].DateStart[2], HoursCalcs[2].DateEnd[2]) + HoursCalcs[2].Sum[2];
                    HoursCalcs[2].Sum[2] = (float)tot3.Content;
                    sub3.Visibility = Visibility.Hidden;
                    Calc3.Visibility = Visibility.Hidden;
                    HoursCalcs[2].Save("data.xml");
                    Settings1.Default.calsSet3 = false;
                    HoursCalcs[2].Sum[2] = 0;

                    break;
                case "Calc4":
                    txt4.Visibility = Visibility.Hidden;
                    add4.Visibility = Visibility.Hidden;
                    HoursCalcs[3].DateEnd[3] = DateTime.Now;
                    tot4.Content = HoursCalc.Func1(HoursCalcs[3].DateStart[3], HoursCalcs[3].DateEnd[3]) + HoursCalcs[3].Sum[3];
                    HoursCalcs[3].Sum[3] = (float)tot4.Content;
                    sub4.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet4 = false;
                    Calc4.Visibility = Visibility.Hidden;
                    HoursCalcs[3].Save("data.xml");
                    HoursCalcs[3].Sum[3] = 0;
                    break;
                case "Calc5":
                    txt5.Visibility = Visibility.Hidden;
                    add5.Visibility = Visibility.Hidden;
                    HoursCalcs[4].DateEnd[4] = DateTime.Now;
                    tot5.Content = HoursCalc.Func1(HoursCalcs[4].DateStart[4], HoursCalcs[4].DateEnd[4]) + HoursCalcs[4].Sum[4];
                    HoursCalcs[4].Sum[4] = (float)tot5.Content;
                    sub5.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet5 = false;
                    Calc5.Visibility = Visibility.Hidden;
                    HoursCalcs[4].Save("data.xml");
                    HoursCalcs[4].Sum[4] = 0;
                    break;
                case "Calc6":
                    txt6.Visibility = Visibility.Hidden;
                    add6.Visibility = Visibility.Hidden;
                    HoursCalcs[5].DateEnd[5] = DateTime.Now;
                    tot6.Content = HoursCalc.Func1(HoursCalcs[5].DateStart[5], HoursCalcs[5].DateEnd[5]) + HoursCalcs[5].Sum[5];
                    HoursCalcs[5].Sum[5] = (float)tot6.Content;
                    sub6.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet6 = false;
                    Calc6.Visibility = Visibility.Hidden;
                    HoursCalcs[5].Save("data.xml");
                    HoursCalcs[5].Sum[5] = 0;
                    break;
                case "Calc7":
                    txt7.Visibility = Visibility.Hidden;
                    add7.Visibility = Visibility.Hidden;
                    HoursCalcs[6].DateEnd[6] = DateTime.Now;
                    tot7.Content = HoursCalc.Func1(HoursCalcs[6].DateStart[6], HoursCalcs[6].DateEnd[6]) + HoursCalcs[6].Sum[6];
                    HoursCalcs[6].Sum[6] = (float)tot7.Content;
                    sub7.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet7 = false;
                    Calc7.Visibility = Visibility.Hidden;
                    HoursCalcs[6].Save("data.xml");
                    HoursCalcs[6].Sum[6] = 0;
                    break;
                case "Calc8":
                    txt8.Visibility = Visibility.Hidden;
                    add8.Visibility = Visibility.Hidden;
                    HoursCalcs[7].DateEnd[7] = DateTime.Now;
                    tot8.Content = HoursCalc.Func1(HoursCalcs[7].DateStart[7], HoursCalcs[7].DateEnd[7]) + HoursCalcs[7].Sum[7];
                    HoursCalcs[7].Sum[7] = (float)tot8.Content;
                    sub8.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet8 = false;
                    Calc8.Visibility = Visibility.Hidden;
                    HoursCalcs[7].Save("data.xml");
                    HoursCalcs[7].Sum[7] = 0;
                    break;
                case "Calc9":
                    txt9.Visibility = Visibility.Hidden;
                    add9.Visibility = Visibility.Hidden;
                    HoursCalcs[8].DateEnd[8] = DateTime.Now;
                    tot9.Content = HoursCalc.Func1(HoursCalcs[8].DateStart[8], HoursCalcs[8].DateEnd[8]) + HoursCalcs[8].Sum[8];
                    HoursCalcs[8].Sum[8] = (float)tot9.Content;
                    sub9.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet9 = false;
                    Calc9.Visibility = Visibility.Hidden;
                    HoursCalcs[8].Save("data.xml");
                    HoursCalcs[8].Sum[8] = 0;
                    break;
                case "Calc10":
                    txt10.Visibility = Visibility.Hidden;
                    add10.Visibility = Visibility.Hidden;
                    HoursCalcs[9].DateEnd[9] = DateTime.Now;
                    tot10.Content = HoursCalc.Func1(HoursCalcs[9].DateStart[9], HoursCalcs[9].DateEnd[9]) + HoursCalcs[9].Sum[9];
                    HoursCalcs[9].Sum[9] = (float)tot10.Content;
                    sub10.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet10 = false;
                    Calc10.Visibility = Visibility.Hidden;
                    HoursCalcs[9].Save("data.xml");
                    HoursCalcs[9].Sum[9] = 0;
                    break;
                case "Calc11":
                    txt11.Visibility = Visibility.Hidden;
                    add11.Visibility = Visibility.Hidden;
                    HoursCalcs[10].DateEnd[10] = DateTime.Now;
                    tot11.Content = HoursCalc.Func1(HoursCalcs[10].DateStart[10], HoursCalcs[10].DateEnd[10]) + HoursCalcs[10].Sum[10];
                    HoursCalcs[10].Sum[10] = (float)tot11.Content;
                    sub11.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet11 = false;
                    Calc11.Visibility = Visibility.Hidden;
                    HoursCalcs[10].Save("data.xml");
                    HoursCalcs[10].Sum[10] = 0;
                    break;
                case "Calc12":
                    txt12.Visibility = Visibility.Hidden;
                    add12.Visibility = Visibility.Hidden;
                    HoursCalcs[11].DateEnd[11] = DateTime.Now;
                    tot12.Content = HoursCalc.Func1(HoursCalcs[11].DateStart[11], HoursCalcs[11].DateEnd[11]) + HoursCalcs[11].Sum[11];
                    HoursCalcs[11].Sum[11] = (float)tot12.Content;
                    sub12.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet12 = false;
                    Calc12.Visibility = Visibility.Hidden;
                    HoursCalcs[11].Save("data.xml");
                    HoursCalcs[11].Sum[11] = 0;
                    break;
                case "Calc13":
                    txt13.Visibility = Visibility.Hidden;
                    add13.Visibility = Visibility.Hidden;
                    HoursCalcs[12].DateEnd[12] = DateTime.Now;
                    tot13.Content = HoursCalc.Func1(HoursCalcs[12].DateStart[12], HoursCalcs[12].DateEnd[12]) + HoursCalcs[12].Sum[12];
                    HoursCalcs[12].Sum[12] = (float)tot13.Content;
                    sub13.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet13 = false;
                    Calc13.Visibility = Visibility.Hidden;
                    HoursCalcs[12].Save("data.xml");
                    HoursCalcs[12].Sum[12] = 0;
                    break;
                case "Calc14":
                    txt14.Visibility = Visibility.Hidden;
                    add14.Visibility = Visibility.Hidden;
                    HoursCalcs[13].DateEnd[13] = DateTime.Now;
                    tot14.Content = HoursCalc.Func1(HoursCalcs[13].DateStart[13], HoursCalcs[13].DateEnd[13]) + HoursCalcs[13].Sum[13];
                    HoursCalcs[13].Sum[13] = (float)tot14.Content;
                    sub14.Visibility = Visibility.Hidden;
                    Settings1.Default.calsSet14 = false;
                    Calc14.Visibility = Visibility.Hidden;
                    HoursCalcs[13].Save("data.xml");
                    HoursCalcs[13].Sum[13] = 0;
                    break;
                case "Calc15":
                    HoursCalcs[14].DateEnd[14] = DateTime.Now;
                    tot15.Content = HoursCalc.Func2(HoursCalcs[14].DateStart[14], HoursCalcs[14].DateEnd[14]) + HoursCalcs[14].Sum[14];
                    HoursCalcs[14].Sum[14] = (float)tot15.Content;
                    txt15.Visibility = Visibility.Hidden;
                    add15.Visibility = Visibility.Hidden;
                    sub15.Visibility = Visibility.Hidden;
                    Calc15.Visibility = Visibility.Hidden;
                    HoursCalcs[14].Save("data.xml");
                    HoursCalcs[14].Sum[14] = 0;
                    Settings1.Default.calsSet14 = false;
                    break;
                default: break;
            }

            Settings1.Default.Save();



        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            TextBox text = sender as TextBox;
            string n = text.Name;


            switch (n)
            {

                case "txt":
                    a = txt.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt2":
                    a = txt2.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt3":
                    a = txt3.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt4":
                    a = txt4.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt5":
                    a = txt5.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt6":
                    a = txt6.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt7":
                    a = txt7.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt8":
                    a = txt8.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt9":
                    a = txt9.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt10":
                    a = txt10.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt11":
                    a = txt11.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt12":
                    a = txt12.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt13":
                    a = txt13.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt14":
                    a = txt14.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                case "txt15":
                    a = txt15.Text.ToString();
                    if (a != "")
                        x = float.Parse(a);
                    else x = 0;
                    break;
                default: break;
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            Button button = sender as Button;
            string n = button.Name;


            switch (n)
            {

                case "add1":
                    HoursCalcs[0].Sum[0] += x;
                    tot.Content = HoursCalcs[0].Sum[0];
                    txt.Clear();
                    HoursCalcs[0].Save("data.xml");
                    break;
                case "add2":
                    HoursCalcs[1].Sum[1] += x;
                    tot2.Content = HoursCalcs[1].Sum[1];
                    txt2.Clear();
                    HoursCalcs[1].Save("data.xml");

                    break;
                case "add3":
                    HoursCalcs[2].Sum[2] += x;
                    tot3.Content = HoursCalcs[2].Sum[2];
                    txt3.Clear();
                    HoursCalcs[2].Save("data.xml");
                    break;
                case "add4":
                    HoursCalcs[3].Sum[3] += x;
                    tot4.Content = HoursCalcs[3].Sum[3];
                    txt4.Clear();
                    HoursCalcs[3].Save("data.xml");
                    break;
                case "add5":
                    HoursCalcs[4].Sum[4] += x;
                    tot5.Content = HoursCalcs[4].Sum[4];
                    txt5.Clear();
                    HoursCalcs[4].Save("data.xml");
                    break;
                case "add6":
                    HoursCalcs[5].Sum[5] += x;
                    tot6.Content = HoursCalcs[5].Sum[5];
                    txt6.Clear();
                    HoursCalcs[5].Save("data.xml");
                    break;
                case "add7":
                    HoursCalcs[6].Sum[6] += x;
                    tot7.Content = HoursCalcs[6].Sum[6];
                    txt7.Clear();
                    HoursCalcs[6].Save("data.xml");
                    break;
                case "add8":
                    HoursCalcs[7].Sum[7] += x;
                    tot8.Content = HoursCalcs[7].Sum[7];
                    txt8.Clear();
                    HoursCalcs[7].Save("data.xml");
                    break;
                case "add9":
                    HoursCalcs[8].Sum[8] += x;
                    tot9.Content = HoursCalcs[8].Sum[8];
                    txt9.Clear();
                    HoursCalcs[8].Save("data.xml");
                    break;
                case "add10":
                    HoursCalcs[9].Sum[9] += x;
                    tot10.Content = HoursCalcs[9].Sum[9];
                    txt10.Clear();
                    HoursCalcs[9].Save("data.xml");
                    break;
                case "add11":
                    HoursCalcs[10].Sum[10] += x;
                    tot11.Content = HoursCalcs[10].Sum[10];
                    txt11.Clear();
                    HoursCalcs[10].Save("data.xml");
                    break;
                case "add12":
                    HoursCalcs[11].Sum[11] += x;
                    tot12.Content = HoursCalcs[11].Sum[11];
                    txt12.Clear();
                    HoursCalcs[11].Save("data.xml");
                    break;
                case "add13":
                    HoursCalcs[12].Sum[12] += x;
                    tot13.Content = HoursCalcs[12].Sum[12];
                    txt13.Clear();
                    HoursCalcs[12].Save("data.xml");
                    break;
                case "add14":
                    HoursCalcs[13].Sum[13] += x;
                    tot14.Content = HoursCalcs[13].Sum[13];
                    txt14.Clear();
                    HoursCalcs[13].Save("data.xml");
                    break;
                case "add15":
                    HoursCalcs[14].Sum[14] += x;
                    tot15.Content = HoursCalcs[14].Sum[14];
                    txt15.Clear();
                    HoursCalcs[14].Save("data.xml");
                    break;
                default: break;
            }


            x = 0;
        }



        private void txt_preview(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+");

            if (e.Text.ToString() == ".")
                e.Handled = false;
            else
                e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text == null) return;
            if (e == null) return;

            //allow get out of the text box
            if (e.Key == Key.Enter)
            {


                Button button = sender as Button;
                string n = text.Name;


                switch (n)
                {

                    case "txt":

                        add1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt2":

                        add2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));


                        break;
                    case "txt3":

                        add3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;
                    case "txt4":
                        add4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;
                    case "txt5":
                        add5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt6":
                        add6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt7":
                        add7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt8":
                        add8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt9":
                        add9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt10":
                        add10.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt11":
                        add11.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt12":
                        add12.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt13":
                        add13.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt14":
                        add14.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        break;
                    case "txt15":
                        add15.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;
                    default: break;
                }





                return;

            }
            if (e.Key == Key.Return || e.Key == Key.Tab)
                return;

            //allow list of system keys (add other key here if you want to allow)
            if (e.Key == Key.Escape || e.Key == Key.Back || e.Key == Key.Delete ||
                e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.Home
             || e.Key == Key.End || e.Key == Key.Insert || e.Key == Key.Down || e.Key == Key.Right)
                return;
            if (e.Key == Key.Space)
            {
                e.Handled = true;

                return;
            }

            //if(e.Key == Key.Subtract)
            //{
            //    e.Source = 0;
            //    e.Handled = false;
            //    return;
            //}
            if (e.Key == Key.Decimal)
            {
                e.Handled = false;
                return;

            }

            //char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);

            //allow control system keys
            // if (Char.IsControl(c)) return;

            //allow digits (without Shift or Alt)
            //if (Char.IsDigit(c))
            if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))
                return; //let this key be written inside the textbox


            //forbid letters and signs (#,$, %, ...)
            // e.Handled = true; //ignore this key. mark event as handled, will not be routed to other controls
            // return;
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Source.ToString());
            return;


        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {


            dayInput.Visibility = Visibility.Visible;
            mountInput.Visibility = Visibility.Visible;
            yearInput.Visibility = Visibility.Visible;
            hourInput.Visibility = Visibility.Visible;
            minuteInput.Visibility = Visibility.Visible;
            timesign.Visibility = Visibility.Visible;
            Format.Visibility = Visibility.Visible;
            cleardates.Visibility = Visibility.Visible;
            MonthIsEnable.Visibility = Visibility.Visible;
            dayIsEnable.Visibility = Visibility.Visible;
            yearIsEnable.Visibility = Visibility.Visible;


            yearIsEnable.IsChecked = Settings1.Default.yearcheck;
            yearInput.Text = Settings1.Default.yearInput;

            MonthIsEnable.IsChecked = Settings1.Default.monthcheck;
            mountInput.Text = Settings1.Default.monthInput;

            dayIsEnable.IsChecked = Settings1.Default.daycheck;
            dayInput.Text = Settings1.Default.dayInput;

            flag = true;

        }

        /// <summary>
        /// Clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            hourInput.Clear();
            minuteInput.Clear();

        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {

            dayInput.Visibility = Visibility.Hidden;
            mountInput.Visibility = Visibility.Hidden;
            yearInput.Visibility = Visibility.Hidden;
            hourInput.Visibility = Visibility.Hidden;
            minuteInput.Visibility = Visibility.Hidden;
            timesign.Visibility = Visibility.Hidden;
            Format.Visibility = Visibility.Hidden;
            cleardates.Visibility = Visibility.Hidden;
            yearIsEnable.Visibility = Visibility.Hidden;
            MonthIsEnable.Visibility = Visibility.Hidden;
            dayIsEnable.Visibility = Visibility.Hidden;



        }

        private void sub1_Click(object sender, RoutedEventArgs e)
        {




            Button button = sender as Button;
            string n = button.Name;


            switch (n)
            {

                case "sub1":

                    HoursCalcs[0].Sum[0] -= x;
                    tot.Content = HoursCalcs[0].Sum[0];
                    txt.Clear();
                    HoursCalcs[0].Save("data.xml");
                    break;

                case "sub2":
                    HoursCalcs[1].Sum[1] -= x;
                    tot2.Content = HoursCalcs[1].Sum[1];
                    txt2.Clear();
                    HoursCalcs[1].Save("data.xml");
                    break;

                case "sub3":
                    HoursCalcs[2].Sum[2] -= x;
                    tot3.Content = HoursCalcs[2].Sum[2];
                    txt3.Clear();
                    HoursCalcs[2].Save("data.xml");
                    break;

                case "sub4":
                    HoursCalcs[3].Sum[3] -= x;
                    tot4.Content = HoursCalcs[3].Sum[3];
                    txt4.Clear();
                    HoursCalcs[3].Save("data.xml");
                    break;

                case "sub5":
                    HoursCalcs[4].Sum[4] -= x;
                    tot5.Content = HoursCalcs[4].Sum[4];
                    txt5.Clear();
                    HoursCalcs[4].Save("data.xml");
                    break;

                case "sub6":
                    HoursCalcs[5].Sum[5] -= x;
                    tot6.Content = HoursCalcs[5].Sum[5];
                    txt6.Clear();
                    HoursCalcs[5].Save("data.xml");
                    break;

                case "sub7":
                    HoursCalcs[6].Sum[6] -= x;
                    tot7.Content = HoursCalcs[6].Sum[6];
                    txt7.Clear();
                    HoursCalcs[6].Save("data.xml");
                    break;

                case "sub8":
                    HoursCalcs[7].Sum[7] -= x;
                    tot8.Content = HoursCalcs[7].Sum[7];
                    txt8.Clear();
                    HoursCalcs[7].Save("data.xml");
                    break;

                case "sub9":
                    HoursCalcs[8].Sum[8] -= x;
                    tot9.Content = HoursCalcs[8].Sum[8];
                    txt9.Clear();
                    HoursCalcs[8].Save("data.xml");
                    break;

                case "sub10":
                    HoursCalcs[9].Sum[9] -= x;
                    tot10.Content = HoursCalcs[9].Sum[9];
                    txt10.Clear();
                    HoursCalcs[9].Save("data.xml");
                    break;

                case "sub11":
                    HoursCalcs[10].Sum[10] -= x;
                    tot11.Content = HoursCalcs[10].Sum[10];
                    txt11.Clear();
                    HoursCalcs[10].Save("data.xml");
                    break;

                case "sub12":
                    HoursCalcs[11].Sum[11] -= x;
                    tot12.Content = HoursCalcs[11].Sum[11];
                    txt12.Clear();
                    HoursCalcs[11].Save("data.xml");
                    break;

                case "add13":
                    HoursCalcs[12].Sum[12] -= x;
                    tot13.Content = HoursCalcs[12].Sum[12];
                    txt13.Clear();
                    HoursCalcs[12].Save("data.xml");
                    break;

                case "sub14":
                    HoursCalcs[13].Sum[13] -= x;
                    tot14.Content = HoursCalcs[13].Sum[13];
                    txt14.Clear();
                    HoursCalcs[13].Save("data.xml");
                    break;
                case "sub15":

                    HoursCalcs[14].Sum[14] -= x;
                    tot14.Content = HoursCalcs[0].Sum[0];
                    txt14.Clear();
                    HoursCalcs[14].Save("data.xml");
                    break;
                default: break;
            }

            x = 0;

        }

        private void Button_Click_restor(object sender, RoutedEventArgs e)
        {
            restorable = false;

            chk.IsChecked = Settings1.Default.chkSet1;
            chk2.IsChecked = Settings1.Default.chkSet2;
            chk3.IsChecked = Settings1.Default.chkSet3;
            chk4.IsChecked = Settings1.Default.chkSet4;
            chk5.IsChecked = Settings1.Default.chkSet5;
            chk6.IsChecked = Settings1.Default.chkSet6;
            chk7.IsChecked = Settings1.Default.chkSet7;
            chk8.IsChecked = Settings1.Default.chkSet8;
            chk9.IsChecked = Settings1.Default.chkSet9;
            chk10.IsChecked = Settings1.Default.chkSet10;
            chk11.IsChecked = Settings1.Default.chkSet11;
            chk12.IsChecked = Settings1.Default.chkSet12;
            chk13.IsChecked = Settings1.Default.chkSet13;
            chk14.IsChecked = Settings1.Default.chkSet14;
            chk15.IsChecked = Settings1.Default.chkSet15;




            tempf.DateStart[0] = Settings1.Default.clockSet1;
            tempf.DateStart[1] = Settings1.Default.clockSet2;
            tempf.DateStart[2] = Settings1.Default.clockSet3;
            tempf.DateStart[3] = Settings1.Default.clockSet4;
            tempf.DateStart[4] = Settings1.Default.clockSet5;
            tempf.DateStart[5] = Settings1.Default.clockSet6;
            tempf.DateStart[6] = Settings1.Default.clockSet7;
            tempf.DateStart[7] = Settings1.Default.clockSet8;
            tempf.DateStart[8] = Settings1.Default.clockSet9;
            tempf.DateStart[9] = Settings1.Default.clockSet10;
            tempf.DateStart[10] = Settings1.Default.clockSet11;
            tempf.DateStart[11] = Settings1.Default.clockSet12;
            tempf.DateStart[12] = Settings1.Default.clockSet13;
            tempf.DateStart[13] = Settings1.Default.clockSet14;
            tempf.DateStart[14] = Settings1.Default.clockSet15;



            clock.Content = tempf.DateStart[0];
            clock2.Content = tempf.DateStart[1];
            clock3.Content = tempf.DateStart[2];
            clock4.Content = tempf.DateStart[3];
            clock5.Content = tempf.DateStart[4];
            clock6.Content = tempf.DateStart[5];
            clock7.Content = tempf.DateStart[6];
            clock8.Content = tempf.DateStart[7];
            clock9.Content = tempf.DateStart[8];
            clock10.Content = tempf.DateStart[9];
            clock11.Content = tempf.DateStart[10];
            clock12.Content = tempf.DateStart[11];
            clock13.Content = tempf.DateStart[12];
            clock14.Content = tempf.DateStart[13];
            clock15.Content = tempf.DateStart[14];


            tot.Content = tempf.Sum[0];
            tot2.Content = tempf.Sum[1];
            tot3.Content = tempf.Sum[2];
            tot4.Content = tempf.Sum[3];
            tot5.Content = tempf.Sum[4];
            tot6.Content = tempf.Sum[5];
            tot7.Content = tempf.Sum[6];
            tot8.Content = tempf.Sum[7];
            tot9.Content = tempf.Sum[8];
            tot10.Content = tempf.Sum[9];
            tot11.Content = tempf.Sum[10];
            tot12.Content = tempf.Sum[11];
            tot13.Content = tempf.Sum[12];
            tot14.Content = tempf.Sum[13];
            tot15.Content = tempf.Sum[14];


            Calc.IsEnabled = Settings1.Default.calsSet1;
            Calc2.IsEnabled = Settings1.Default.calsSet2;
            Calc3.IsEnabled = Settings1.Default.calsSet3;
            Calc4.IsEnabled = Settings1.Default.calsSet4;
            Calc5.IsEnabled = Settings1.Default.calsSet5;
            Calc6.IsEnabled = Settings1.Default.calsSet6;
            Calc7.IsEnabled = Settings1.Default.calsSet7;
            Calc8.IsEnabled = Settings1.Default.calsSet8;
            Calc9.IsEnabled = Settings1.Default.calsSet9;
            Calc10.IsEnabled = Settings1.Default.calsSet10;
            Calc11.IsEnabled = Settings1.Default.calsSet11;
            Calc12.IsEnabled = Settings1.Default.calsSet12;
            Calc13.IsEnabled = Settings1.Default.calsSet13;
            Calc14.IsEnabled = Settings1.Default.calsSet14;
            Calc15.IsEnabled = Settings1.Default.calsSet15;


            notes.Text = Settings1.Default.noteSet;


            restorable = true;



        }


        private void MonthIsEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.monthcheck = (bool)MonthIsEnable.IsChecked;
            if (MonthIsEnable.IsChecked.Value == false && flag)
                Settings1.Default.monthInput = mountInput.Text;
            Settings1.Default.Save();
        }

        private void dayIsEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.daycheck = (bool)dayIsEnable.IsChecked;
            if (dayIsEnable.IsChecked.Value == false && flag)
                Settings1.Default.dayInput = dayInput.Text;
            Settings1.Default.Save();
        }

        private void yearIsEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.yearcheck = (bool)yearIsEnable.IsChecked;
            if (yearIsEnable.IsChecked.Value == false && flag)
                Settings1.Default.yearInput = yearInput.Text;

            Settings1.Default.Save();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Settings1.Default.noteSet = notes.Text;
            Settings1.Default.Save();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Nav.Content = new Setting();
            if (Nav.Content != null)
            {
                Nav.Content = null;
                setPrice.Content ="פתח הגדרות" ;

            }
            else { setPrice.Content = "סגור הגדרות"; }


        }
    }
}
