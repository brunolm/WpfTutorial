using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level2ViewViewModel))]
    public class Level2ViewViewModel : BaseViewModel, ILevelViewModel
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

        public class Person
        {
            public string Name { get; set; }

            public int? ContextID { get; set; }
        }

        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                this.RaisePropertyChanged();
            }
        }

        public ICollectionView PeopleView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(People);
            }
        }

        public Dictionary<string, string> Contexts { get; private set; }

        private string selectedContext;
        public string SelectedContext
        {
            get { return selectedContext; }
            set
            {
                selectedContext = value;
                this.RaisePropertyChanged();

                PeopleView.Refresh();
            }
        }

        public Level2ViewViewModel()
        {
            Contexts = new Dictionary<string, string>
            {
                { "", "All" },
                { "10", "System Context 10" },
                { "20", "System Context 20" },
                { "30", "System Context 30" },
            };

            People = new ObservableCollection<Person>(new List<Person>
            {
                new Person { Name = "Bruno Context 10", ContextID = 10 },
                new Person { Name = "Bruno Context 20", ContextID = 20 },
                new Person { Name = "Bruno Context 30", ContextID = 30 },
                new Person { Name = "Bruno Context null", ContextID = null },
            });

            SelectedContext = "10";

            PeopleView.Filter = new Predicate<object>((o) =>
            {
                var person = o as Person;

                return person.ContextID == int.Parse(SelectedContext);
            });
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 2 - Grid results by context
Expected result
===============
When I choose a context it should show only people from that context.
If I choose All it should show everyone regardless of context.

Actual result
===============
When I choose All the grid doesn't change.

Steps to reproduce:
1. Change the combobox selection to another context (see that the grid updates)
2. Change the combobox selection to All (error)
";

            #endregion
        }
    }
}
