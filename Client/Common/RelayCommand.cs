using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Raised when RaiseCanExecuteChanged is called.

        public event EventHandler CanExecuteChanged;

        // Creates a new command that can always execute.

        // <param name="execute"> The execution logic. </param>

        public RelayCommand(Action execute)
        : this(execute, null)
        {
        }

        //Creates a new command.

        //<param name="execute">The execution logic.</param>
        //<param name="canExecute">The execution status logic. </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        //Determines whether this <see cref="RelayCommand"/> can execute in its current state.

        // <param name="parameter">
        // Data used by the command. If the command does not require data to be passed, 
        // this object can be set to null
        // </param>
        // <returns> true if this command can be executed;
        // otherwise, false. 
        // </returns>

        // Executes the <see cre="RelayCommand" /> on the current command target.

        // <param name="parameter">
        // Data used by the command. If the command does not require data to be passed, 
        // this object can be set to null.
        // </param>

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        // Method used to raise the >see cref="CanExecuteChanged" /> event
        // to indicate that the return value of the <see cref="CanExecute"/>
        // method has changed.

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
