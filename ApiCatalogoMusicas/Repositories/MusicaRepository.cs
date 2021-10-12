using ApiCatalogoMusicas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Repositories
{
    public class MusicaSqlServerRepositor : IMusicaRepository
    {


        private static Dictionary<Guid, Musica> musicas = new Dictionary<Guid, Musica>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Musica{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Racionais Mcs", Produtora = "Boogie Naipe", Preco = 150} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Musica{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Sabotagem", Produtora = "Boogie Naipe", Preco = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Musica{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "LinkPark", Produtora = "Warner Bros. Machine Shop", Preco = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Musica{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Mc Carlinhos Fiel", Produtora = "Favela", Preco = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Musica{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Lady Gaga", Produtora = " Interscope Records", Preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Musica{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Sia", Produtora = "VEVO", Preco = 190} }
        };

        public Task<List<Musica>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(musicas.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Musica> Obter(Guid id)
        {
            if (!musicas.ContainsKey(id))
                return Task.FromResult<Musica>(null);

            return Task.FromResult(musicas[id]);
        }

        public Task<List<Musica>> Obter(string nome, string produtora)
        {
            return Task.FromResult(musicas.Values.Where(musica => musica.Nome.Equals(nome) && musica.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Musica>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Musica>();

            foreach (var musica in musicas.Values)
            {
                if (musica.Nome.Equals(nome) && musica.Produtora.Equals(produtora))
                    retorno.Add(musica);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Musica musica)
        {
            musicas.Add(musica.Id, musica);
            return Task.CompletedTask;
        }

        public Task Atualizar(Musica musica)
        {
            musicas[musica.Id] = musica;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            musicas.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    
    
    }








}

