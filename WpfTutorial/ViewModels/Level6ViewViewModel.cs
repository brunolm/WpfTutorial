using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level6ViewViewModel))]
    public class Level6ViewViewModel : BaseLevelViewModel
    {
        public string SomeInput { get; set; }

        public RelayCommand ChangeTextCommand { get; private set; }

        public Level6ViewViewModel()
        {
            ChangeTextCommand = new RelayCommand(ChangeTextExecute);

            SomeInput = "Initial text";
            this.RaisePropertyChanged("SomeInput");
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 6 - Can't change
Expected result
===============
When I click the Change button the text should change.

Actual result
===============
When I click the Change button the text does not change.

Steps to reproduce:
1. Click the Change button
";

            #endregion
        }

        private void ChangeTextExecute(object obj)
        {
            SomeInput = "Changed";
        }
    }
}
