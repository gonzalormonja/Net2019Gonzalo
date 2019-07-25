using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                //abrimos la conexion con la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /*
                 * creamos un objeto SqlCommand que sera la sentencia SQL
                 * que vamos a ejecutar contra la base de datos
                 * (los datos de la BD usuario, contraseña, servidor, etc
                 * estan en el connectionstring)
                 */
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", sqlConn);


                /*
                 * instanciamos un objeto DataReader que sera
                 * el que recuperara los datos de la BD
                 */
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /*
                 * Read() lee una fila de las devueltas por el comando sql,
                 * carga los datos en drUsuarios para poder accederlos,
                 * devuelve verdadero misntras haya podido leer datos
                 * y avanza a la fila siguiente para el proximo read
                 */
                while (drUsuarios.Read())
                {
                    /*
                     * creamos un objet Usuario de la capa de entidades para copiar
                     * los datos de la fila de DataReader al objeto entidades
                     */
                    Usuario usr = new Usuario();
                    //ahora copiamos los datos de la fila al objeto
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];

                    //agregamos el objeto con datos a la lista que devolvemos
                    usuarios.Add(usr);
                }
                //cerramos el DataReader y la conexion a la BD
                drUsuarios.Close();
            }catch( Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar la lista de usuarios", Ex);
                throw ExcepcionManejada;
            } finally
            {
                this.CloseConnection();
            }
            //devolvemos el objeto
            return usuarios;
            
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id",sqlConn);
                cmdUsuarios.Parameters.Add("@id",SqlDbType.Int).Value=ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();  
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //devolvemos el objeto
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                //abrimos la conexion
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al parametro
                SqlCommand cmdDelete =
                    new SqlCommand("DELETE usuarios WHERE id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email)" +
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email)" +
                    "select @@identity", sqlConn);//esta ultima linea es para obtener el id generado automaticamente
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                //asi obtenemos el id que se genero automaticamente
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }catch(Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario," +
                    " clave = @clave, habilitado = @habilitado, " +
                    "nombre = @nombre, apellido = @apellido, email = @email " +
                    "WHERE id_usuario = @id",sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
                MessageBox.Show("llego2");
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            
            if(usuario.State == BusinessEntity.States.Delete)
            {
                this.Delete(usuario.ID);
            }else if(usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }else if(usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
