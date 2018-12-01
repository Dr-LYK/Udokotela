using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Udokotela.ServiceUser;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for UserSheetView.xaml
    /// </summary>
    public partial class UserSheetView : UserControl
    {
        public UserSheetView(User _userToDisplay, MainWindowViewModel mainView = null)
        {
            InitializeComponent();
            this.DataContext = new UserSheetViewModel(_userToDisplay, mainView);
        }
    }
}
