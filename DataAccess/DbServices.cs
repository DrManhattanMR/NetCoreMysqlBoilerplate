using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess;

public class DbServices
{
    public static MySqlConnection ObtenerConexion()
    {
        MySqlConnection conexion = new MySqlConnection();
        string cadena = "";
        conexion.ConnectionString = cadena;
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static MySqlCommand ObtenerComando(MySqlConnection conn, string sql)
    {
        return new MySqlCommand(sql, conn);
    }
    public static MySqlCommand ObtenerComando(MySqlConnection conn, string sql, MySqlTransaction tran)
    {
        return new MySqlCommand(sql, conn, tran);
    }
    public bool EjecutarProcedimiento(string pNombre)
    {
        MySqlConnection conexion = ObtenerConexion();
        try
        {
            MySqlCommand cmdProc = new MySqlCommand(pNombre, conexion);
            cmdProc.CommandType = CommandType.StoredProcedure;
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
            cmdProc.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexion.Close();
            MySqlConnection.ClearPool(conexion);
        }
    }
}