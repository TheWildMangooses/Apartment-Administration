using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace Client.Model
{
    public class UserModel
    {
        private int _id;
        private string _username;
        private string _password;
        private Boolean _isadmin;
        private int _adminLevel;
        private int _r_No;
        private bool _isapproved;
        public UserModel() { }

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Boolean IsAdmin
        {
            get { return _isadmin; }
            set { _isadmin = value; }
        }
        public int AdminLevel
        {
            get { return _adminLevel; }
            set { _adminLevel = value; }
        }
        public int R_No
        {
            get { return _r_No; }
            set { _r_No = value; }
        }
        public bool IsActive
        {
            get { return _isapproved; }
            set { _isapproved = value; }
        }


        #endregion
    }
}