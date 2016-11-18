// <summary>
// Project Name         :   EssentialMVVM
// Project Description  :   A lightweight Model-View-ViewModel (MVVM) framework for WPF
// Project Website      :   https://essentialmvvm.codeplex.com
// Developer            :   Phil Tyler (http://www.laidbackcoder.co.uk)
// License              :   GNU Lesser General Public License (LGPL)
// License URL          :   https://essentialmvvm.codeplex.com/license
// </summary>
using System;
using System.Windows.Input;

namespace PT.EssentialMVVM
{
    /// <summary>
    /// An implementation of the <see cref="ICommand"/> interface that can be initialized 
    /// in a ViewModel for execution, through binding, by a Control in a View.
    /// </summary>
    public class ViewModelCommand : ICommand
    {
        /// <summary>
        /// A function that determines whether the Command can be Executed
        /// </summary>
        private Func<bool> canExecuteCommand;

        /// <summary>
        /// An action to Execute
        /// </summary>
        private Action commandToExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class. 
        /// </summary>
        /// <remarks>The command can always be executed</remarks>
        /// <param name="execute">The Action for the Command to Execute</param>
        public ViewModelCommand(Action execute) 
            : this(execute, null)
        {
            // Do Nothing
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class.
        /// </summary>
        /// <param name="command">The Action for the Command to Execute</param>
        /// <param name="canExecute">A function that determines whether the Command can be Executed</param>
        public ViewModelCommand(Action command, Func<bool> canExecute)
        {
            if (command != null)
            {
                this.canExecuteCommand = canExecute;
                this.commandToExecute = command;
            }
            else
            {
                throw new Exception("No Action supplied for Execution by the Command");
            }
        }

        #region ICommand Requirements

            /// <summary>
            /// Can Execute Changed Event
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (this.canExecuteCommand != null)
                    {
                    // Helps the Command Manager to detect conditions 
                    // that change the ability of a command to execute
                    CommandManager.RequerySuggested += value;
                    }
                }

                remove
                {
                    if (this.canExecuteCommand != null)
                    {
                        CommandManager.RequerySuggested -= value;
                    }
                }
            }

            /// <summary>
            /// Determine if the Command can be Executed
            /// </summary>
            /// <param name="parameter">object used by the command</param>
            /// <remarks>If null is passed, the return value will be true</remarks>
            /// <returns>true if the command can be executed</returns>
            public bool CanExecute(object parameter)
            {
                if (this.canExecuteCommand != null)
                {
                    return this.canExecuteCommand();
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// Execute the Command
            /// </summary>
            /// <param name="parameter">object used by the command</param>
            /// <remarks>If the command does not require data to be passed, the parameter object can be set to null</remarks>
            public void Execute(object parameter)
            {
                this.commandToExecute();
            }

        #endregion
    }
}