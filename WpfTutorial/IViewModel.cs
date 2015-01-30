using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTutorial
{
    public interface IViewModel
    {
        void OnLoaded(object sender);
    }
}
