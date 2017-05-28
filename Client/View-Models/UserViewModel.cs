using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.View_Models;
using Client.Handlers;

namespace Client.View_Models
{ 
    class UserViewModel 
    {

        GenericSingleton GenericSingleton { get; set; }

        public UserModel CurrentUser { get { return _currentuser; } set { _currentuser = value; } }

        private UserModel _currentuser { get; set; } 

        public UserViewModel()
        {

            GenericSingleton = GenericSingleton.Instance;

            CurrentUser = GenericSingleton.Instance.User;
        }
    }
}
