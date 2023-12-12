using ClaseTarea;
namespace RepoTarea{
    public interface ITareaRepository{
        //● Crear una nueva tarea en un tablero. (recibe un idTablero, devuelve un objeto Tarea)
        public Tarea CrearTarea(Tarea Tarea);
        //● Modificar una tarea existente. (recibe un id y un objeto Tarea)
        public void UpDateNombre(int id, string nombre);
        public void UpDateEstado(int id, EstadoTarea Estado);
        //● Obtener detalles de una tarea por su ID. (devuelve un objeto Tarea)
        public Tarea GetById(int id);
        //● Listar todas las tareas asignadas a un usuario específico.(recibe un idUsuario,
        //devuelve un list de tareas)
        public List<Tarea> GetAllByIdUsuario(int idUsuario);
        //● Listar todas las tareas de un tablero específico. (recibe un idTablero, devuelve un list de tareas)
        public List<Tarea> GetAllByIdTablero(int idTablero);
        //● Eliminar una tarea (recibe un IdTarea)
        public void Remove(int id);
        //● Asignar Usuario a Tarea (recibe idUsuario y un idTarea)
        public void AsignarUsuarioATarea(int idUsuario, int idTarea);
        //public int CantidadTareasByEstado(EstadoTarea estado);
    }
}