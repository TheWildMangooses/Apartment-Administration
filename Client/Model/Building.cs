using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Building
    {

        private int _b_no;
        private string _adrress;
        private int _no_ap;

        public Building() { }

        #region Properties
        public int B_No { get { return _b_no; } set { _b_no = value; } }
        public string Address { get { return _adrress; } set { _adrress = value; } }
        public int No_Ap { get { return _no_ap; } set { _no_ap = value; } }
#endregion
    }
}
