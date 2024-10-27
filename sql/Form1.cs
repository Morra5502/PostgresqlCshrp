using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace sql
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost; port = 5432; database= Nemnnozko_ponoshenoe; User = danil; password = 1234;";

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SqlConnectionReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection();
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM customers";
            NpgsqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(reader);
                dataGridView1.DataSource = data;
            }
            sqlConnection.Close();
        }
    }
}
