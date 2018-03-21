using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dataBaseExample
{
    public partial class Form1 : Form
    {
        private DBConnect connection;

        public Form1()
        {
            InitializeComponent();
            textBoxUserName.Text = "user";
            textBoxPassword.Text = "user";
            textBoxDB.Text = "hola";
            connection = new DBConnect();
        }

        private void openDB()
        {
            try
            {
                connection.OpenConnection(textBoxDB.Text);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
            }
            
        }

        private void closeDB()
        {
            try
            {
                connection.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxDB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDB.Checked)
                this.openDB();
            else this.closeDB();
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                connection.CreateTable(textBoxTable.Text);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
