using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.View_Models;
using Client.Handlers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Annotations;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Windows.Input;
using Client.Common;

namespace Client.View_Models
{ 
    public class UserViewModel : INotifyPropertyChanged
    {
        
        GenericSingleton GenericSingleton { get; set; }

        UserHandler UserHandler { get; set; }

        private ICommand _changeimage { get; set; }
        public ICommand ChangeImage { get { return _changeimage; } set { _changeimage = value; } }

        private ICommand _savedetails { get; set; }
        public ICommand SaveDetails
        {
            get
            { return _savedetails; }
            set { _savedetails = value;}
        }

        public UserModel CurrentUser { get { return _currentuser; } set { _currentuser = value; OnPropertyChanged("CurrentUser"); } }
        public ResidentModel CurrentResident { get { return _currentresident; } set { _currentresident = value; OnPropertyChanged("CurrentResident"); } }
        public BitmapImage Image { get { return _image; } set { _image = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Image")); } }

        private UserModel _currentuser { get; set; } 
        private ResidentModel _currentresident { get; set; }
        private BitmapImage _image { get; set; }

        public UserViewModel()
        {

            GenericSingleton = GenericSingleton.Instance;

            CurrentUser = GenericSingleton.Instance.User;
            

            UserHandler = new UserHandler(this);

            UserHandler.GetUserInfo();

            ChangeImage = new RelayCommand(UserHandler.SetPhotoAsync);

            SaveDetails = new RelayCommand(UserHandler.SaveUserInfo);
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
