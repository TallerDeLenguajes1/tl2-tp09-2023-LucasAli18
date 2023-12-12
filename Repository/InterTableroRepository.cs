using ClaseTablero;
namespace RepoTablero
{
    public interface ITableroRepository
    {
        public Tablero CrearNuevo(Tablero tablero);
        public void ModificarTablero(int id, Tablero tablero);
        public Tablero ObtenerTableroPorID(int id);
        public List<Tablero> ListarTableros();
        public List<Tablero> ListarTablerosDeUsuario(int idUsuario);
        public void EliminarTablero(int id);
    }
}