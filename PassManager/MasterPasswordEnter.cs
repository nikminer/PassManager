using System;
using System.Security.Cryptography;

namespace PassManager
{
    public partial class MasterPasswordEnter : Gtk.Dialog
    {
        public MasterPasswordEnter()
        {
            this.Build();
        }

        protected void OnButtonCancelClicked(object sender, EventArgs e)
        {
            if (AppData.isChange)
                OnClose();
            else
                Gtk.Application.Quit();
        }

        protected void OnButtonOkClicked(object sender, EventArgs e)
        { 
            string hash = string.Empty;
            foreach (byte i in new SHA512Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(PassBox.Text)))
                hash += i.ToString("X2");
            Environment.SetEnvironmentVariable(AppData.MastePassVariableName, hash);

            hash = string.Empty;

            hash = Environment.GetEnvironmentVariable(AppData.MastePassVariableName);
        }


    }
}
