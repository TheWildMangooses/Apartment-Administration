using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class MessageModel
    {
        private int _id;
        private int _r_no;
        private string _message;
        private DateTime _date_time;
        private int _sent_to;
        private byte _uploaded_file;
        private string _uploaded_file_name; 

        public MessageModel() { }

        #region Properties
        public int Id { get { return _id; } set { _id = value; } }
        public int R_No { get { return _r_no; } set { _r_no = value; } }
        public string Message { get { return _message; } set { _message = value; } }
        public DateTime Date_Time { get { return _date_time; } set { _date_time = value; } }
        public int Send_To { get { return _sent_to; } set { _sent_to = value; } }
        public byte Uploaded_File { get { return _uploaded_file; } set { _uploaded_file = value; } }
        public string Uploaded_File_Name { get { return _uploaded_file_name; } set { _uploaded_file_name = value; } }

        #endregion
    }
}
