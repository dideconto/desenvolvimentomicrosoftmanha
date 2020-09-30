using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWPF.Models
{
    [Table("Vendas")]
    class Venda : BaseModel
    {
        public Venda()
        {
            Cliente = new Cliente();
            Itens = new List<ItemVenda>();
            Vendedor = new Vendedor();
        }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<ItemVenda> Itens { get; set; }
    }
}
