﻿namespace Pedidos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public double Total { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}
