using ClaseTablero;
using System.Data.SQLite;
namespace RepoTablero
{
    public class TableroRepositorio : ITableroRepository
    {
        private string cadenaConexion = "Data Source=BaseDatos/kanban.db;Cache=Shared";

        public Tablero CrearNuevo(Tablero tablero)
        {
            var query = @"
            INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion)
            VALUES (@usuarioPropietario, @nombre , @descripcion);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@usuarioPropietario", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tablero;
        }

        public void EliminarTablero(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tablero> ListarTableros()
        {
            string query = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();

                using (SQLiteDataReader Reader = command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Tablero tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(Reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(Reader["id_usuario_propietario"]);
                        tablero.Nombre = Reader["nombre"].ToString();
                        tablero.Descripcion = Reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }

                connection.Close();
            }
            return tableros;
        }

        public List<Tablero> ListarTablerosDeUsuario(int idUsuario)
        {
            string query = @"SELECT * FROM Tablero WHERE id_usuario_propietario = @idUsuario;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();

                using (SQLiteDataReader Reader = command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Tablero tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(Reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(Reader["id_usuario_propietario"]);
                        tablero.Nombre = Reader["nombre"].ToString();
                        tablero.Descripcion = Reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }

                connection.Close();
            }
            return tableros;
        }

        public void ModificarTablero(int id, Tablero tablero)
        {
             using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tablero SET id_usuario_propietario = @idUsuarioPropietario, nombre = @nombre, descripcion = @descripcion
                WHERE id = @id;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuarioPropietario", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Tablero ObtenerTableroPorID(int id)
        {
            Tablero tablero = new Tablero();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string queryString = @"SELECT * FROM Tablero WHERE id = @id;";
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                    }
                }
                connection.Close();
            }
            return tablero;
        }
    }
}