using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class FacilitiesModel
    {
        private int _ap_no;
        private string _f_name;
        private string _f_condition;
        private DateTime _last_broken;
        private int _times_broken;
        private byte _image;
        private byte _uploaded_f;
        private string _uploaded_f_name;
        private DateTime _updated_on;
        private bool _approved;
        private int _id;
        private int _f_value;

        public FacilitiesModel() { }

        #region Properties
        public int Ap_No { get { return _ap_no; } set { _ap_no = value; } }
        public string F_Name { get { return _f_name; } set { _f_name = value; } }
        public string F_Condition { get { return _f_condition; } set { _f_condition = value; } }
        public DateTime Last_Broken { get { return _last_broken; } set { _last_broken = value; } }
        public int Times_Broken { get { return _times_broken; } set { _times_broken = value; } }
        public byte Image { get { return _image; } set { _image = value; } }
        public byte Uploaded_F { get { return _uploaded_f; } set { _uploaded_f = value; } }
        private DateTime Updated_On { get { return _updated_on; } set { _updated_on = value; } }
        public string Uploaded_F_Name { get { return _uploaded_f_name; } set { _uploaded_f_name = value;} }
        public bool Approved { get { return _approved; } set { _approved = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public int F_Value { get { return _f_value; } set { _f_value = value; } }

        #endregion

    }
}
