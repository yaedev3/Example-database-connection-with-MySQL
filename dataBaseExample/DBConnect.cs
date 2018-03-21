/**
 * Clase DBConnect
 * Esta clase establece la coneccion con la base de datos por MySQL
 * Creada el 1 de Septiembre del 2017
 * Autor - Gerardo Arturo Enriquez Capetillo
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dataBaseExample
{
    class DBConnect
    {
        private MySqlConnection connection;
        private String server, database, username, password;

        public DBConnect(String username, String password)
        {
            server = "localhost";
            this.username = username;
            this.password = password;
        }

        //Initialize values
        private void Initialize()
        {
            String connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public void OpenConnection(String name)
        {
            database = name;
            Initialize();
            connection.Open();
        }

        //Close connection
        public void CloseConnection()
        {
            connection.Close();
        }

        //Create a new table
        public void CreateTable(String name)
        {
            MySqlCommand command = new MySqlCommand("create table " + name + " (id INT)", connection );
            command.ExecuteNonQuery();
        }
    }
}
