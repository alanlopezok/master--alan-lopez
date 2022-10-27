using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void CargarVenta([FromBody] VentaProducto vtas)
        {
            ADO_Venta.CargarVenta(vtas);
        }
        [HttpGet("GetVentas")]
        public List<Venta> Get()
        {
            return ADO_Venta.DevolverVenta();
        }

    }
}
