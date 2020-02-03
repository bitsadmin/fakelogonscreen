namespace FakeLogonScreen
{
    partial class LogonScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mtbPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.llblResetPassword = new System.Windows.Forms.LinkLabel();
            this.llblSigninOptions = new System.Windows.Forms.LinkLabel();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.pPassword = new System.Windows.Forms.Panel();
            this.pbSubmit = new System.Windows.Forms.PictureBox();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.tlpControls.SuspendLayout();
            this.pPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbPassword
            // 
            this.mtbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mtbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbPassword.Location = new System.Drawing.Point(51, 12);
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.Size = new System.Drawing.Size(200, 26);
            this.mtbPassword.TabIndex = 1;
            this.mtbPassword.UseSystemPasswordChar = true;
            this.mtbPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbPassword_KeyUp);
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semilight", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(3, 206);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(694, 106);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "User";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llblResetPassword
            // 
            this.llblResetPassword.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.llblResetPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblResetPassword.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.llblResetPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblResetPassword.LinkColor = System.Drawing.Color.White;
            this.llblResetPassword.Location = new System.Drawing.Point(3, 403);
            this.llblResetPassword.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.llblResetPassword.Name = "llblResetPassword";
            this.llblResetPassword.Size = new System.Drawing.Size(694, 23);
            this.llblResetPassword.TabIndex = 2;
            this.llblResetPassword.TabStop = true;
            this.llblResetPassword.Text = "Reset password";
            this.llblResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llblSigninOptions
            // 
            this.llblSigninOptions.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.llblSigninOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblSigninOptions.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.llblSigninOptions.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblSigninOptions.LinkColor = System.Drawing.Color.White;
            this.llblSigninOptions.Location = new System.Drawing.Point(3, 441);
            this.llblSigninOptions.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.llblSigninOptions.Name = "llblSigninOptions";
            this.llblSigninOptions.Size = new System.Drawing.Size(694, 50);
            this.llblSigninOptions.TabIndex = 3;
            this.llblSigninOptions.TabStop = true;
            this.llblSigninOptions.Text = "Sign-in options";
            this.llblSigninOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpControls
            // 
            this.tlpControls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpControls.AutoSize = true;
            this.tlpControls.BackColor = System.Drawing.Color.Transparent;
            this.tlpControls.ColumnCount = 1;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.Controls.Add(this.pPassword, 0, 2);
            this.tlpControls.Controls.Add(this.llblSigninOptions, 0, 5);
            this.tlpControls.Controls.Add(this.llblResetPassword, 0, 4);
            this.tlpControls.Controls.Add(this.lblUsername, 0, 1);
            this.tlpControls.Controls.Add(this.pbUser, 0, 0);
            this.tlpControls.Controls.Add(this.lblError, 0, 3);
            this.tlpControls.Location = new System.Drawing.Point(42, 257);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 7;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpControls.Size = new System.Drawing.Size(700, 511);
            this.tlpControls.TabIndex = 2;
            // 
            // pPassword
            // 
            this.pPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pPassword.Controls.Add(this.pbSubmit);
            this.pPassword.Controls.Add(this.mtbPassword);
            this.pPassword.Location = new System.Drawing.Point(192, 315);
            this.pPassword.Name = "pPassword";
            this.pPassword.Size = new System.Drawing.Size(315, 50);
            this.pPassword.TabIndex = 3;
            // 
            // pbSubmit
            // 
            this.pbSubmit.Image = global::FakeLogonScreen.Properties.Resources.SubmitIcon;
            this.pbSubmit.Location = new System.Drawing.Point(251, 12);
            this.pbSubmit.Name = "pbSubmit";
            this.pbSubmit.Size = new System.Drawing.Size(26, 26);
            this.pbSubmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSubmit.TabIndex = 2;
            this.pbSubmit.TabStop = false;
            this.pbSubmit.Click += new System.EventHandler(this.pbSubmit_Click);
            // 
            // pbUser
            // 
            this.pbUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbUser.Image = global::FakeLogonScreen.Properties.Resources.UserIcon;
            this.pbUser.Location = new System.Drawing.Point(250, 3);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(200, 200);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUser.TabIndex = 4;
            this.pbUser.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(3, 368);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(694, 20);
            this.lblError.TabIndex = 5;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogonScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 811);
            this.ControlBox = false;
            this.Controls.Add(this.tlpControls);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogonScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Windows Logon Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Screen_FormClosing);
            this.Load += new System.EventHandler(this.Screen_Load);
            this.tlpControls.ResumeLayout(false);
            this.tlpControls.PerformLayout();
            this.pPassword.ResumeLayout(false);
            this.pPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbPassword;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.LinkLabel llblResetPassword;
        private System.Windows.Forms.LinkLabel llblSigninOptions;
        private System.Windows.Forms.Panel pPassword;
        private System.Windows.Forms.PictureBox pbSubmit;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblUsername;
    }
}

