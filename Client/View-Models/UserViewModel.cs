using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.View_Models;
using Client.Handlers;
using System.Collections.ObjectModel;

namespace Client.View_Models
{ 
    public class UserViewModel 
    {

        GenericSingleton GenericSingleton { get; set; }

        UserHandler UserHandler { get; set; }
        ResidentHandler ResidentHandler { get; set; }

        public UserModel CurrentUser { get { return _currentuser; } set { _currentuser = value; } }
        public ResidentModel CurrentResident { get { return _currentresident; } set { _currentresident = value; } }

        private UserModel _currentuser { get; set; } 
        private ResidentModel _currentresident { get; set; }

        public UserViewModel()
        {

            GenericSingleton = GenericSingleton.Instance;

            CurrentUser = GenericSingleton.Instance.User;
            

    //        UserHandler = new UserHandler(this);
            ResidentHandler = new ResidentHandler(this);

            ResidentHandler.GetUserInfo();
        }


        private void GetTestDetails()
        {
            
        }
    }
}
