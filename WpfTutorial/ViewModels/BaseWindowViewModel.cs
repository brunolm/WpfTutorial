using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    public class BaseWindowViewModel : BaseViewModel
    {
        private string title;
        public virtual string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
