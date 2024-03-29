﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Udokotela.ServicePatient;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for PatientSheetView.xaml
    /// </summary>
    public partial class PatientSheetView : UserControl
    {
        public PatientSheetView(Patient _patientToDisplay, MainWindowViewModel mainView = null)
        {
            InitializeComponent();
            this.DataContext = new PatientSheetViewModel(_patientToDisplay, mainView);
        }
    }
}
