using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(LevelWindowViewModel))]
    public class LevelWindowViewModel : BaseViewModel
    {
        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                description = value;
                this.RaisePropertyChanged();
            }
        }

        private UserControl level;
        public UserControl Level
        {
            get { return level; }
            set
            {
                level = value;
                this.RaisePropertyChanged();

                Description = (Level.DataContext as BaseLevelViewModel).Description;
            }
        }
    }
}
