namespace WebApplication3.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public double Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
    }
}
