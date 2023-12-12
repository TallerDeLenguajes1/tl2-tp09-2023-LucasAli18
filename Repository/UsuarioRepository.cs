using ClaseUsuario;
using System.Data.SQLite;
namespace RepoUsuario{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private string cadenaConexion = "Data Source=BaseDatos/kanban.db;Cache=Shared";
        public void CrearNuevo(Usuario usuario)
        {
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var query = $"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre)";
                connection.Open();
                var command = new SQLiteCommand(query,connection);
                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreDeUsuario));
                command.ExecuteNonQuery();
                connection.Close();  
            }
        }

        public void EliminarUsuario(int id)
        {
             using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string query = @"DELETE FROM Usuario WHERE id = @id;";
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string query = @"SELECT * FROM Usuario;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        Usuarios.Add(usuario);
                    }
                }
                connection.Close();

            }
            return Usuarios;
        }

        public void ModificarUsuario(int id, Usuario usuario)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"UPDATE Usuario SET nombre_de_usuario = @nombre WHERE id = @idUsuario;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre", usuario.NombreDeUsuario));
                command.Parameters.Add(new SQLiteParameter("@idUsuario", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Usuario ObtenerUsuarioPorID(int id)
        {
            Usuario usuario = new Usuario();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string queryString = @"SELECT * FROM Usuario WHERE id = @idUsuario;";
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", id));
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                    }
                }
                connection.Close();
            }
            return usuario;
        }
    }
}