using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(LevelWindowViewModel))]
    public class LevelWindowViewModel : IViewModel, INotifyPropertyChanged
    {
        private UserControl level;
        public UserControl Level
        {
            get { return level; }
            set
            {
                level = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Level"));
            }
        }

        public void OnLoaded(object sender)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
