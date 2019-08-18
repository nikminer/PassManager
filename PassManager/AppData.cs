using System;

namespace PassManager
{
    class AppData
    {
        static public readonly string Appdir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.passmanager";

        static public readonly string MastePassVariableName = "PassManager_MasterPass";

        static public bool isChange = false;
    }
}
