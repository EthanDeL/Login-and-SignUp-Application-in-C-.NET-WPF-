using Microsoft.Data.SqlClient;
using Login.classe;
using Microsoft.Identity.Client;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Diagnostics;

namespace Login.ado
{
    internal class UserAdo
    {
        // AJOUTER UN UTILISATEUR
        public static void AjouterUser(Users u)
        {
            SqlConnection sqlconnexion = Ado.OpenConnexion();

            // REQUETE SQL //
            string query = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES(@param1, @param2, @param3, @param4)";
            using (SqlCommand cmd = new SqlCommand(query, sqlconnexion))
            {
                cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = u.FirstName;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = u.LastName;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = u.Email;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar).Value = u.Password;

                cmd.ExecuteNonQuery();
            }

            Ado.CloseeConnexion(sqlconnexion);
        }


        // RECUPERE L'EMAIL + PWD DE L'UTILISATEUR 
        public static Users GetUserEmailAndPassword(string Email, string Password)
        {
            Users u = null;
            SqlConnection sqlconnexion = Ado.OpenConnexion();

            // REQUETE SQL //
            string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
            using (SqlCommand cmd = new SqlCommand(query, sqlconnexion))
            {
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        u = new Users();
                        u.Id = reader.GetInt32(0);
                        u.FirstName = reader.GetString(1);
                        u.LastName = reader.GetString(2);
                        u.Email = reader.GetString(3);
                        u.Password = reader.GetString(4);
                    }
                }
            }

            Ado.CloseeConnexion(sqlconnexion);
            return u;
        }


        // VERIFIE SI L'EMAIL EST UNIQUE
        public static bool EmailUnique(string Email)
        {
            SqlConnection sqlConnection = Ado.OpenConnexion();

            // REQUETE SQL
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }

    }
}