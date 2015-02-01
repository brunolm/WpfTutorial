using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level7View), typeof(ILevelControl), "Level 7 - I wish...")]
    /// <summary>
    /// Interaction logic for Level3View.xaml
    /// </summary>
    public partial class Level7View : UserControl, ILevelControl
    {
        public Level7View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
