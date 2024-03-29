using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SportBar_0.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that gets raised whenever a property value changes.
        /// This event is used for data binding in WPF and other UI frameworks.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;



        /// <summary>
        /// Protected method to raise the PropertyChanged event for a specific property.
        /// </summary>
        /// <param name="name">Optional: The name of the property that changed. 
        /// If not provided, it will be inferred using CallerMemberName attribute.</param>

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
