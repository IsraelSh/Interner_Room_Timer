using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBar_0.Core;


namespace SportBar_0.MVVM.ViewModel
{

    /// <summary>
    /// This class represents the MainViewModel for the MVVM application.
    /// It manages the overall application state and navigation between views.
    /// </summary>
    internal class MainViewModel : ObservableObject
    {

        /// <summary>
        /// ViewModel instance for the Home view.
        /// </summary>
        public HomeViewModel HomeVm { get; set; }

        /// <summary>
        /// The currently displayed view model in the application.
        /// This property is used for data binding to dynamically switch views.
        /// </summary>
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(); // Notify UI of change
            }
        }


        /// <summary>
        /// Constructor for the MainViewModel.
        /// Initializes the HomeViewModel and sets it as the initial view.
        /// </summary>
        public MainViewModel()
        {
            // Consider making HomeVm nullable if it's okay for it to be null initially
            // (depending on your application logic).
            HomeVm = new HomeViewModel();

            CurrentView = HomeVm; // Set Home view as initial view



        }


    }
}







// Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.