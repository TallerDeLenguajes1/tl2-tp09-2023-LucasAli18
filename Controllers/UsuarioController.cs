using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ClaseUsuario;
using RepoUsuario;
namespace tl2_tp09_2023_exequiel1984.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepositorio();
    }

    [HttpPost]
    [Route("api/usuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usuario)
    {
        usuarioRepository.CrearNuevo(usuario);
        return Ok(usuario);
    }

    [HttpGet]
    [Route("api/usuarios")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(usuarioRepository.ListarUsuarios());
    }

    [HttpGet]
    [Route("api/usuario/{id}")]
    public ActionResult<Usuario> GetUsuario(int id)
    {
        Usuario usuario = usuarioRepository.ObtenerUsuarioPorID(id);
        if(String.IsNullOrEmpty(usuario.NombreDeUsuario))
            return NotFound("No lo encontré");
        else 
            return Ok(usuario);
    }

    [HttpPut]
    [Route("api/usuario/{id}/Nombre")]
    public ActionResult<string> UpdUsuario(int id, Usuario usuario)
    {
        usuarioRepository.ModificarUsuario(id, usuario);
        return "Bien hecho";
    }

    [HttpDelete]
    [Route("api/usuarios/eliminar/{id}")]
    public IActionResult DeleteUser(int id){
        usuarioRepository.EliminarUsuario(id);
        return Ok();
    }
}