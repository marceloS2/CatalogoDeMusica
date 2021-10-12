using ApiCatalogoMusicas.InputModel;
using ApiCatalogoMusicas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Services
{
    public interface IMusicaService : IDisposable
    {
        Task<List<MusicaViewModel>> Obter(int pagina, int quantidade);
        Task<MusicaViewModel> Obter(Guid id);
        Task<MusicaViewModel> Inserir(MusicaInputModel jogo);
        Task Atualizar(Guid id, MusicaInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);

    }
}
