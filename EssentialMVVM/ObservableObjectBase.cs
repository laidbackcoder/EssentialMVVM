// <summary>
// Project Name         :   EssentialMVVM
// Project Description  :   A lightweight Model-View-ViewModel (MVVM) framework for WPF
// Project Website      :   https://essentialmvvm.codeplex.com
// Developer            :   Phil Tyler (http://www.laidbackcoder.co.uk)
// License              :   GNU Lesser General Public License (LGPL)
// License URL          :   https://essentialmvvm.codeplex.com/license
// </summary>
using System.ComponentModel;

namespace PT.EssentialMVVM
{
    /// <summary>
    /// A basic implementation of the <see cref="INotifyPropertyChanged"/> interface to be used 
    /// as a base class for Models.
    /// </summary>
    public abstract class ObservableObjectBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Trigger the Property Changed Event
        /// </summary>
        /// <param name="propertyName">Name of Property that has Changed</param>
        public void RaisePropertyChanged(string propertyName)
        { 
            // Check if there are any Listeners
            if (this.PropertyChanged != null)
            {
                // Trigger the Property Changed Event
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
