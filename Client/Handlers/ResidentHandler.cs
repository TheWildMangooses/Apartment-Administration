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
using Client.Common;
using Windows.Storage.Pickers;
using Windows.Storage;
using Client.Views;
using System.Collections.ObjectModel;

namespace Client.Handlers
{
    public class ResidentHandler
    {
        public ResidentViewModel ResidentViewModel { get; set; }
        public ResidentHandler(ResidentViewModel _viewmodel) {
            ResidentViewModel = _viewmodel;
        }
        public async Task<ObservableCollection<ResidentModel>> GetCoResidents(int Parent_Resident) //FELIX
        {
            return new ObservableCollection<ResidentModel>(APIController.GetPeople(Parent_Resident));
        }
        public void DeleteCoresident()
        {
            ResidentViewModel.Cohabitants.RemoveAt(0);
        }
        public async void EditCoresident()
        {

        }
    }
}
