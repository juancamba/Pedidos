namespace Pedidos.Exceptions
{
    public class NoStockException : Exception
    {
        public NoStockException(string name, object key) : base($"{name} ({key}) no tiene stock suficiente")
        {
        }
    }
}
