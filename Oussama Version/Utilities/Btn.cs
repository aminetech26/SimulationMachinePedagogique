using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows. Controls;

namespace projet.Utilities
{
    public class Btn : RadioButton
    {
        static Btn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn), new FrameworkPropertyMetadata(typeof(Btn)));
        }

    }
}
