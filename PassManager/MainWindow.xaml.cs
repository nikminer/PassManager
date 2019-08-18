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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(AppData.Appdir);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(AppData.Appdir);
                files = Directory.GetFiles(AppData.Appdir);
            }

            
            foreach (string i in files)
            {
                using (FileStream fs = new FileStream(i, FileMode.OpenOrCreate))
                {
                    Account account =(Account) Json.load(typeof(Account), fs);

                    if (i.Split('\\').Last() == Crypt.decrypt(account.hash, "key"))
                        accounts.Items.Add(Crypt.decrypt(account.name, "key"));
                    
                    var a = new ListBoxItem();
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("AddPassword.xaml", UriKind.Relative));
        }
    }
}
