using ABS;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisoDal
    {
        public List<Patente> ObtenerTodasLasPatentes()
        {
            List<Patente> lista = new List<Patente>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID_Permiso, Nombre, Permiso FROM Permiso WHERE EsFamilia = 0", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Patente p = new Patente();
                    p.ID_Permiso = reader.GetInt32(0);
                    p.Nombre = reader.GetString(1);
                    p.Permiso_Sistema = reader.IsDBNull(2) ? null : reader.GetString(2);
                    lista.Add(p);
                }
            }
            return lista;
        }
        public List<Familia> ObtenerFamilias()
        {
            List<Familia> lista = new List<Familia>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID_Permiso, Nombre, Permiso FROM Permiso WHERE EsFamilia = 1", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Familia f = new Familia();
                    f.ID_Permiso = reader.GetInt32(0);
                    f.Nombre = reader.GetString(1);
                    f.Permiso_Sistema = reader.IsDBNull(2) ? null : reader.GetString(2);
                    lista.Add(f);
                }
            }
            return lista;
        }
        public void LlenarFamiliaRecursivo(Familia familiaPadre)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT p.ID_Permiso, p.Nombre, p.Permiso, p.EsFamilia 
                    FROM Permiso p
                    INNER JOIN Permiso_Permiso pp ON p.ID_Permiso = pp.ID_Permiso_Hijo
                    WHERE pp.ID_Permiso_Padre = @IdPadre", con);

                cmd.Parameters.AddWithValue("@IdPadre", familiaPadre.ID_Permiso);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string permisoSis = reader.IsDBNull(2) ? null : reader.GetString(2);
                    bool esFamilia = reader.GetBoolean(3);

                    if (esFamilia)
                    {
                        Familia subFamilia = new Familia();
                        subFamilia.ID_Permiso = id;
                        subFamilia.Nombre = nombre;
                        subFamilia.Permiso_Sistema = permisoSis;
                        LlenarFamiliaRecursivo(subFamilia);
                        familiaPadre.AgregarHijo(subFamilia);
                    }
                    else
                    {
                        Patente patente = new Patente();
                        patente.ID_Permiso = id;
                        patente.Nombre = nombre;
                        patente.Permiso_Sistema = permisoSis;

                        familiaPadre.AgregarHijo(patente);
                    }
                }
            }
        }
        public List<Permiso> ObtenerPermisosDeUsuario(long idUsuario)
        {
            List<Permiso> permisosDelUsuario = new List<Permiso>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@" SELECT p.ID_Permiso, p.Nombre, p.Permiso, p.EsFamilia 
                FROM Permiso p
                INNER JOIN Usuario_Permiso up ON p.ID_Permiso = up.ID_Permiso
                WHERE up.ID_Usuario = @IdUsuario", con);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string permisoSis = reader.IsDBNull(2) ? null : reader.GetString(2);
                    bool esFamilia = reader.GetBoolean(3);

                    if (esFamilia)
                    {
                        Familia f = new Familia();
                        f.ID_Permiso = id;
                        f.Nombre = nombre;
                        f.Permiso_Sistema = permisoSis;
                        LlenarFamiliaRecursivo(f);
                        permisosDelUsuario.Add(f);
                    }
                    else
                    {
                        Patente p = new Patente();
                        p.ID_Permiso = id;
                        p.Nombre = nombre;
                        p.Permiso_Sistema = permisoSis;
                        permisosDelUsuario.Add(p);
                    }
                }
            }
            return permisosDelUsuario;
        }
        public void GuardarPermisosUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    // Borramos los permisos actuales que tenía el usuario en la BD
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Usuario_Permiso WHERE ID_Usuario = @IdUsuario", con, tx);
                    cmdDelete.Parameters.AddWithValue("@IdUsuario", usuario.ID_Usuario);
                    cmdDelete.ExecuteNonQuery();
                    // Iteramos sobre su lista de permisos en memoria y los insertamos uno por uno
                    foreach (var permiso in usuario.Permisos)
                    {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO Usuario_Permiso (ID_Usuario, ID_Permiso) VALUES (@Id, @IdPermiso)", con, tx);
                        cmdInsert.Parameters.AddWithValue("@Id", usuario.ID_Usuario);
                        cmdInsert.Parameters.AddWithValue("@IdPermiso", permiso.ID_Permiso);
                        cmdInsert.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Error al guardar los permisos en la base de datos.", ex);
                }
            }
        }
    }
}