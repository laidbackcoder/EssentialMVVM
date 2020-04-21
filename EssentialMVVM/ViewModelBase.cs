// <summary>
// Project Name         :   EssentialMVVM
// Project Description  :   A lightweight Model-View-ViewModel (MVVM) framework for WPF
// Project Website      :   https://github.com/laidbackcoder/EssentialMVVM
// License              :   GNU Lesser General Public License (LGPL)
// License URL          :   https://github.com/laidbackcoder/EssentialMVVM/blob/master/LICENSE
// </summary>
using System;

namespace PT.EssentialMVVM
{
    /// <summary>
    /// An extension of the <see cref="ObservableObjectBase"/> class to be used as a 
    /// base class for ViewModels.
    /// </summary>
    public abstract class ViewModelBase : ObservableObjectBase
    {
        // TODO: Implement VM Messaging Engine.

        /// <summary>
        /// Invoke Code on the Main Thread
        /// </summary>
        /// <param name="action">Action to Execute on the Main Thread</param>
        public void InvokeOnMainThread(Action action)
        {
            ThreadHelper.InvokeOnMainThread(action);
        }
    }
}
