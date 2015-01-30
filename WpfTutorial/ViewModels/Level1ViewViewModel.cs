using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level1ViewViewModel))]
    public class Level1ViewViewModel : IViewModel, INotifyPropertyChanged
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
        public void OnLoaded(object sender)
        {
            Description = "bla";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
