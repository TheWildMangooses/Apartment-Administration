using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ApartmentSingleton
    {
        private static ApartmentSingleton instance = new ApartmentSingleton();

        public static ApartmentSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<ApartmentModel> Apartments { get; set; }

        private ApartmentSingleton()
        {
            Apartments = new ObservableCollection<ApartmentModel>();
            ApartmentModel Ap1 = new ApartmentModel(11111, "Yes", "Roskildevej 88", 2, "4 TH", 110, 2, 45, 80, "Drawing", 4880);
            Apartments.Add(Ap1);
        }

        public void Add(int Ap_No, string IsFree, string Address, int Floor, string Number, int Size, int No_Rooms, int BBR, int? Fordelingstal, string Ap_Drawing, decimal? Rent)
        {
            Apartments.Add(new ApartmentModel(Ap_No, IsFree, Address, Floor, Number, Size, No_Rooms, BBR, Fordelingstal, Ap_Drawing, Rent));
        }
    }
}
