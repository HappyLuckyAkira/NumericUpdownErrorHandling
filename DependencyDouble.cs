using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppErrorHandling
{
    class DependencyDouble:DependencyObject
    {
        //依存関係プロパティ
        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register("Value", typeof(double), typeof(DependencyDouble));

        //CLRプロパティ
        public double Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
    }
}
