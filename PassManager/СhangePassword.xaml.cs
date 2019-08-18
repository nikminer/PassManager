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
using System.Windows.Shapes;

namespace PassManager
{
    /// <summary>
    /// Логика взаимодействия для СhangePassword.xaml
    /// </summary>
    public partial class СhangePassword : Window
    {
        MainWindow win;
        AccountData account;
        public СhangePassword(AccountData account,MainWindow win)
        {
            this.account = account;
            this.win = win;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            accountname.Text = account.name;
            Password.Text = Crypt.decrypt(account.password, "key");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string hashname, hashpass, hash;
            hashname = Crypt.encrypt(accountname.Text, "key");
            hashpass = Crypt.encrypt(Password.Text, "key");
            hash = Crypt.encrypt(hashname + hashpass, "key");
            Json.dump(typeof(AccountDataContract), AppData.Appdir + "\\" + account.id, new AccountDataContract(hashname, hashpass, hash));
            win.Update();

            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string dict = "qwertyuiopasdfghjklzxcvbnm";
            if (isLower.IsChecked.Value)
                dict += "QWERTYUIOPASDFGHJKLZXCVBNM";
            if (isDigital.IsChecked.Value)
                dict += "1234567890";
            if (isSpecial.IsChecked.Value)
                dict += "`~!@#$%^&*()_-+={}[]\\|:;\"'<>,.?/";

            Password.Text = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < SizePass.Value; i++)
                Password.Text += dict[rnd.Next(0, dict.Length)];
        }
    }
}
