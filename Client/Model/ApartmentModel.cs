using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ApartmentModel
    {
        public int Ap_No { get; set; }
        public string IsFree { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; }
        public int Size { get; set; }
        public int No_Rooms { get; set; }
        public int BBR { get; set; }
        public int? Fordelingstal { get; set; }
        public string Ap_Drawing { get; set; }
        public decimal? Rent { get; set; }

        public ApartmentModel(int _ap_No, string _isFree, string _address, int _floor, string _number, int _size, int _no_Rooms, int _bbr, int? _fordelingstal, string _ap_Drawing, decimal? _rent)
        {
            Ap_No = _ap_No;
            IsFree = _isFree;
            Address = _address;
            Floor = _floor;
            Number = _number;
            Size = _size;
            No_Rooms = _no_Rooms;
            BBR = _bbr;
            Fordelingstal = _fordelingstal;
            Ap_Drawing = _ap_Drawing;
            Rent = _rent;
        }

        public override string ToString()
        {
            return string.Format("Apartment ID = {0} \r\n" +
                "Available = {1} \r\n" +
                "Address = {2} \r\n" +
                "Floor = {3} \r\n" +
                "Apartment Number = {4} \r\n" +
                "Size = {5} \r\n" +
                "Number of rooms = {6} \r\n" +
                "BBR = {7} \r\n" +
                "Fordelingstal = {8} \r\n" +
                "Rent = {9}", Ap_No, IsFree, Address, Floor, Number, Size, No_Rooms, BBR, Fordelingstal, Rent);
        }

    }
}
