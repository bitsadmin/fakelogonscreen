using System;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

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

            // Set username
            string SID = string.Empty;
            try
            {
                UserPrincipal user = UserPrincipal.Current;
                s.Username = user.SamAccountName;
                s.DisplayName = user.DisplayName;
                SID = user.Sid.Value;
                s.Context = user.ContextType;
            }
            catch (Exception)
            {
                s.Username = Environment.UserName;
                s.Context = ContextType.Machine;
            }

            // Set background
            string imagePath = GetImagePath(SID) ?? @"C:\Windows\Web\Screen\img100.jpg";
            if (File.Exists(imagePath))
                s.BackgroundImage = Image.FromFile(imagePath);
            else
                s.BackColor = Color.FromArgb(0, 90, 158);

            // Show
            Application.Run(s);
        }

        static string GetImagePath(string SID)
        {
            string foundImage = null;

            try
            {
                // Open registry, if path exists
                string regPath = string.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\SystemProtectedUserData\{0}\AnyoneRead\LockScreen", SID);
                RegistryKey regLockScreen = Registry.LocalMachine.OpenSubKey(regPath);
                if (regLockScreen == null)
                    return null;

                // Obtain lock screen index
                string imageOrder = (string)regLockScreen.GetValue(null);
                int ord = (int)imageOrder[0];

                // A = 65 < N = 78 < Z = 90
                // Default image is used
                if (ord > 78)
                {
                    string webScreenPath = @"C:\Windows\Web\Screen";
                    List<string> webScreenFiles = new List<string>(Directory.GetFiles(webScreenPath, "img*"));
                    string image = string.Format("img{0}", ord + 10 + (90 - ord) * 2);
                    foundImage = (from name
                                  in webScreenFiles
                                  where name.StartsWith(string.Format(@"{0}\{1}", webScreenPath, image))
                                  select name).SingleOrDefault();
                }
                // Custom image is used
                else
                {
                    string customImagePath = string.Format(@"{0}\Microsoft\Windows\SystemData\{1}\ReadOnly", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), SID);
                    string customLockScreenPath = string.Format(@"{0}\LockScreen_{1}", customImagePath, imageOrder[0]);
                    foundImage = Directory.GetFiles(customLockScreenPath)[0];
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return foundImage;
        }
    }
}
