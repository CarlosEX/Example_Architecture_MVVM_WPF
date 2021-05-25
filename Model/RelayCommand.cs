// Carlos Antonio : https://carlosantoniocison.editorx.io/portifolio
// Example Extract the: https://www.c-sharpcorner.com/article/mvvm-architecture/

using System;
using System.Windows.Input;


namespace ArchitectureMVVMinWPF.RelayCommands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> execute;

        public RelayCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;           
        }

        public bool CanExecute(object parameter){
            return canExecute(parameter);
        }
        public void Execute(object parameter){
            execute(parameter);
        }
    }
}