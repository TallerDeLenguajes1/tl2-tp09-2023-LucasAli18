using ClaseUsuario;
namespace RepoUsuario
{
    public interface IUsuarioRepository
    {
        //● Crear un nuevo usuario. (recibe un objeto Usuario)
        public void CrearNuevo(Usuario usuario);
        //● Modificar un usuario existente. (recibe un Id y un objeto Usuario)
        public void ModificarUsuario(int id, Usuario usuario);
        //● Obtener detalles de un usuario por su ID. (recibe un Id y devuelve un Usuario)
        public Usuario ObtenerUsuarioPorID(int id);
        //● Listar todos los usuarios registrados. (devuelve un List de Usuarios)
        public List<Usuario> ListarUsuarios();
        //● Eliminar un usuario por ID
        public void EliminarUsuario(int id);
    }
}