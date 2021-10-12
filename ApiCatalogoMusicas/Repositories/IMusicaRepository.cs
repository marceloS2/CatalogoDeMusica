using ApiCatalogoMusicas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Repositories
{
    public interface IMusicaRepository : IDisposable
    {

        Task<List<Musica>> Obter(int pagina, int quantidade);
        Task<Musica> Obter(Guid id);
        Task<List<Musica>> Obter(string nome, string produtora);
        Task Inserir(Musica musica);
        Task Atualizar(Musica musica);
        Task Remover(Guid id);

    }
}
