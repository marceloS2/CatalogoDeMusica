using ApiCatalogoMusicas.Entities;
using ApiCatalogoMusicas.Exceptions;
using ApiCatalogoMusicas.InputModel;
using ApiCatalogoMusicas.Repositories;
using ApiCatalogoMusicas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Services
{
    public class MusicaService : IMusicaService
    {

        private readonly IMusicaRepository _musicaRepository;

        public MusicaService(IMusicaRepository musicaRepository)
        {
            _musicaRepository = musicaRepository;
        }

        public async Task<List<MusicaViewModel>> Obter(int pagina, int quantidade)
        {
            var musica = await _musicaRepository.Obter(pagina, quantidade);

            return musica.Select(musica => new MusicaViewModel
            {
                Id = musica.Id,
                Nome = musica.Nome,
                Produtora = musica.Produtora,
                Preco = musica.Preco
            })
                               .ToList();
        }

        public async Task<MusicaViewModel> Obter(Guid id)
        {
            var musica = await _musicaRepository.Obter(id);

            if (musica == null)
                return null;

            return new MusicaViewModel
            {
                Id = musica.Id,
                Nome = musica.Nome,
                Produtora = musica.Produtora,
                Preco = musica.Preco
            };
        }

        public async Task<MusicaViewModel> Inserir(MusicaInputModel musica)
        {
            var entidadeMusica = await _musicaRepository.Obter(musica.Nome, musica.Produtora);

            if (entidadeMusica.Count > 0)
                throw new MusicaJaCadastradaException();

            var musicaInsert = new Musica
            {
                Id = Guid.NewGuid(),
                Nome = musica.Nome,
                Produtora = musica.Produtora,
                Preco = musica.Preco
            };

            await _musicaRepository.Inserir(musicaInsert);

            return new MusicaViewModel
            {
                Id = musicaInsert.Id,
                Nome = musica.Nome,
                Produtora = musica.Produtora,
                Preco = musica.Preco
            };
        }

        public async Task Atualizar(Guid id, MusicaInputModel musica)
        {
            var entidadeMusica = await _musicaRepository.Obter(id);

            if (entidadeMusica == null)
                throw new MusicaNaoCadastradaException();

            entidadeMusica.Nome = musica.Nome;
            entidadeMusica.Produtora = musica.Produtora;
            entidadeMusica.Preco = musica.Preco;

            await _musicaRepository.Atualizar(entidadeMusica);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeMusica = await _musicaRepository.Obter(id);

            if (entidadeMusica == null)
                throw new MusicaNaoCadastradaException();

            entidadeMusica.Preco = preco;

            await _musicaRepository.Atualizar(entidadeMusica);
        }

        public async Task Remover(Guid id)
        {
            var musica = await _musicaRepository.Obter(id);

            if (musica == null)
                throw new MusicaNaoCadastradaException();

            await _musicaRepository.Remover(id);
        }

        public void Dispose()
        {
            _musicaRepository?.Dispose();
        }

    
    }

}


