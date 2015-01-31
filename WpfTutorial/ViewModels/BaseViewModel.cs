﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTutorial.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public virtual void OnLoaded(object sender)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
