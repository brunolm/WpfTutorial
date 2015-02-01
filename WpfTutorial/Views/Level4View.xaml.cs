using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level4View), typeof(ILevelControl), "Level 4 - Math is too hard")]
    /// <summary>
    /// Interaction logic for Level3View.xaml
    /// </summary>
    public partial class Level4View : UserControl, ILevelControl
    {
        public Level4View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
