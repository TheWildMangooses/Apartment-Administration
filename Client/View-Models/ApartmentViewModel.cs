using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.View_Models
{
    class ApartmentViewModel
    {
        public ApartmentSingleton ApartmentSingleton { get; set; }
        public ApartmentViewModel()
        {
            ApartmentSingleton = ApartmentSingleton.Instance;
        }
    }
}
