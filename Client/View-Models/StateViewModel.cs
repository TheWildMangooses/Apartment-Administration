using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Annotations;
using System.ComponentModel;
using Client.Handlers;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Client.Common;

namespace Client.View_Models
{
    public class StateViewModel : INotifyPropertyChanged
    {

        //AGATA
       public GenericSingleton StateSingleton { get; set; }

        private ICommand _login { get; set; }

        private string _password;
        private string _username;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        public ICommand  Login {
            get { return _login; }
            set { _login = value; }
        }
        public StateHandler StateHandler { get; set; }
        public StateViewModel()
        {
            StateSingleton = GenericSingleton.Instance;
            StateHandler = new StateHandler(this);
            Login = new RelayCommand(StateHandler.PrepareLoginPhase);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
