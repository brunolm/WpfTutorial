using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Extenders
{
    public static class ContentControlExtender
    {
        public static void ResolveDependencies(this ContentControl control)
        {
            MefBootstrap.Container.ComposeParts(control);
            MefBootstrap.Container.SatisfyImportsOnce(control);
            
            var controlName = control.GetType().Name;

            var viewModel = MefBootstrap.Container.GetExports<IViewModel, IExportMetadata>()
                .Where(i => i.Metadata.DeclaredType.Name.EndsWith(String.Format("{0}ViewModel", controlName)))
                .Select(i => i.Value)
                .FirstOrDefault();

            if (viewModel != null)
            {
                MefBootstrap.Container.SatisfyImportsOnce(viewModel);
                
                viewModel.OnLoaded(control);

                control.DataContext = viewModel;
            }
        }
    }
}
