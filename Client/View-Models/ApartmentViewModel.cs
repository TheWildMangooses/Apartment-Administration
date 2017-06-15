using Client.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Client.Model;
using Client.Handlers;
using Client.Common;
using System.Threading.Tasks;

namespace Client.View_Models
{
    class ApartmentViewModel : INotifyPropertyChanged
    {
        public ApartmentModel Apartment { get; set; }
        public ApartmentHandler ApartmentHandler { get; set; }
        public GenericSingleton GenericSingleton { get; set; }
        public ApartmentViewModel()
        {
            GenericSingleton = GenericSingleton.Instance;
            Apartment = GenericSingleton.Apartment;
            ApartmentHandler = new ApartmentHandler(this);

            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
