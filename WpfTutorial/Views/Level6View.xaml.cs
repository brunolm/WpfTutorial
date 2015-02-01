using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level6View), typeof(ILevelControl), "Level 6 - Can't change")]
    /// <summary>
    /// Interaction logic for Level3View.xaml
    /// </summary>
    public partial class Level6View : UserControl, ILevelControl
    {
        public Level6View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
