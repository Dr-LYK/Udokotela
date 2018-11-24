using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Udokotela.Utils
{
    public class WindowLoader
    {
        public static void Show(string viewName)
        {
            Window view = (Window)Assembly.GetExecutingAssembly().CreateInstance("Udokotela.View." + viewName + "View");
            object viewModel = Assembly.GetExecutingAssembly().CreateInstance("Udokotela.ViewModel." + viewName + "ViewModel");
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
