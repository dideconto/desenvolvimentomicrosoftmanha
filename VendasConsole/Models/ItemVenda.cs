using System;

namespace VendasConsole.Models
{
    class ItemVenda
    {
        public ItemVenda()
        {
            Produto = new Produto();
            CriadoEm = DateTime.Now;
        }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
