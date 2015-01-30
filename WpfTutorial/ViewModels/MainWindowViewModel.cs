using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfTutorial.Extenders;
using WpfTutorial.Views;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : BaseWindowViewModel
    {
        private ObservableCollection<KeyValuePair<Type, string>> levels;
        public ObservableCollection<KeyValuePair<Type, string>> Levels
        {
            get { return levels; }
            set
            {
                levels = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand PlayCommand { get; private set; }

        private KeyValuePair<Type, string>? selectedLevel;
        public KeyValuePair<Type, string>? SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                selectedLevel = value;
                this.RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Title = "WPF Learning Game";

            PlayCommand = new RelayCommand(o =>
            {
                var levelWindow = new LevelWindow();
                (levelWindow.DataContext as LevelWindowViewModel).Level =
                    Activator.CreateInstance(SelectedLevel.Value.Key) as UserControl;
                levelWindow.ShowDialog();
                
            }, o => SelectedLevel != null);
        }

        public override void OnLoaded(object sender)
        {
            var levelControlExports = MefBootstrap.Container.GetExports<ILevelControl, IExportMetadata>();

            Levels = new ObservableCollection<KeyValuePair<Type, string>>(
                levelControlExports.Where(o => o.Metadata.DeclaredType.Name.StartsWith("Level"))
                    .Select(o => new KeyValuePair<Type, string>(o.Metadata.DeclaredType, o.Metadata.Name))
            );
        }
    }
}
