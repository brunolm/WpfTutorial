using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level5View), typeof(ILevelControl), "Level 5 - Can't get it right")]
    /// <summary>
    /// Interaction logic for Level3View.xaml
    /// </summary>
    public partial class Level5View : UserControl, ILevelControl
    {
        public Level5View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
