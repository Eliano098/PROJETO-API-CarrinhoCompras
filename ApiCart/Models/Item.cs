namespace ApiCart.Models
{
    public class Item
    {
        public Item()
        {
            Identificador = Guid.NewGuid();
        }
        public Guid Identificador { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }
    }
}
