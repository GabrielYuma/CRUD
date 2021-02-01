using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Data;


namespace CRUD_Alunos
{
    public class Database
    {
        static DatabaseStart databasestart = new DatabaseStart();

        public void CreateTable()
        {
            SQLiteConnection connect = databasestart.GetConnection();
            connect.Open();
            string query = @"CREATE TABLE IF NOT EXISTS FuncionarioTb (
                            ID INTEGER,
                            nomeFuncionario VARCHAR(30),
                            salarioFuncionario float,
                            telFuncionario int,
                            PRIMARY KEY (ID AUTOINCREMENT)
                        )";
            SQLiteCommand command = new SQLiteCommand(query, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public DataTable SelectCommand()
        {   

           SQLiteConnection connect = databasestart.GetConnection();
           connect.Open();

           SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM FuncionarioTb", connect);
           DataTable dt = new DataTable();
           SQLiteDataReader reader = command.ExecuteReader();
           dt.Load(reader);

           connect.Close();
           return dt;
            
        }

        public void InsertData(string NOME, float SALARIO, int TEL)
        {
            SQLiteConnection connect = databasestart.GetConnection();
            connect.Open();

            SQLiteCommand command = new SQLiteCommand(@"INSERT INTO FuncionarioTb (nomeFuncionario, salarioFuncionario, telFuncionario) VALUES (@nome, @salario, @telefone)", connect);            
            command.Parameters.AddWithValue(@"nome", NOME);
            command.Parameters.AddWithValue(@"salario", SALARIO);
            command.Parameters.AddWithValue(@"telefone", TEL);

            command.ExecuteNonQuery();
            connect.Close();
        }

        public void UpdateData(int ID, string NOME, float SALARIO, int TEL)
        {
            SQLiteConnection connect = databasestart.GetConnection();
            connect.Open();

            SQLiteCommand command = new SQLiteCommand(@"UPDATE FuncionarioTb SET nomeFuncionario = @nome, salarioFuncionario = @salario, telFuncionario = @telefone WHERE ID = @id", connect);
            command.Parameters.AddWithValue(@"nome", NOME);
            command.Parameters.AddWithValue(@"salario", SALARIO);
            command.Parameters.AddWithValue(@"telefone", TEL);
            command.Parameters.AddWithValue(@"id", ID);

            command.ExecuteNonQuery();
            connect.Close();
        }

        public void DeleteData(int ID)
        {
            SQLiteConnection connect = databasestart.GetConnection();
            connect.Open();

            SQLiteCommand command = new SQLiteCommand(@"DELETE FROM FuncionarioTb WHERE ID=@id", connect);            
            command.Parameters.AddWithValue(@"id", ID);

            command.ExecuteNonQuery();
            connect.Close();
        }
    }

}
