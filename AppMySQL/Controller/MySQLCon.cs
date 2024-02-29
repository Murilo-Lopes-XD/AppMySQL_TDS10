using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using AppMySQL.Models;

namespace AppMySQL.Controller
{
    public class MySQLCon
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb.MucaLopesDB_TDS10;user=freedb_MucaLopes;password=$wm7!EMhj6xRxZ5";

        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listapessoas = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoa pessoa = new Pessoa()
                            {
                                ID = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Idade = reader.GetString(2),
                                Cidade = reader.GetString(3),
                            };
                            listapessoas.Add(pessoa);
                        }
                    }
                }
                con.Close();
                return listapessoas;
            }
        }

        public static void InserirPessoa(string nome, string idade, string cidade)
        {
            string sql = "INSERT INTO pessoa(Nome,Idade,Cidade) VALUES (@Nome,@Idade,@Cidade)";
        }
    }
}
