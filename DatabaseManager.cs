using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simple_Sql_Example
{
    public class DatabaseManager
    {
        private string connectionString = "Server=localhost;Database=SimpleExample;Uid=root;Pwd=1278ilbeyli;";

        public MySqlConnection GetConnection() // veri tabani baglantisini acmak icin 
        {
            return new MySqlConnection(connectionString);
        }

        public void InsertIntoPersons(string NameColumn, string NameValue, string LastNameColumn, string LastNameValue)
        {
            string query = "INSERT INTO Persons(name, lastName) VALUES (@name, @lastName)";
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(NameColumn, NameValue);
                    command.Parameters.AddWithValue(LastNameColumn, LastNameValue);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataFromPersons()
        {
            string query = "SELECT * FROM Persons";
            using (var connection = GetConnection())
            {
                var dataTable = new DataTable();
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
        }

        public void DeletePerson(string name, string lastname)
        {
            string query = "DELETE FROM Persons WHERE name=@name AND lastName=@lastname";  // srogu yapisini olsuturduk
            using (var connection = GetConnection())   //veri tabani baglantisini acmak icin getconncetion methodunu cagirdik
            {
                using (var command = new MySqlCommand(query, connection))  // sql komutunu tanimlamak icin 
                {
                    command.Parameters.AddWithValue("@name", name);  // parametreleri yerleri ile doldurmak icin 
                    command.Parameters.AddWithValue("@lastname", lastname);

                    connection.Open(); // veri baglantisini actik 

                    command.ExecuteNonQuery();  
                }
            }
        }

    }
}
