namespace ApiCart.Models
{
    public class Carrinho
    {
        public Carrinho(int identificador)
        {
            this.Identificador = identificador;
            ListaItem = new List<Item>();
        }
        public int Identificador { get; set; }
        public List<Item> ListaItem { get; set; }
    }
}
