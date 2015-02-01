using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level7ViewViewModel))]
    public class Level7ViewViewModel : BaseLevelViewModel
    {
        public Level7ViewViewModel()
        {
        }

        public override void OnLoaded(object sender)
        {
            #region Level info

            Description = @"Level 7 - I wish...

As a user I want to be able to create a wishlist so I can remember what to buy next.

Acceptance Criteria
- I can enter a name for the item I want to add to my wishlist
- I can click a button to add the item to the wishlist
- I can click a button to remove the selected item from the wishlist
";

            #endregion
        }
    }
}
