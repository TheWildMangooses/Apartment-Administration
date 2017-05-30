using Client.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Handlers
{
    class UserHandler
    {
        public UserViewModel UserViewModel { get; set; }
        public UserHandler(UserViewModel uservm)
        {
            UserViewModel = uservm;
        }


    }
}
