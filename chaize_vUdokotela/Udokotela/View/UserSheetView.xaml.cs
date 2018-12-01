using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for UserSheetView.xaml
    /// </summary>
    public partial class UserSheetView : UserControl
    {
        public UserSheetView()
        {
            InitializeComponent();
            this.DataContext = new UserSheetViewModel();
        }
    }
}
