using RubricaCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryRubricaAdo
{
    public class RepoIndirizziADO : IRepoIndirizzo
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Indirizzo Add(Indirizzo item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into Indirizzo values (@t, @v,@c, @cap,@p, @n,@i)";
                    command.Parameters.AddWithValue("@t", item.Tipologia);
                    command.Parameters.AddWithValue("@v", item.Via); 
                    command.Parameters.AddWithValue("@c", item.Città);
                    command.Parameters.AddWithValue("@cap", item.CAP); 
                    command.Parameters.AddWithValue("@p", item.Provincia);
                    command.Parameters.AddWithValue("@n", item.Nazione);  
                    command.Parameters.AddWithValue("@i", item.IdContatto);
               



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
    }
}
