﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Service;
using WindowsFormsApp1.Service.ServiceImpl;

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        private IUserService userService;

        public UserForm(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        public UserForm() : this(new UserServiceImpl()) { }

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.tableTableAdapter.Fill(this.dataSet1.Table);
            getAllData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void getAllData()
        {
            UsersDataGridView.DataSource = userService.GetAllData();
        }

        public void DRYUser(object sender, EventArgs e, bool IamExisting)
        {
            User usr = new User();

            if (IamExisting)
            {
                var selectedRow = UsersDataGridView.SelectedRows[0];
                usr.userId = Convert.ToInt32(selectedRow.Cells["userId"].Value);
                usr.surname = SurnameTextBox.Text.ToString();
                usr.isActive = CheckBoxForUserActivation.Checked;
                usr.name = NameTextBox1.Text.ToString();
                usr.username = UsernameTextBox.Text.ToString();
                usr.password = userService.Encrypt(PasswordTextBox.Text.ToString());

                userService.UpdateDataInUserTable(usr);
            }
            else
            {
                usr.surname = SurnameTextBox.Text.ToString();
                usr.isActive = CheckBoxForUserActivation.Checked;
                usr.name = NameTextBox1.Text.ToString();
                usr.username = UsernameTextBox.Text.ToString();
                usr.password = userService.Encrypt(PasswordTextBox.Text.ToString());

                userService.InsertDataInUserTable(usr);
            }

            getAllData();
        }

        private bool isValidData()
        {
            //Name Logic
            bool nameFlag = true;

            if (string.IsNullOrEmpty(NameTextBox1.Text.Trim()))
            {
                errorProvider1.SetError(NameTextBox1, "Name is required!");
                nameFlag = false;
            }
            else if (NameTextBox1.Text.Length > 50)
            {
                errorProvider1.SetError(NameTextBox1, "Name is too long!");
                nameFlag = false;
            }
            else
            {
                errorProvider1.SetError(NameTextBox1, string.Empty);
                errorProvider1.Clear();
            }

            //Surname Logic
            bool surnameFlag = true;

            if (string.IsNullOrEmpty(SurnameTextBox.Text.Trim()))
            {
                errorProviderUserSurname.SetError(SurnameTextBox, "Surname is required!");
                surnameFlag = false;
            }
            else if (SurnameTextBox.Text.Length > 50)
            {
                errorProviderUserSurname.SetError(SurnameTextBox, "Surname is too long!");
                surnameFlag = false;
            }
            else
            {
                errorProviderUserSurname.SetError(SurnameTextBox, string.Empty);
                errorProviderUserSurname.Clear();
            }

            //Username Logic
            bool usernameFlag = true;
            if (string.IsNullOrEmpty(UsernameTextBox.Text.Trim()))
            {
                UsernameErrorProvider.SetError(UsernameTextBox, "Username is required!");
                usernameFlag = false;
            }
            else if (UsernameTextBox.Text.Length > 50)
            {
                UsernameErrorProvider.SetError(UsernameTextBox, "Username is too long!");
                usernameFlag = false;
            }
            else
            {
                UsernameErrorProvider.SetError(UsernameTextBox, string.Empty);
                UsernameErrorProvider.Clear();
            }

            //Password Logic
            bool passwordFlag = true;

            if (string.IsNullOrEmpty(PasswordTextBox.Text.Trim()))
            {
                PasswordErrorProvider.SetError(PasswordTextBox, "Password is required!");
                passwordFlag = false;
            }
            else if (UsernameTextBox.Text.Length > 50)
            {
                PasswordErrorProvider.SetError(PasswordTextBox, "Password is too long!");
                passwordFlag = false;
            }
            else
            {
                PasswordErrorProvider.SetError(PasswordTextBox, string.Empty);
                PasswordErrorProvider.Clear();
            }

            if (nameFlag && surnameFlag && usernameFlag && passwordFlag) return true;
            else return false;
        }


        private void AddNewUserButton_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                DRYUser(sender, e, false);
                clearData();
            }
        }

        private void SaveUserButton_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                DRYUser(sender, e, true);
                clearData();
            }

        }

        private void UsersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UsersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Dokolku se klikne bilo kade na dataGridiew
            UsersDataGridView.CurrentCell.Selected = true;
            NameTextBox1.Text = UsersDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            SurnameTextBox.Text = UsersDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            CheckBoxForUserActivation.Checked = (bool)UsersDataGridView.Rows[e.RowIndex].Cells[3].Value;
            UsernameTextBox.Text = UsersDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            //PasswordTextBox.Text = UsersDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void clearData()
        {
            NameTextBox1.Text = "";
            SurnameTextBox.Text = "";
            CheckBoxForUserActivation.Checked = false;
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        //private void SearchTextBox_Enter(object sender, EventArgs e)
        //{
        //    if (SearchTextBox.Text == "Search for User")
        //    {
        //        SearchTextBox.Text = "";
        //        SearchTextBox.ForeColor = System.Drawing.Color.Black;
        //    }

        //}

        //private void SearchTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (SearchTextBox.Text == "")
        //    {
        //        SearchTextBox.Text = "Search for User";
        //        SearchTextBox.ForeColor = System.Drawing.Color.Gray;
        //    }
        //}

        private void SearchButton_Click(object sender, EventArgs e)
        {
            List<User> users = userService.searchUsers(SearchTextBox.Text);
            if (users != null)
            {
                UsersDataGridView.DataSource = users;
            }
        }

        private void AllUsersButton_Click(object sender, EventArgs e)
        {
            UsersDataGridView.DataSource = userService.GetAllData();
        }
        
    }
}
