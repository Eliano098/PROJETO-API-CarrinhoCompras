using System.Linq;

namespace ApiCart.Models
{
    public class Repositorio
    {
        public List<Carrinho> ListaCarrinho { get; set; }

        public Repositorio()
        {
            ListaCarrinho = new List<Carrinho>();
        }

        public Item AdicionarItem(int idCarrinho, Item item)
        {
            var carrinhoTemp = (from x in ListaCarrinho
                                where x.Identificador == idCarrinho
                                select x).SingleOrDefault();

            if (carrinhoTemp == null)
            {
                Carrinho Newcarrinho = new Carrinho(idCarrinho);
                Newcarrinho.ListaItem.Add(item);
                ListaCarrinho.Add(Newcarrinho);
                return item;
            }
            else
            {
                carrinhoTemp.ListaItem.Add(item);
                return item;
            }
        }

        public List<Carrinho> ListarTodosCarrinho()
        {
            return this.ListaCarrinho;
        }

        public List<Item> ListarItensCarrinho(int idCarrinho)
        {
            var carrinhoTemp = (from x in ListaCarrinho
                                where x.Identificador == idCarrinho
                                select x).SingleOrDefault();

            if (carrinhoTemp != null)
            {
                return carrinhoTemp.ListaItem;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteItensCarrinho(int idCarrinho, Guid idItem)
        {

            var carrinhoTemp = (from x in ListaCarrinho
                                where x.Identificador == idCarrinho
                                select x).SingleOrDefault();

            if (carrinhoTemp != null)
            {
                var listTemp = carrinhoTemp.ListaItem;

                foreach (Item x in listTemp)
                {
                    if (x.Identificador == idItem)
                    {
                        return carrinhoTemp.ListaItem.Remove(x);
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCarrinho(int idCarrinho)
        {
            var carrinhoTemp = (from x in ListaCarrinho
                                where x.Identificador == idCarrinho
                                select x).SingleOrDefault();

            if (carrinhoTemp != null)
            {
                carrinhoTemp.ListaItem.Clear();

                return ListaCarrinho.Remove(carrinhoTemp);
            }
            else
            {
                return false;
            }
        }

        public string FinalizarCarrinho(int idCarrinho)
        {
            var carrinhoTemp = (from x in ListaCarrinho
                                where x.Identificador == idCarrinho
                                select x).SingleOrDefault();

            if (carrinhoTemp != null)
            {
                var listTemp = carrinhoTemp.ListaItem;

                int quantidadeElem = listTemp.Count();
                float total = (from x in listTemp
                               select (int)x.Quantidade * x.ValorUnitario).Sum();

                string final = String.Concat("Quantidade Itens: ", quantidadeElem, "\nValor Total: ", total);
                return final;
            }
            else
            {
                return null;
            }
        }
    }
}

