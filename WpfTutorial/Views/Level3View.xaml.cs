using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level3View), typeof(ILevelControl), "Level 3 - Broken right click calc")]
    /// <summary>
    /// Interaction logic for Level3View.xaml
    /// </summary>
    public partial class Level3View : UserControl, ILevelControl
    {
        public Level3View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
