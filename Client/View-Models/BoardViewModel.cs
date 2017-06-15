using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Handlers;
using Client.Common;
using System.ComponentModel;
using Client.Annotations;
using System.Runtime.CompilerServices;
using Client.Model;


namespace Client.View_Models
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        GenericSingleton Singleton { get; set; }
        public BoardViewModel()
        {
            Singleton = GenericSingleton.Instance;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
