using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Handlers;
using Client.Common;
using Client.View_Models;
using Client.API;

namespace Client.Handlers
{
    class ApartmentHandler
    {
        public ApartmentViewModel ApartmentVM { get; set; }
        public ApartmentHandler(ApartmentViewModel _viewmodel)
        {
            ApartmentVM = _viewmodel;
        }
    }
}
