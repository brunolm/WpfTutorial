using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    public class BaseLevelViewModel : BaseViewModel
    {
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
