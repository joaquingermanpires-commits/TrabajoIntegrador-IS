using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BackupDal
    {
        public void RealizarBackup(string rutaDestino)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"BACKUP DATABASE [EJ] TO DISK = '{rutaDestino}' WITH FORMAT, INIT, NAME = 'Copia de Seguridad - EJ'";// Comando nativo de SQL Server para hacer backup
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RealizarRestore(string rutaOrigen)
        {
            string connectionStringOriginal = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionStringOriginal);
            builder.InitialCatalog = "master";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                string queryKill = "ALTER DATABASE [EJ] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";//Forzamos el cierre de TODAS las conexión activa a la base
                using (SqlCommand cmdKill = new SqlCommand(queryKill, con))
                {
                    cmdKill.ExecuteNonQuery();
                }
                string queryRestore = $"RESTORE DATABASE [EJ] FROM DISK = '{rutaOrigen}' WITH REPLACE;";
                using (SqlCommand cmdRestore = new SqlCommand(queryRestore, con))
                {
                    cmdRestore.ExecuteNonQuery();
                }
                string queryMulti = "ALTER DATABASE [EJ] SET MULTI_USER;";
                using (SqlCommand cmdMulti = new SqlCommand(queryMulti, con))
                {
                    cmdMulti.ExecuteNonQuery();
                }
            }
        }
    }
}