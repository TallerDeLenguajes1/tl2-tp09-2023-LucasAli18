using Microsoft.AspNetCore.Mvc;
using ClaseTarea;
using RepoTarea;
namespace tl2_tp09_2023_exequiel1984.Controllers;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepositorio();
    }

    [HttpPost]
    [Route("/api/Tarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        tareaRepository.CrearTarea(tarea);
        return Ok(tarea);
    }

    [HttpPut]
    [Route("/api/Tarea/{id}/Nombre/{Nombre}")]
    public ActionResult<string> UpdTarea(int id, String Nombre)
    {
        tareaRepository.UpDateNombre(id, Nombre);
        return "Bien hecho";
    }

    [HttpPut]
    [Route("/api/Tarea/{id}/Estado/{Estado}")]
    public ActionResult<string> UpdEstado(int id, EstadoTarea Estado)
    {
        tareaRepository.UpDateEstado(id, Estado);
        return "Bien hecho";
    }

    [HttpGet]
    [Route("/api/Tarea/{id}")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        Tarea tarea = tareaRepository.GetById(id);
        if(String.IsNullOrEmpty(tarea.Nombre))
            return NotFound("No lo encontré");
        else 
            return Ok(tarea);
    }

    [HttpGet]
    [Route("/api/Tarea/Usuario/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasByIdUsuario(int id){
        List<Tarea> tareas = tareaRepository.GetAllByIdUsuario(id);
        if (tareas.Count != 0)
            return Ok(tareas);
        else
            return BadRequest("No hay tareas para ese usuario");
    }

    [HttpGet]
    [Route("/api/Tarea/Tablero/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasByIdTablero(int id){
        List<Tarea> tareas = tareaRepository.GetAllByIdTablero(id);
        if (tareas.Count != 0)
            return Ok(tareas);
        else
            return BadRequest("No hay tareas para ese tablero");
    }

    [HttpDelete]
    [Route("/api/Tarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int id)
    {
        tareaRepository.Remove(id);
        
        return Ok("Exitos");
    }

    /* [HttpGet]
    [Route("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetTableros(){
        List<Tablero> tableros = tableroRepository.GetAll();
        if (tableros.Count != 0)
            return Ok(tableros);
        else
            return BadRequest("Todavia no tengo tableros");
    } */
}