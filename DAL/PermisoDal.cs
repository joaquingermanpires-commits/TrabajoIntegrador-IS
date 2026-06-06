using ABS;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisoDal
    {
        //Carga y Lectura de permisos
        public List<Patente> ObtenerTodasLasPatentes()
        {
            List<Patente> lista = new List<Patente>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerTodasLasPatentes", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("SP_ObtenerFamilias", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("SP_ObtenerHijosPermiso", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //Permisos de usuario
        public List<Permiso> ObtenerPermisosDeUsuario(long idUsuario)
        {
            List<Permiso> permisosDelUsuario = new List<Permiso>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerPermisosDeUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
                    SqlCommand cmdDelete = new SqlCommand("SP_EliminarPermisosUsuario", con, tx);
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.AddWithValue("@IdUsuario", usuario.ID_Usuario);
                    cmdDelete.ExecuteNonQuery();
                    HashSet<int> idsInsertados = new HashSet<int>();
                    foreach (var permiso in usuario.Permisos)
                    {
                        if (idsInsertados.Contains(permiso.ID_Permiso)) continue;

                        SqlCommand cmdInsert = new SqlCommand("SP_InsertarPermisoUsuario", con, tx);
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.Parameters.AddWithValue("@IdUsuario", usuario.ID_Usuario);
                        cmdInsert.Parameters.AddWithValue("@IdPermiso", permiso.ID_Permiso);
                        cmdInsert.ExecuteNonQuery();
                        idsInsertados.Add(permiso.ID_Permiso);
                    }
                    tx.Commit();
                }
                catch (SqlException sqlEx)
                {
                    tx.Rollback();
                    throw new Exception("SQL Server rechazó la operación: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Error en C#: " + ex.Message);
                }
            }
        }
        //Crear Familia
        public void GuardarNuevaFamilia(Familia familiaNueva)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    SqlCommand cmdPadre = new SqlCommand("SP_CrearFamilia", con, tx);
                    cmdPadre.CommandType = CommandType.StoredProcedure;
                    cmdPadre.Parameters.AddWithValue("@Nombre", familiaNueva.Nombre);
                    SqlParameter outParam = new SqlParameter("@IdNuevaFamilia", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmdPadre.Parameters.Add(outParam);
                    cmdPadre.ExecuteNonQuery();
                    int idPadreGenerado = (int)cmdPadre.Parameters["@IdNuevaFamilia"].Value;
                    familiaNueva.ID_Permiso = idPadreGenerado;
                    foreach (var hijo in familiaNueva.ObtenerHijos())
                    {
                        SqlCommand cmdHijo = new SqlCommand("SP_AgregarPermisoAFamilia", con, tx);
                        cmdHijo.CommandType = CommandType.StoredProcedure;
                        cmdHijo.Parameters.AddWithValue("@IdPadre", idPadreGenerado);
                        cmdHijo.Parameters.AddWithValue("@IdHijo", hijo.ID_Permiso);
                        cmdHijo.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Error al guardar la nueva familia en la base de datos.", ex);
                }
            }
        }
        //Eliminar familia
        public void EliminarFamiliaSegura(int idFamilia)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_EliminarFamiliaConReasignacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFamilia", idFamilia);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}