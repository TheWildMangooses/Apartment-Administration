using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.View_Models;

namespace Client.Model
{
    class UserSingleton
    {
        private UserSingleton()
        {
        }
        private static UserSingleton _instance;
        public static UserSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSingleton();
                }
                return _instance;
            }
        }
    }
}
