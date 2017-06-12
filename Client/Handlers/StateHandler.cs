using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Views;
using Client.API;
using Client.View_Models;
using Client.Common;

namespace Client.Handlers
{
    public class StateHandler
    {
        //AGATA
        public StateViewModel StateViewModel { get; set; }

        public StateHandler(StateViewModel _stateviewmodel)
        {
            StateViewModel = _stateviewmodel;
        }

        public void PrepareLoginPhase()
        {
            var check = APIController.CheckLogin(StateViewModel.Username, StateViewModel.Password);
            if(check!=null)
            {
                
                if (!check.IsAdmin)
                {
                    //                   StateViewModel.CurrentLoggedUser = check;
                    StateViewModel.StateSingleton.User = check;
                    StateViewModel.StateSingleton.Resident = APIController.GetOwner(check.R_No);
                    DecideNextView(false);
                }
                else
                {
                    StateViewModel.StateSingleton.User = check;
                    StateViewModel.StateSingleton.Resident = APIController.GetOwner(check.R_No);
                    DecideNextView(false);
                }
            }
        }
        public void DecideNextView(bool IsAdmin)
        {

            if (IsAdmin == true)
                App.NavService.NavigateTo(typeof(BoardMView), null);
            else
                App.NavService.NavigateTo(typeof(UserView), null);
        }
        public void DoLogout()
        {
            StateViewModel.StateSingleton.Resident = null;
            StateViewModel.StateSingleton.User = null;
            App.NavService.NavigateTo(typeof(Login), null);
        }

    }
}
