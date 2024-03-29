using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SportBar_0.Core;

namespace SportBar_0
{
    /// <summary>
    /// This class represents the main window of the SportBar_0 application.
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

             // Initialize the user interface components defined in XAML.

            InitializeComponent();

            // Create a dispatcher timer for updating the digital clock every second.
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick; // Add event handler for timer tick
            timer.Start(); // Start the timer
        }



        /// <summary>
        /// Event handler for the timer tick event.
        /// Updates the content of the "digitalclock" element (likely a Label in XAML)
        /// with the current time in long time format (e.g., 10:30:25 PM).
        /// </summary>
        /// <param name="sender">The object that raised the event (the timer).</param>
        /// <param name="e">Event arguments (unused in this case).</param>
        void timer_Tick(object sender, EventArgs e)
        {
            digitalclock.Content = DateTime.Now.ToLongTimeString();
        }



        /// <summary>
        /// Event handler for the window's mouse move event.
        /// Allows the window to be dragged by the user if the left mouse button is pressed.
        /// </summary>
        /// <param name="sender">The object that raised the event (the window).</param>
        /// <param name="e">Event arguments containing mouse button information.</param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Allow dragging the window
            }
        }


        /// <summary>
        /// Event handler for the button click event.
        /// (This code snippet creates a new MainWindow instance and shuts down the current application.)
        /// Consider revising this behavior based on your intended functionality.
        /// </summary>
        /// <param name="sender">The object that raised the event (the button).</param>
        /// <param name="e">Event arguments (unused in this case).</param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Consider revising this behavior for a more appropriate action on button click.
            // For example, you might open a new window, navigate to a different view,
            // or perform some other task relevant to your application.

            // This code snippet currently creates a new MainWindow instance and shuts down the current application.

            MainWindow win1 = new MainWindow();
            Application.Current.Shutdown();
        }


    }
}




























            //   Loaded += new RoutedEventHandler(MainWindow_Loaded);
            //   Closing += new CancelEventHandler(MainWindow_Closing);

            //time1.Text = DateTime.Now.ToString();








            //win1.Show();
            //this.Close();












        //void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadExternalXaml();
        //}

        //void MainWindow_Closing(object sender, CancelEventArgs e)
        //{
        //    SaveExternalXaml();
        //}

        //public void LoadExternalXaml()
        //{
        //    if (File.Exists(@"C:\Test.xaml"))
        //    {
        //        using (FileStream stream = new FileStream(@"C:\Test.xaml", FileMode.Open))
        //        {
        //            this.Content = XamlReader.Load(stream);
        //        }
        //    }
        //}

        //public void SaveExternalXaml()
        //{
        //    using (FileStream stream = new FileStream(@"C:\Test.xaml", FileMode.Create))
        //    {
        //        XamlWriter.Save(this.Content, stream);
        //    }
        //}