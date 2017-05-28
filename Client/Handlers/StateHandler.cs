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
                //TODO: SHOULD SHIT SHOULD COME HERE
                if (!check.IsAdmin)
                {
                    if (check.R_No == 0)
                    {
                        //TODO: ASSIGN APARTMENT 
                        check.R_No = 0;

                    }
                    //                   StateViewModel.CurrentLoggedUser = check;
                    StateViewModel.StateSingleton.User = check;
                    DecideNextView(false);
                }
                else
                {
                    StateViewModel.StateSingleton.User = check;
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

    }
}
