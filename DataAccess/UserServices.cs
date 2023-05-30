using System.Text;
using Dapper;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccess;

public class UserServices
{
    public List<User> GetUsers()
    {
        List<User> userList = new();
        MySqlConnection conexion = DbServices.ObtenerConexion();
        try
        {
            userList = conexion.Query<User>("SELECT *FROM USERS ").ToList();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conexion.Close();
            conexion.Dispose();
            MySqlConnection.ClearPool(conexion);
        }
        return userList;
    }

    public bool InsertUser(User user)
    {
        MySqlConnection conexion = DbServices.ObtenerConexion();
        try
        {
            StringBuilder sentencia = new(" insert into Users ( Nombre, Apellidos, FechaNacimiento, Direccion, Correo, ");
            sentencia.AppendLine(" Telefono, Password, fechaAlta, Verificado ) ");
            sentencia.AppendLine(" values ( @Nombre, @Apellidos, @FechaNacimiento, @Direccion, @Correo, ");
            sentencia.AppendLine(" @Telefono, @Password, CURDATE(), @Verificado ) ");
            return conexion.Execute(sentencia.ToString(), user) > 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conexion.Close();
            conexion.Dispose();
            MySqlConnection.ClearPool(conexion);
        }
    }

    public bool UpdateUser(User user)
    {
        MySqlConnection conexion = DbServices.ObtenerConexion();
        try
        {
            StringBuilder sentencia = new(" update Users ");
            sentencia.AppendLine(" set Nombre = @Nombre,  Apellidos = @Apellidos, FechaNacimiento = @FechaNacimiento, ");
            sentencia.AppendLine(" Direccion = @Direccion, Correo = @Correo, Telefono = @Telefono ");
            sentencia.AppendLine(" where Id = @Id ");
            return conexion.Execute(sentencia.ToString(), user) > 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conexion.Close();
            conexion.Dispose();
            MySqlConnection.ClearPool(conexion);
        }
        
    }

    public bool DeleteUser(int id)
    {
        MySqlConnection conexion = DbServices.ObtenerConexion();
        try
        {
            StringBuilder sentencia = new(" DELETE FROM USERS ");
            sentencia.AppendLine(" where id = @id ");
            return conexion.Execute(sentencia.ToString(), new { id = id })>0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conexion.Close();
            conexion.Dispose();
            MySqlConnection.ClearPool(conexion);
        }
    }
}