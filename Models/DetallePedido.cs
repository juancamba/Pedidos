namespace Pedidos.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}
