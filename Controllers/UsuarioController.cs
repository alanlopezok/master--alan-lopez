using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> Get()
        {
            return ADO_Usuario.DevolverUsuarios();
        }
        [HttpDelete]
        public void Eliminar([FromBody]int id)
        {
            ADO_Usuario.EliminarUsuario(id);
        }
        [HttpPut]
        public void Modificar([FromBody]Usuario us)
        {
            ADO_Usuario.ModificarUsuario(us);
        }
        [HttpPost]
        public void Agregar([FromBody] Usuario us)
        {
            ADO_Usuario.AgregarUsuario(us);
        }
    }
}
