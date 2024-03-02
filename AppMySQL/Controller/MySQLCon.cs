using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using AppMySQL.Models;
using System.Xml.Serialization;

namespace AppMySQL.Controller
{
    public class MySQLCon
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb.MucaLopesDB_TDS10;user=freedb_MucaLopes;password=kwsdhj5S?pnKb92";

        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listapessoas = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
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
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@Idade", MySqlDbType.VarChar).Value = idade;
                    cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = cidade;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void AtualizarPessoa(Pessoa pessoa)
        {
            string sql = "UPDATE pessoa SET Nome=@Nome, Idade=@Idade, Cidade=@Cidade WHERE ID=@ID";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = pessoa.Nome;
                        cmd.Parameters.Add("@Idade", MySqlDbType.VarChar).Value = pessoa.Idade;
                        cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = pessoa.Cidade;
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = pessoa.ID;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void ExcluirPessoa(Pessoa pessoa)
        {
            string sql = "DELETE FROM Pessoa WHERE ID=@ID";
            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand( sql, con))
                {
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = pessoa.ID;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}

