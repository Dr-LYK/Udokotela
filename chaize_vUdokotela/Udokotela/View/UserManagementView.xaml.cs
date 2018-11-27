using System.Windows.Controls;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for UserManagementView.xaml
    /// </summary>
    public partial class UserManagementView : UserControl
    {
        public UserManagementView()
        {
            InitializeComponent();
            this.DataContext = new UserManagementViewModel();
        }
    }
}
