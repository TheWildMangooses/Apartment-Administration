using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.API;
using Client.View_Models;
using Client.Model;
using Client.API;
using Windows.UI.Popups;

namespace Client.Handlers
{
    public class ResidentHandler
    {
        public UserViewModel UserViewModel { get; set; }
        public ResidentHandler(UserViewModel _viewmodel) {
            UserViewModel = _viewmodel;
        }

        public void GetUserInfo()
        {
            int RNo = UserViewModel.CurrentUser.R_No;
            try
            {
                ResidentModel Owner = APIController.GetOwner(RNo);
                if(Owner==null)
                    new MessageDialog("Internal error on processing the data.").ShowAsync();
                UserViewModel.CurrentResident = Owner;
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }


        }

    }
}
