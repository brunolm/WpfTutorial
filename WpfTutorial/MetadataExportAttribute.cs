using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTutorial
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MetadataExportAttribute : ExportAttribute
    {
        public Type DeclaredType { get; private set; }

        public string Name { get; private set; }

        public MetadataExportAttribute(Type declaredType, Type contractType, string name = null)
            : base(contractType)
        {
            DeclaredType = declaredType;
            Name = name;
        }
    }
}
