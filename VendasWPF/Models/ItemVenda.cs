using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWPF.Models
{
    [Table("ItensVenda")]
    class ItemVenda : BaseModel
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
