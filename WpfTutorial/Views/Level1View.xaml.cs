using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using WpfTutorial.Extenders;

namespace WpfTutorial.Views
{
    [MetadataExport(typeof(Level1View), typeof(ILevelControl), "Level 1 - Exception on pay")]
    /// <summary>
    /// Interaction logic for Level1View.xaml
    /// </summary>
    public partial class Level1View : UserControl, ILevelControl
    {
        public Level1View()
        {
            InitializeComponent();
            this.ResolveDependencies();
        }
    }
}
