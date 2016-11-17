// <summary>
// Project Name         :   EssentialMVVM
// Project Description  :   A lightweight Model-View-ViewModel (MVVM) framework for WPF
// Project Website      :   https://essentialmvvm.codeplex.com
// Developer            :   Phil Tyler (http://www.laidbackcoder.co.uk)
// License              :   GNU Lesser General Public License (LGPL)
// License URL          :   https://essentialmvvm.codeplex.com/license
// </summary>
using System;

namespace PT.EssentialMVVM
{
    /// <summary>
    /// <see cref="ViewModelBase"/> Class is an extension of the <see cref="ObservableObjectBase"/> class
    /// to be used as a BaseClass for ViewModels
    /// </summary>
    public abstract class ViewModelBase : ObservableObjectBase
    {
        // TODO: Implement VM Messaging Engine.

        /// <summary>
        /// Invoke Code on the Main Thread
        /// </summary>
        /// <param name="action">Code to Execute</param>
        public void InvokeOnMainThread(Action action)
        {
            ThreadHelper.InvokeOnMainThread(action);
        }
    }
}
