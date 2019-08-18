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
        MainWindow win;
        public AddPassword(MainWindow win)
        {
            this.win = win;
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
            hash = Crypt.encrypt(hashname+hashpass, "key");

            Json.dump(typeof(AccountDataContract), AppData.Appdir + "\\" + id, new AccountDataContract(hashname, hashpass, hash));
            win.Update();
        }

        private void FildValid(object sender, TextChangedEventArgs e)
        {
            if (CheckHidden.IsChecked.Value)
                if (accountName.Text.Length > 0 && PasswordHide.Text.Length > 0)
                    SavePass.IsEnabled = true;
                else
                    SavePass.IsEnabled = false;                      
        }

        private void PasswordField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (accountName.Text.Length > 0 && PasswordField.Password.Length > 0)
                SavePass.IsEnabled = true;
            else
                SavePass.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dict = "qwertyuiopasdfghjklzxcvbnm";
            if (isLower.IsChecked.Value)
                dict += "QWERTYUIOPASDFGHJKLZXCVBNM";
            if (isDigital.IsChecked.Value)
                dict += "1234567890";
            if (isSpecial.IsChecked.Value)
                dict+= "`~!@#$%^&*()_-+={}[]\\|:;\"'<>,.?/";

            string pass=string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < SizePass.Value; i++)
                pass += dict[rnd.Next(0, dict.Length)];

            if (CheckHidden.IsChecked.Value)
               PasswordHide.Text= pass;
            else
               PasswordField.Password = pass;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win.frame.Content = "";
        }
    }
}
