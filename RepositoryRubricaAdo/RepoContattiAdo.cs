using RubricaCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepositoryRubricaAdo
{
    public class RepoContattiAdo : IRepoContatti
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Contatto Add(Contatto item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into Contatto values (@c, @n)";
                    command.Parameters.AddWithValue("@c", item.Cognome);
                    command.Parameters.AddWithValue("@n", item.Nome);
               


                    int numRighe = command.ExecuteNonQuery();
                    if (numRighe == 1)
                    {
                        connection.Close();
                        return item;
                    }

                    connection.Close();
                    return item;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public List<Contatto> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Contatto";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Contatto> contatti = new List<Contatto>();

                    while (reader.Read())
                    {
                        int id = (int)reader["IdContatto"];
                        string cognome = (string)reader["Cognome"];
                        string nome = (string)reader["Nome"];
                  


                        Contatto nuovoContatto = new Contatto(id, cognome,nome);
                        contatti.Add(nuovoContatto);

                    }
                    connection.Close();
                    return contatti;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Contatto>();
            }
        }

        public Contatto GetById(int idContatto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Contatto";

                    SqlDataReader reader = command.ExecuteReader();


                    Contatto contattoCercato = null;
                    while (reader.Read())
                    {
                        int id = (int)reader["IdContatto"];
                        string cognome = (string)reader["Cognome"];
                        string nome = (string)reader["Nome"];
                      

                        contattoCercato = new Contatto(id, cognome, nome);

                    }
                    connection.Close();
                    return contattoCercato;
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new Contatto();

            }

        }
    }
}
