using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.View_Models;
using System.Threading.Tasks;

namespace Client.Model
{
    public class GenericSingleton
    {
        private static UserModel _user { get; set; }

        public UserModel User
        {
            get { return _user; }
            set { _user = value; }
        }
        private GenericSingleton()
        {
           

        }
        private static GenericSingleton _instance;
        public static GenericSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenericSingleton();
                }
                return _instance;
            }
        }
    }
}
