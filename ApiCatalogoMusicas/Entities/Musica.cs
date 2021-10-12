using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Entities
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }

        internal void Add(Guid id, Musica musica)
        {
            throw new NotImplementedException();
        }
    }
}
