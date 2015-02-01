using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level3ViewViewModel))]
    public class Level3ViewViewModel : BaseLevelViewModel
    {
        private ObservableCollection<Knight> knights;
        public ObservableCollection<Knight> Knights
        {
            get { return knights; }
            set
            {
                knights = value;
                this.RaisePropertyChanged();
            }
        }

        public ICollectionView KnightsView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(Knights);
            }
        }

        private Knight selectedKnight;
        public Knight SelectedKnight
        {
            get { return selectedKnight; }
            set
            {
                selectedKnight = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand CalculatePowerCommand { get; private set; }

        public class Knight
        {
            public string Name { get; set; }

            public int Strenght { get; set; }

            public int Magic { get; set; }

            public int Spirit { get; set; }
        }

        public Level3ViewViewModel()
        {
            CalculatePowerCommand = new RelayCommand(CalculatePowerExecute);

            Knights = new ObservableCollection<Knight>(new List<Knight>
            {
                new Knight { Name = "Meliodas", Strenght = 960, Magic = 400, Spirit = 2010 },
                new Knight { Name = "Diane", Strenght = 1870, Magic = 900, Spirit = 480 },
                new Knight { Name = "Ban", Strenght = 0, Magic = 0, Spirit = 0 },
                new Knight { Name = "King", Strenght = 0, Magic = 0, Spirit = 0 },
                new Knight { Name = "Merlin", Strenght = 70, Magic = 3540, Spirit = 1100 },
                new Knight { Name = "Gowther", Strenght = 500, Magic = 1300, Spirit = 1300 },
                new Knight { Name = "Escanor", Strenght = 0, Magic = 0, Spirit = 0 },
            });
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 3 - Broken right click calc
Expected result
===============
When I right click an element on the grid and select Calculate Power it should show me the character information along with its total power.
The total power should be displayed as a sum of Strenght + Magic + Spirit.

Actual result
===============
When I right click and calculate the application throws an exception.

Steps to reproduce:
1. Select a row on the grid
2. Right click the row
3. Click calculate on the context menu
";

            #endregion
        }

        private void CalculatePowerExecute(object obj)
        {
            MessageBox.Show(
                String.Format("Name: {1}{0}Strengh: {2}{0}Magic: {3}{0}Spirit: {4}{0}Total: {5}"
                    , Environment.NewLine
                    , SelectedKnight.Name
                    , SelectedKnight.Strenght
                    , SelectedKnight.Magic
                    , SelectedKnight.Spirit
                    , SelectedKnight.Spirit
                )
            );
        }
    }
}
