using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CRUD_Alunos
{
    public class LoginData
    {
        static Database database = new Database();

        public void CreateTabe()
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=database.sqlite3");
            connect.Open();            
            SQLiteCommand command = new SQLiteCommand(@"CREATE TABLE IF NOT EXISTS DadosLogin (
                                                      ID INTEGER,
                                                      username VARCHAR(30),
                                                      password VARCHAR(30),
                                                      PRIMARY KEY (ID AUTOINCREMENT)
                                                      )", connect);
                     
            command.ExecuteNonQuery();
            connect.Close();
        }

        public Boolean ConfereLogin(string USER, string PASS)
        {
            
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=database.sqlite3");
            connect.Open();
            SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM DadosLogin WHERE username=@username AND password=@password", connect);
            command.Parameters.AddWithValue("@username", USER);
            command.Parameters.AddWithValue("@password", PASS);
            command.ExecuteNonQuery();
            var teste = command.ExecuteScalar();
            if (teste == null)
            {
                return false;
            }

            return true;
        }

        public void CadastraUsuario(string USER, string PASS)
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=database.sqlite3");
            connect.Open();
            SQLiteCommand command = new SQLiteCommand(@"INSERT INTO DadosLogin (username, password) VALUES (@USER, @PASS)", connect);
            command.Parameters.AddWithValue("@USER", USER);
            command.Parameters.AddWithValue("@PASS", PASS);
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
