using Client.Annotations;
using Client.API;
using Client.Common;
using Client.Handlers;
using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.View_Models
{
    public class ResidentViewModel : INotifyPropertyChanged //FELIX
    {


        private ICommand _delete { get; set; }
        public ICommand Delete
        {
            get { return _delete; }
            set { _delete = value; }
        }
        private ICommand _add { get; set; }
        public ICommand Add
        {
            get { return _add; }
            set { _add = value; }
        }
        private ICommand _edit { get; set; }
        public ICommand Edit
        {
            get { return _edit; }
            set { _edit = value; }
        }

        public GenericSingleton StateSingleton { get; set; }
        
        public ResidentHandler ResidentHandler;
        public ObservableCollection<ResidentModel> Cohabitants { get { return _cohabitants; } set { if (_cohabitants != value) { _cohabitants = value; OnPropertyChanged(); } } }
        private ObservableCollection<ResidentModel> _cohabitants { get; set; }
        public ResidentModel CurrentResident { get; set; }

        public ResidentViewModel()
        {
            StateSingleton = GenericSingleton.Instance;
            CurrentResident = StateSingleton.Resident;
            ResidentHandler = new ResidentHandler(this);
//            Cohabitants = new ObservableCollection<ResidentModel>();
            Cohabitants = ResidentHandler.GetCoResidents(CurrentResident.R_No).Result;
//            Add = new RelayCommand(ResidentHandler.);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
