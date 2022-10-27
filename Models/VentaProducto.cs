namespace WebApplication3.Models
{
    public class VentaProducto : Venta
    {
        public List<ProductoVendido> Productos { get; set; }

    }
}
