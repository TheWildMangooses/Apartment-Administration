﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.View_Models
{
    public class StateViewModel: INotifyPropertyChanged
    {


        GenericSingleton statesingleton;


        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}