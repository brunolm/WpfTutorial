using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level4ViewViewModel))]
    public class Level4ViewViewModel : BaseLevelViewModel
    {
        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                this.RaisePropertyChanged();
            }
        }

        public ICollectionView TagsView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(Tags);
            }
        }

        public RelayCommand ShowInfoCommand { get; private set; }

        public class Tag
        {
            public string Name { get; set; }

            public ObservableCollection<Tag> Children { get; set; }
        }

        public Level4ViewViewModel()
        {
            Tags = new ObservableCollection<Tag>(new List<Tag>
            {
                new Tag { Name = "C#", Children = new ObservableCollection<Tag>(new List<Tag> { new Tag { Name = "WPF" }}) },
                new Tag { Name = "Web", Children = new ObservableCollection<Tag>(new List<Tag> { new Tag { Name = "HTML" }}) },
            });

            ShowInfoCommand = new RelayCommand(ShowInfoExecute);
            this.RaisePropertyChanged("ShowInfoCommand");
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 4 - Math is too hard
Expected result
===============
When I righ click an element on the TreeView and select Show Info I should be able to see the tag name along with the number of children it contains.

Actual result
===============
When I open the info popup it is not showing the number of children correctly.

Steps to reproduce:
1. Select an element from the TreeView
2. Right click
3. Click Show Info
";

            #endregion
        }

        private void ShowInfoExecute(object obj)
        {
            var tag = obj as Tag;

            MessageBox.Show(String.Format("Tag name: {0} Children tags: {1}", tag.Name, tag.Children), "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
