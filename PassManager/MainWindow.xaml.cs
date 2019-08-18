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
            frame.NavigationService.Navigate(new Account((AccountData)accounts.SelectedItem, this));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            frame.Content = "";
            accounts.Items.Clear();
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
                    AccountDataContract account = (AccountDataContract)Json.load(typeof(AccountDataContract), fs);
                    
                    if (account.name + account.password == Crypt.decrypt(account.hash, Environment.GetEnvironmentVariable(AppData.MastePassVariableName)))
                        accounts.Items.Add(new AccountData( Crypt.decrypt(account.name, Environment.GetEnvironmentVariable(AppData.MastePassVariableName)), account.password,i.Split('\\').Last()));

                    var a = new ListBoxItem();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            accounts.SelectedIndex = -1;
            frame.NavigationService.Navigate(new AddPassword(this));
        }
    }

    public class AccountData
    {
        public string name { set; get; }
        public string password { set; get; }
        public string id { set; get; }

        public AccountData(string name,string password,string id)
        {
            this.name = name;
            this.password = password;
            this.id = id;
        }
    }
}
