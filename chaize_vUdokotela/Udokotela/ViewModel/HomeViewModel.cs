﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.ServiceUser;
using Udokotela.Utils;
using Udokotela.View;

namespace Udokotela.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables
        private CSUser _userService;
        #endregion

        #region Properties
        /// <summary>
        /// Commande pour ajouter un utilisateur.
        /// </summary>
        public ICommand AddUserCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des utilisateurs.
        /// </summary>
        public ICommand UserManagementCommand { get; set; }

        /// <summary>
        /// Commande pour ajouter un patient.
        /// </summary>
        public ICommand AddPatientCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des patients.
        /// </summary>
        public ICommand PatientManagementCommand { get; set; }

        /// <summary>
        /// Commande pour accéder à lq visualisation des données en temps réel. 
        /// </summary>
        public ICommand LiveDataCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de la page d'accueil.
        /// </summary>
        public HomeViewModel()
        {
            base.DisplayName = "Udokotela - Accueil";
            this._userService = new CSUser();

            AddUserCommand = new RelayCommand(param => AddUser(), param => MainWindowViewModel.CheckUserRole());
            AddPatientCommand = new RelayCommand(param => AddPatient(), param => MainWindowViewModel.CheckUserRole());
            UserManagementCommand = new RelayCommand(param => UserManagement(), param => true);
            PatientManagementCommand = new RelayCommand(param => PatientManagement(), param => true);
            LiveDataCommand = new RelayCommand(param => LiveData(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant à l'utilisateur d'ajouter un nouvel utilisateur.
        /// </summary>
        private void AddUser()
        {
            WindowLoader.Show("AddUser");
            /* TODO */
        }
        
        /// <summary>
        /// Action permettant à l'utilisateur d'ajouter un nouveau patient.
        /// </summary>
        private void AddPatient()
        {
            WindowLoader.Show("AddPatient");
            /* TODO */
        }

        /// <summary>
        /// Action permettant à l'utilisateur d'accéder à la gestion des utilisateurs.
        /// </summary>
        private void UserManagement()
        {
            /* TODO */
        }

        /// <summary>
        /// Action permettant à l'utilisateur d'accéder à la gestion des patients.
        /// </summary>
        private void PatientManagement()
        {
            /* TODO */
        }

        /// <summary>
        /// Action permettant à l'utilisateur de visualiser les données en temps réel.
        /// </summary>
        private void LiveData()
        {
            /* TODO */
        }
        #endregion
    }
}
