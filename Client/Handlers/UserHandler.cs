using Client.API;
using Client.Common;
using Client.Model;
using Client.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Client.Handlers
{
    class UserHandler
    {
        public UserViewModel UserViewModel { get; set; }
        public UserHandler(UserViewModel uservm)
        {
            UserViewModel = uservm;
        }
        public void GetUserInfo()
        {
            int RNo = UserViewModel.CurrentUser.R_No;
            try
            {
                ResidentModel Owner = APIController.GetOwner(RNo);
                if (Owner == null)
                    new MessageDialog("Internal error on processing the data.").ShowAsync();
                UserViewModel.CurrentResident = Owner;
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }


        }
        public void SaveUserInfo()
        {
            APIController.SaveUser(UserViewModel.CurrentResident);
        }

        public void SetPhotoAsync()
        {

            
          //  UserViewModel.CurrentResident.Picture = DownloadData("http://www.google.com/images/logos/ps_logo2.png");
//UserViewModel.Image = handler.GetImage(UserViewModel.CurrentResident.Picture);
        }


    }
}
