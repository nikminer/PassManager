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
using System.IO;

namespace PassManager
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        AccountData account;
        bool isCrtpt = true;
        MainWindow win;
        public Account(AccountData account,MainWindow win)
        {
            this.account = account;
            this.win = win;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PasswordTitle.Text = account.password;
                AccountLabel.Content = account.name;
            }catch (NullReferenceException)
            {
                win.frame.Content = "";
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isCrtpt)
            {
                PasswordTitle.Text = Crypt.decrypt(account.password, "key");
                cryptBtn.Content = "Скрыть пароль";
            }
            else
            {
                PasswordTitle.Text = account.password;
                cryptBtn.Content = "Показать пароль";
            }
                
            isCrtpt = !isCrtpt;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Crypt.decrypt(account.password, "key"));
            MessageBox.Show("Пароль скопирован в буфер обмена");
        }

        private void CloseAccount()
        {
            win.Update();
            win.frame.Content = "";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            if (MessageBox.Show("Вы действительно хотите удалить этот аккаунт?","PassManager",MessageBoxButton.YesNo,MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                string path = AppData.Appdir + "\\" + account.id;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    MessageBox.Show("Аккаунт успешно удалён", "PassManager", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseAccount();
                }
                else
                {
                    MessageBox.Show("Аккаунт ненайден или уже удалён", "PassManager", MessageBoxButton.OK, MessageBoxImage.Error);
                    CloseAccount();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CloseAccount();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            СhangePassword chwin = new СhangePassword(account, win);
            chwin.Owner = win;
            chwin.Show();
        }
    }
}
