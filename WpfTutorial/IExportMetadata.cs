using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTutorial
{
    public interface IExportMetadata
    {
        Type DeclaredType { get; }

        string Name { get; }
    }
}
