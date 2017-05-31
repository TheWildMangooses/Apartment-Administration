using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class ResidentModel
    {
        private string _name;
        private string _l_name;
        private int _r_no;
        private int _ap_no;
        private int _phone_no;
        private string _email;
        private DateTime _m_in;
        private DateTime _m_out;
        private bool _isowner;
        private byte[] _image;
        private int _parent_Resident;
        private bool _isactive;

        public ResidentModel() { }

        #region Properties
        public int Ap_No { get { return _ap_no; } set { _ap_no = value; } }
        public string E_Mail { get { return _email; } set { _email = value; } }
        public bool IsOwner { get { return _isowner; } set { _isowner = value; } }
        public string L_Name { get { return _l_name; } set { _l_name = value; } }
        public DateTime M_In { get { return _m_in; } set { _m_in = value; } }
        public DateTime M_Out { get { return _m_out; } set { _m_out = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Parent_Resident { get { return _parent_Resident; } set { _parent_Resident = value; } }
        public int Phone_No { get { return _phone_no; } set { _phone_no = value; } }
        public byte[] Picture { get { return _image; } set { _image = value; } }
        public int R_No { get { return _r_no; } set { _r_no = value; } }  
        public bool IsActive { get { return _isactive; } set { _isactive = value; } }
        #endregion


    }
}
