using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Handlers;
using System.Windows.Input;
using Client.Common;

namespace Client.View_Models
{
    public class UserCreation
    {
        public GenericSingleton Singleton { get; set; }
        public UserCreateHandler Handler { get; set; }
        private ICommand _create { get; set; }


        private string username { get; set; }
        private string password { get; set; }
        public ICommand Create { get { return _create; } set { _create = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public UserCreation()
        {
            Singleton = GenericSingleton.Instance;
            Handler = new UserCreateHandler(this);

            Create = new RelayCommand(Handler.AddUser);
        }

    }
}
