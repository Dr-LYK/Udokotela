﻿using System.Windows.Controls;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView(MainWindowViewModel mainView)
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel(mainView);
        }
    }
}
