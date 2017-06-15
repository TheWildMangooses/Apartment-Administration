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
        private static ResidentModel _resident { get; set; }
        private static ApartmentModel _apartment { get; set; }

        public ApartmentModel Apartment
        {
            get { return _apartment; }
            set { _apartment = value; }
        }
        public UserModel User
        {
            get { return _user; }
            set { _user = value; }
        }
        public ResidentModel Resident
        {
            get { return _resident; }
            set { _resident = value; }
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
