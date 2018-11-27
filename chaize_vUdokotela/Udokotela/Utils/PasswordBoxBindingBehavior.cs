using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace Udokotela.Utils
{
    public class PasswordBoxBindingBehavior : Behavior<PasswordBox>
    {
        #region Variables
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(SecureString), typeof(PasswordBoxBindingBehavior), new PropertyMetadata(null));
        #endregion

        #region Properties
        public SecureString Password
        {
            get
            {
                return (SecureString)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }
        #endregion

        #region Methods
        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += OnPasswordBoxValueChanged;
        }

        private void OnPasswordBoxValueChanged(object sender, RoutedEventArgs e)
        {
            var binding = BindingOperations.GetBindingExpression(this, PasswordProperty);
            if (binding != null)
            {
                PropertyInfo property = binding.DataItem.GetType().GetProperty(binding.ParentBinding.Path.Path);
                if (property != null)
                {
                    property.SetValue(binding.DataItem, AssociatedObject.SecurePassword, null);
                }
            }
        }
        #endregion
    }
}
