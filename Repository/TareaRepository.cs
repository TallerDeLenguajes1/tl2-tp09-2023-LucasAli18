using ClaseTarea;
using System.Data.SQLite;
namespace RepoTarea{

    public class TareaRepositorio : ITareaRepository
    {
        private string cadenaConexion = "Data Source=BaseDatos/kanban.db;Cache=Shared";
        public Tarea CrearTarea(Tarea Tarea)
        {
            Tarea tarea = new Tarea();
            var query = @"
            INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado)
            VALUES (@idTablero, @nombre , @estado, @descripcion, @color, @idUsuarioAsignado);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tarea;
        }
        public void AsignarUsuarioATarea(int idUsuario, int idTarea)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tarea SET id_usuario_asignado = @idUsuarioAsignado
                WHERE id = @idTarea;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@isUsuarioAsignado", idUsuario));
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public List<Tarea> GetAllByIdTablero(int idTablero)
        {
            string query = @"SELECT * FROM Tarea WHERE id_tablero = @idTablero;";
            List<Tarea> tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                connection.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tareas.Add(tarea);
                    }
                }

                connection.Close();
            }
            return tareas;
        }

        public List<Tarea> GetAllByIdUsuario(int idUsuario)
        {
            string query = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuario;";
            List<Tarea> tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tareas.Add(tarea);
                    }
                }

                connection.Close();
            }
            return tareas;
        }

        public Tarea GetById(int id)
        {
            Tarea tarea = new Tarea();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string queryString = @"SELECT * FROM Tarea WHERE id = @idTarea;";
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", id));
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                }
                connection.Close();
            }
            return tarea;
        }

        public void Remove(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string query = @"DELETE FROM Tarea WHERE id = @id;";
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpDateEstado(int id, EstadoTarea Estado)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tarea SET estado = @estado
                WHERE id = @id;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estado", Estado));
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpDateNombre(int id, string nombre)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tarea SET nombre = @nombre
                WHERE id = @id;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre", nombre));
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}