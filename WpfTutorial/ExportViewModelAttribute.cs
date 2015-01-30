using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTutorial.ViewModels;

namespace WpfTutorial
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportViewModelAttribute : MetadataExportAttribute
    {
        public ExportViewModelAttribute(Type declaredType)
            : base(declaredType, typeof(IViewModel))
        {
        }
    }
}
