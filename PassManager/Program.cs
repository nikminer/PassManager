using System;
using Gtk;
using System.IO;
namespace PassManager
{
    class AppData
    {
        static public string Appdir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.passmanager";

        static public string MastePassVariableName = "PassManager_MasterPass";

        static public bool isChange = false;
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
