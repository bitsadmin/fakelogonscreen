using System;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;

/*
Author: @bitsadmin
Website: https://github.com/bitsadmin
License: BSD 3-Clause
*/

namespace FakeLogonScreen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize new screen
            LogonScreen s = new LogonScreen();

            // Set background
            string imagePath = @"C:\Windows\Web\Screen\img100.jpg";
            if (File.Exists(imagePath))
                s.BackgroundImage = Image.FromFile(imagePath);
            else
                s.BackColor = Color.FromArgb(0, 90, 158);

            // Set username
            s.Username = Environment.UserName;
            s.Context = ContextType.Machine;
            try
            {
                UserPrincipal user = UserPrincipal.Current;
                s.Username = user.SamAccountName;
                s.DisplayName = user.DisplayName;
                s.Context = user.ContextType;
            }
            catch (Exception)
            { }

            // Show
            Application.Run(s);
        }
    }
}
