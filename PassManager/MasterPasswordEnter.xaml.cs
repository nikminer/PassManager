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
using System.Security.Cryptography;

namespace PassManager
{
    /// <summary>
    /// Логика взаимодействия для MasterPasswordEnter.xaml
    /// </summary>
    public partial class MasterPasswordEnter : Window
    {
        public MasterPasswordEnter()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.isChange)
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
            else
                Application.Current.Shutdown();

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

            Environment.SetEnvironmentVariable(AppData.MastePassVariableName, Crypt.HashSHA512(PassBox.Password));
            
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
