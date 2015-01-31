using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level2View), typeof(ILevelControl), "Level 2 - Grid results by context")]
    /// <summary>
    /// Interaction logic for Level2View.xaml
    /// </summary>
    public partial class Level2View : UserControl, ILevelControl
    {
        public Level2View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
