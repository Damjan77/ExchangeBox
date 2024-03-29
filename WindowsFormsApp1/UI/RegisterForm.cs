﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Service;
using WindowsFormsApp1.Service.ServiceImpl;

namespace WindowsFormsApp1.UI
{
    public partial class RegisterForm : Form
    {
        private IUserService userService;

        public RegisterForm(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }
        public RegisterForm() : this(new UserServiceImpl()) { }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            UserRole userRoleObj = RegisterRoleComboBox.SelectedItem as UserRole;

            if (IsValidData())
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                bool isActive = ActivateUserCheckBox.Checked;
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                int roleId = userRoleObj.roleId;

                User user = new User(name, surname, isActive, username, password, roleId);
                user.name = name;
                user.surname = surname;
                user.username = username;
                user.password = userService.Encrypt(password);// Encrypt(password);
                user.roleId = roleId;

                userService.InsertDataInUserTable(user);
                this.Close();
                this.Dispose();

                LogInForm logInForm = new LogInForm();
                logInForm.Show();

            }
        }

        bool IsValidData()
        {
            //Name Logic
            bool nameFlag = true;

            if (string.IsNullOrEmpty(NameTextBox.Text.Trim()))
            {
                RegisterNameErrorProvider.SetError(NameTextBox, "Name is required!");
                nameFlag = false;
            }
            else if (NameTextBox.Text.Length > 50)
            {
                RegisterNameErrorProvider.SetError(NameTextBox, "Name is too long!");
                nameFlag = false;
            }

            if (nameFlag)
            {
                RegisterNameErrorProvider.SetError(NameTextBox, string.Empty);
                RegisterNameErrorProvider.Clear();
            }

            //Surname Logic
            bool surnameFlag = true;

            if (string.IsNullOrEmpty(SurnameTextBox.Text.Trim()))
            {
                RegisterSurnameErrorProvider.SetError(SurnameTextBox, "Surname is required!");
                surnameFlag = false;
            }
            else if (SurnameTextBox.Text.Length > 50)
            {
                RegisterSurnameErrorProvider.SetError(SurnameTextBox, "Surname is too long!");
                surnameFlag = false;
            }
            if (surnameFlag)
            {
                RegisterSurnameErrorProvider.SetError(SurnameTextBox, string.Empty);
                RegisterSurnameErrorProvider.Clear();
            }

            //Username Logic
            bool usernameFlag = true;

            if (string.IsNullOrEmpty(UsernameTextBox.Text.Trim()))
            {
                RegisterUsernameErrorProvider.SetError(UsernameTextBox, "Username is required!");
                usernameFlag = false;
            }
            else if (UsernameTextBox.Text.Length > 50)
            {
                RegisterUsernameErrorProvider.SetError(UsernameTextBox, "Username is too long!");
                usernameFlag = false;
            }
            if (usernameFlag)
            {
                RegisterUsernameErrorProvider.SetError(UsernameTextBox, string.Empty);
                RegisterUsernameErrorProvider.Clear();
            }

            //Password Logic
            bool passwordFlag = true;

            if (string.IsNullOrEmpty(PasswordTextBox.Text.Trim()))
            {
                RegisterPasswordErrorProvider.SetError(PasswordTextBox, "Password is required!");
                passwordFlag = false;
            }
            else if (PasswordTextBox.Text.Length > 50)
            {
                RegisterPasswordErrorProvider.SetError(PasswordTextBox, "Password is too long!");
                passwordFlag = false;
            }
            else if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
            {
                RegisterPasswordErrorProvider.SetError(PasswordTextBox, "Password does not compare!");
                RegisterPasswordErrorProvider.SetError(ConfirmPasswordTextBox, "Password does not compare!");
                passwordFlag = false;
            }
            if (passwordFlag)
            {
                RegisterPasswordErrorProvider.SetError(PasswordTextBox, string.Empty);
                RegisterPasswordErrorProvider.Clear();
            }

            //Confirm Password Logic
            bool confirmPasswordFlag = true;

            if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text.Trim()))
            {
                RegisterConfirmPasswordErrorProvider.SetError(ConfirmPasswordTextBox, "ConfirmPassword is required!");
                confirmPasswordFlag = false;
            }
            else if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
            {
                RegisterConfirmPasswordErrorProvider.SetError(ConfirmPasswordTextBox, "Password does not compare!");
                passwordFlag = false;
            }
            if (confirmPasswordFlag)
            {
                RegisterConfirmPasswordErrorProvider.SetError(PasswordTextBox, string.Empty);
                RegisterConfirmPasswordErrorProvider.Clear();
            }

            bool RoleFlag = true;

            if (RegisterRoleComboBox.SelectedItem == null)
            {
                RegisterRoleErrorProvider.SetError(RegisterRoleComboBox, "Select Role");
                RoleFlag = false;
            }
            if (RoleFlag)
            {
                RegisterRoleErrorProvider.SetError(RegisterRoleComboBox, string.Empty);
                RegisterRoleErrorProvider.Clear();
            }

            if (nameFlag && usernameFlag && surnameFlag && passwordFlag && confirmPasswordFlag && RoleFlag) return true;
            else return false;
        }

        private void backToLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

            LogInForm logIn = new LogInForm();
            logIn.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            using (var myDb = new Model1())
            {
                var roles = myDb.UserRoles.ToList();
                RegisterRoleComboBox.DataSource = roles;
                RegisterRoleComboBox.ValueMember = "roleId";
                RegisterRoleComboBox.DisplayMember = "roleName";
                RegisterRoleComboBox.SelectedItem = null;
            }
        }
    }
}
