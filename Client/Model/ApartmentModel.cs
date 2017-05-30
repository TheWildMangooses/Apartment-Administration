using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ApartmentModel
    {

        private int _ap_no;
        private bool _isfree;
        private int _floor;
        private string _number;
        private int _b_no;
        private int _size;
        private int _no_rooms;
        private int _bbr;
        private int _fordelingstal;
        private byte _ap_drawing;
        private decimal _rent;
        private byte _uploaded_doc;
        private string _uploaded_doc_name;
        private DateTime _uploaded_doc_date;
        private string _address;
        private bool _isactive;

        public ApartmentModel() { }

        #region Properties
            public int Ap_No { get { return _ap_no; } set { _ap_no = value; } }
            public bool IsFree { get { return _isfree; } set { _isfree = value; } }
            public int Floor { get { return _floor; } set { _floor = value; } }
            public int Number { get { return _number; } set { _number = value; } }
            public int B_No { get { return _b_no; } set { _b_no = value; } }
            public int Size { get { return _size; } set { _size = value; } }
            public int No_Rooms { get { return _no_rooms; }set { _no_rooms = value; } }
            public int BBR { get { return _bbr; } set { _bbr = value; } }
            public int Fordelingstal { get { return _fordelingstal; } set { _fordelingstal = value; } }
            public byte Ap_Drawing { get { return _ap_drawing; } set { _ap_drawing = value; } }
            public decimal Rent { get { return _rent; } set { _rent = value; } }
            public byte Uploaded_Doc { get { return _uploaded_doc; } set { _uploaded_doc = value; } }
            public string Uploaded_Doc_Name { get { return _uploaded_doc_name; } set { _uploaded_doc_name = value; } }
            public DateTime Uploaded_Doc_Date { get { return _uploaded_doc_date; } set { _uploaded_doc_date = value; } }
            public string Address { get { return _address; } set { _address = value; } }
            public bool IsActive { get { return _isactive; } set { _isactive = value; } }
        #endregion

    }
}
