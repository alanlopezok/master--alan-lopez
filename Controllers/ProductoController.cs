using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> Get()
        {
            return ADO_Producto.DevolverProductos();
        }

        [HttpPost]
        public void CrearProducto([FromBody] Producto pro)
        {
            ADO_Producto.CrearProducto(pro);
        }
        [HttpPut]
        public void ModificarProducto([FromBody] Producto pro)
        {
            ADO_Producto.ModificarProducto(pro);
        }

        [HttpDelete]
        public void EliminarProducto([FromBody] int id)
        {
            ADO_ProductosVendidos.EliminarProductoVendido(id);
            ADO_Producto.EliminarProducto(id);
        }

    }


}
