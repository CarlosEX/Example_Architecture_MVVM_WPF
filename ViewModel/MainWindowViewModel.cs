using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ArchitectureMVVMinWPF.RelayCommands;

namespace ArchitectureMVVMinWPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string name;
        public string Name{
            get {return name;}
            set{
                name = value;
                CheckAndEnableButton();
                OnPropertyChanged();
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { 
                phoneNumber = value; 
                CheckAndEnableButton();
                OnPropertyChanged();
                }
        }
        public ICommand SubmitButtonCommand{get; set;}
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            CheckAndEnableButton();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CheckAndEnableButton(){
            bool isEnabled = false;
            string result = string.Empty;

            if(Name?.Length > 0 && PhoneNumber?.Length > 0){
                isEnabled = true;
                result = string.Format("My Details are: \n{0}\n{1}\n",Name, PhoneNumber);
            }
            else{
                isEnabled = false;
            }
            SubmitButtonCommand = new RelayCommand((obj) => {return isEnabled;}, (ob) => {MessageBox.Show(result);});
            OnPropertyChanged("SubmitButtonCommand");
        }
    }
}