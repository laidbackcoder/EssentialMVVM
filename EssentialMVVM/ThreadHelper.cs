// <summary>
// Project Name         :   EssentialMVVM
// Project Description  :   A lightweight Model-View-ViewModel (MVVM) framework for WPF
// Project Website      :   https://essentialmvvm.codeplex.com
// Developer            :   Phil Tyler (http://www.laidbackcoder.co.uk)
// License              :   GNU Lesser General Public License (LGPL)
// License URL          :   https://essentialmvvm.codeplex.com/license
// </summary>
using System;
using System.Windows;
using System.Windows.Threading;

namespace PT.EssentialMVVM
{
    /// <summary>
    /// <see cref="ThreadHelper"/> static class.
    /// </summary>
    public static class ThreadHelper
    {
        /// <summary>
        /// Invoke Code on the Main Thread
        /// </summary>
        /// <param name="action">Code to Execute</param>
        public static void InvokeOnMainThread(Action action)
        {
            // Checks the application's instance of AppDomain is initialized
            // This step is required for Unit Testing support.           
            if (Application.Current != null)
            {
                // Get the Dispatcher instance for the current AppDomain
                Dispatcher d = Application.Current.Dispatcher;

                // If the calling thread is not the thread associated 
                // with the Dispatcher instance
                if (d != null && !d.CheckAccess())
                {
                    // Invoke action on the Dispatcher Thread
                    d.Invoke(action);
                }
                else
                {
                    // Execute the Action on the Calling Thread
                    action();
                }
            }
            else
            {
                // Execute the Action on the Calling Thread
                action();
            }
        }
    }
}
