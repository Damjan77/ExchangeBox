﻿namespace WindowsFormsApp1.UI
{
    partial class LogInForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox_LogIn = new System.Windows.Forms.TextBox();
            this.PasswordTextBox_LogIn = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.UsernameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PasswordErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.WelcomeUserLabel = new System.Windows.Forms.Label();
            this.LogInPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorProvider)).BeginInit();
            this.LogInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.WelcomeLabel.Location = new System.Drawing.Point(300, 69);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(368, 32);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome to ExchangeBox";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PasswordLabel.Location = new System.Drawing.Point(145, 258);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(120, 29);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.UsernameLabel.Location = new System.Drawing.Point(145, 184);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(124, 29);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username";
            // 
            // UserNameTextBox_LogIn
            // 
            this.UserNameTextBox_LogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameTextBox_LogIn.Location = new System.Drawing.Point(325, 184);
            this.UserNameTextBox_LogIn.Name = "UserNameTextBox_LogIn";
            this.UserNameTextBox_LogIn.Size = new System.Drawing.Size(299, 26);
            this.UserNameTextBox_LogIn.TabIndex = 3;
            // 
            // PasswordTextBox_LogIn
            // 
            this.PasswordTextBox_LogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox_LogIn.Location = new System.Drawing.Point(325, 262);
            this.PasswordTextBox_LogIn.Name = "PasswordTextBox_LogIn";
            this.PasswordTextBox_LogIn.PasswordChar = '*';
            this.PasswordTextBox_LogIn.Size = new System.Drawing.Size(299, 26);
            this.PasswordTextBox_LogIn.TabIndex = 4;
            // 
            // LogInButton
            // 
            this.LogInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInButton.Location = new System.Drawing.Point(391, 325);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(161, 54);
            this.LogInButton.TabIndex = 5;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Location = new System.Drawing.Point(391, 527);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(161, 54);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RegisterLabel.Location = new System.Drawing.Point(258, 459);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(448, 29);
            this.RegisterLabel.TabIndex = 7;
            this.RegisterLabel.Text = "If you don\'t have account please Register";
            // 
            // UsernameErrorProvider
            // 
            this.UsernameErrorProvider.ContainerControl = this;
            // 
            // PasswordErrorProvider
            // 
            this.PasswordErrorProvider.ContainerControl = this;
            // 
            // WelcomeUserLabel
            // 
            this.WelcomeUserLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WelcomeUserLabel.AutoSize = true;
            this.WelcomeUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeUserLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.WelcomeUserLabel.Location = new System.Drawing.Point(386, 405);
            this.WelcomeUserLabel.Name = "WelcomeUserLabel";
            this.WelcomeUserLabel.Size = new System.Drawing.Size(115, 29);
            this.WelcomeUserLabel.TabIndex = 8;
            this.WelcomeUserLabel.Text = "Welcome";
            this.WelcomeUserLabel.Visible = false;
            // 
            // LogInPanel
            // 
            this.LogInPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInPanel.BackColor = System.Drawing.Color.Transparent;
            this.LogInPanel.Controls.Add(this.UsernameLabel);
            this.LogInPanel.Controls.Add(this.WelcomeUserLabel);
            this.LogInPanel.Controls.Add(this.WelcomeLabel);
            this.LogInPanel.Controls.Add(this.RegisterLabel);
            this.LogInPanel.Controls.Add(this.PasswordLabel);
            this.LogInPanel.Controls.Add(this.RegisterButton);
            this.LogInPanel.Controls.Add(this.UserNameTextBox_LogIn);
            this.LogInPanel.Controls.Add(this.LogInButton);
            this.LogInPanel.Controls.Add(this.PasswordTextBox_LogIn);
            this.LogInPanel.Location = new System.Drawing.Point(12, 12);
            this.LogInPanel.Name = "LogInPanel";
            this.LogInPanel.Size = new System.Drawing.Size(903, 710);
            this.LogInPanel.TabIndex = 9;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(941, 734);
            this.Controls.Add(this.LogInPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsernameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorProvider)).EndInit();
            this.LogInPanel.ResumeLayout(false);
            this.LogInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox_LogIn;
        private System.Windows.Forms.TextBox PasswordTextBox_LogIn;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.ErrorProvider UsernameErrorProvider;
        private System.Windows.Forms.ErrorProvider PasswordErrorProvider;
        private System.Windows.Forms.Label WelcomeUserLabel;
        private System.Windows.Forms.Panel LogInPanel;
    }
}