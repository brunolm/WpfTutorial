using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTutorial
{
    public static class MefBootstrap
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    var catalog = new AssemblyCatalog(typeof(App).Assembly);

                    container = new CompositionContainer(catalog);
                }

                return container;
            }
        }
    }
}
