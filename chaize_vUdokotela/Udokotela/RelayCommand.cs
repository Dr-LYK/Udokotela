﻿using System;
using System.Windows.Input;
using System.Diagnostics;

namespace Udokotela
{
    public class RelayCommand : ICommand
    {
        #region variables
        /// <summary>
        /// Action à executer
        /// </summary>
        readonly Action<object> _execute;
        /// <summary>
        /// Test pour savoir si on peut executer la commande
        /// </summary>
        readonly Predicate<object> _canExecute;
        #endregion 


        #region Constructeur
        /// <summary>
        /// Crée une nouvelle commande que l'on peut toujours executer
        /// </summary>
        /// <param name="execute">Le code à executer</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {}

        /// <summary>
        /// Crée une nouvelle commande
        /// </summary>
        /// <param name="execute">le code à executer</param>
        /// <param name="canExecute">Si on peut executer ou pas</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }
        #endregion


        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion // ICommand Members
    }
}