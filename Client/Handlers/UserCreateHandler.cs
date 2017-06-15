using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.API;
using Client.Model;
using Client.View_Models;

namespace Client.Handlers
{
    public class UserCreateHandler
    {
       public UserCreation VM { get; set; }
       public UserCreateHandler(UserCreation vm)
        {
            VM = vm;
        }

        public async void AddUser()
        {
            UserModel temp = new UserModel();
            temp.Id = 0;
            temp.IsActive = true;
            temp.Username = VM.Username;
            temp.Password = VM.Password;
            temp.IsAdmin = false;
            temp.R_No = 0;
            temp.AdminLevel = 0;
            APIController.CreateUser(temp);
        }
    }
}
