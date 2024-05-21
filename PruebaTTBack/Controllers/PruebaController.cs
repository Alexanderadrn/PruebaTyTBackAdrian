using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTTBack.Service;
using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public  PruebaController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("obtener-cargos")]
        public IActionResult ObtenerCargos()
        {
            var result = _usuario.ObtenerCargos();
            return new JsonResult(result);
        } 
        [HttpGet("obtener-departamentos")]
        public IActionResult ObtenerDepartamentos()
        {
            var result = _usuario.ObtenerDepartamentos();
            return new JsonResult(result);
        }
        [HttpPost("crear-usuario")]
        public IActionResult CrearUsuario(CrearUsuariosDto usuario)
        {
            var result = _usuario.CrearUsuario(usuario);
            return new JsonResult(result);
        }
        [HttpPost("borrar-usuario")]
        public IActionResult BorrarUsuario(int usuarioId)
        {
            var result = _usuario.BorrarUsuario(usuarioId);
            return new JsonResult(result);
        }
        [HttpPost("actualizar-usuario")]
        public IActionResult ActualizarUsuario(ActualizarUsuariosDto usuario)
        {
            var result = _usuario.ActualizarUsuario(usuario);
            return new JsonResult(result);
        }
        [HttpGet("obtener-usuarios")]
        public IActionResult ObtenerUsuarios()
        {
            var result = _usuario.ObtenerUsuarios();
            return new JsonResult(result);
        }
        [HttpGet("obtener-usuarios-by-filtro")]
        public IActionResult GetUsuariosFiltros(UsuariosDto usuario)
        {
            if(usuario.IdDepartamento != 0 && usuario.IdCargo != 0)
            {
                var result = _usuario.ObtenerUsuarios().Where(s=>s.IdCargo == usuario.IdCargo && s.IdDepartamento == usuario.IdDepartamento);
                return new JsonResult(result);
            }
            else if (usuario.IdDepartamento != 0 )
            {
                var result = _usuario.ObtenerUsuarios().Where(s =>  s.IdDepartamento == usuario.IdDepartamento);
                return new JsonResult(result);
            }
            else 
            {
                var result = _usuario.ObtenerUsuarios().Where(s => s.IdCargo == usuario.IdCargo );
                return new JsonResult(result);
            }

        }
    }
}
