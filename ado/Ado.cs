using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.ado
{
    // CHAINE DE CONNEXION //

    internal class Ado
    {
        // OUVERTURE DE LA CONNEXION VERS NOTRE BDD "PROJETLOGIN"
        public static SqlConnection OpenConnexion()
        {
            SqlConnection sqlconnexion = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=PROJETLOGIN;Integrated Security=SSPI");
            sqlconnexion.Open();
            return sqlconnexion;
        }

        // FERMETURE DE LA CONNEXION DE NOTRE BDD
        public static void CloseeConnexion(SqlConnection sqlconnexion)
        {
            sqlconnexion.Close();
        }
    }
}
