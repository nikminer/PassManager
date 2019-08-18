using System;
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

namespace PassManager
{
    /// <summary>
    /// Логика взаимодействия для AddPassword.xaml
    /// </summary>
    public partial class AddPassword : Page
    {
        public AddPassword()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordField.Visibility = Visibility.Hidden;
            PasswordHide.Visibility = Visibility.Visible;
            PasswordHide.Text = PasswordField.Password;
            PasswordHide.Focus();
        }

        private void CheckHidden_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordField.Visibility = Visibility.Visible;
            PasswordHide.Visibility = Visibility.Hidden;
            PasswordField.Password = PasswordHide.Text;
            PasswordField.Focus();
        }

        private void SavePass_Click(object sender, RoutedEventArgs e)
        {
            string pass,hashname,hashpass,hash;
            if (CheckHidden.IsChecked.Value)
                pass = PasswordHide.Text;
            else
                pass = PasswordField.Password;
            Guid id = Guid.NewGuid();

            hashname = Crypt.encrypt(accountName.Text, "key");
            hashpass = Crypt.encrypt(pass, "key");
            hash = Crypt.encrypt(id.ToString(), "key");

            Json.dump(typeof(Account), AppData.Appdir + "\\" + id, new Account(hashname, hashpass, hash));
        }

        private void FildValid(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordField_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
