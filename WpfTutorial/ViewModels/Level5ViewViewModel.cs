using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level5ViewViewModel))]
    public class Level5ViewViewModel : BaseLevelViewModel
    {
        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get { return games; }
            set
            {
                games = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand ShowInfoCommand { get; private set; }

        public class Game
        {
            public string Name { get; set; }

            public ObservableCollection<Character> Characters { get; set; }
        }

        public class Character
        {
            public string Name { get; set; }
        }

        public Level5ViewViewModel()
        {
            ShowInfoCommand = new RelayCommand(ShowInfoExecute);

            Games = new ObservableCollection<Game>(new List<Game>
            {
                new Game 
                { 
                    Name = "Breath of Fire IV",
                    Characters = new ObservableCollection<Character>(new List<Character> 
                    {
                        new Character { Name = "Ryu" },
                        new Character { Name = "Fou-lu" },
                    }),
                },
                new Game 
                { 
                    Name = "Skyrim",
                    Characters = new ObservableCollection<Character>(new List<Character> 
                    {
                        new Character { Name = "Last Dragonborn" },
                        new Character { Name = "Alduin" },
                    }),
                },
            });
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 5 - Can't get it right
Expected result
===============
When I right click a game and click Show Info I should be able to see the game name properly.

Actual result
===============
When I right click a game and show info I get an exception.

Steps to reproduce:
1. Select a game from the TreeView
2. Right click
3. Click Show Info

Note: it seems to be woring fine for Characters
";

            #endregion
        }

        private void ShowInfoExecute(object obj)
        {
            var entity = (Character)obj;

            MessageBox.Show(entity.Name, "Selected");
        }
    }
}
