using ApiCatalogoMusicas.Exceptions;
using ApiCatalogoMusicas.InputModel;
using ApiCatalogoMusicas.Services;
using ApiCatalogoMusicas.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly IMusicaService _musicaService;

        public MusicasController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicaViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _musicaService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }
        /// <summary>
        /// Buscar um Musica pelo seu Id
        /// </summary>
        /// <param name="idMusica">Id do Musica buscado</param>
        /// <response code="200">Retorna o Musica filtrado</response>
        /// <response code="204">Caso não haja Musica com este id</response> 

        [HttpGet("{idMusica:guid}")]
        public async Task<ActionResult<MusicaViewModel>> Obter(Guid idMusica)
             {
            var musica = await _musicaService.Obter(idMusica);

            if (musica == null)
                return NoContent();

            return Ok(musica);
        }

        [HttpPost]
        public async Task<ActionResult<MusicaViewModel>> InsesirMusica([FromBody] MusicaInputModel musicaInputModel)
        {
            try
            {
                var musica = await _musicaService.Inserir(musicaInputModel);

                return Ok(musica);
            }
            catch (MusicaJaCadastradaException ex)
            
            {
                return UnprocessableEntity("Já existe uma musica com este nome para esta produtora");
            }

        }
       
        [HttpPut("{idMusica:guid}")]
        public async Task<ActionResult> AtualizarMusica([FromRoute]Guid idMusica, [FromBody] MusicaInputModel musicaInputModel)
        {
            try
            {
                await _musicaService.Atualizar(idMusica, musicaInputModel);

                return Ok();
            }
            catch (MusicaNaoCadastradaException ex)
            
            {
                return NotFound("Não existe este musica");
            }
       
        
        
        }
            
       [HttpPatch("{idMusica:guid}/preco/{preco:double}")]
       public async Task<ActionResult> AtualizarMusica([FromRoute] Guid idMusica, [FromRoute] double preco)
        {

            try
            {
                await _musicaService.Atualizar(idMusica, preco);

                return Ok();
            }
            catch (MusicaNaoCadastradaException ex)
            
            {
                return NotFound("Não existe este jogo");
            }


        }
       
        [HttpDelete("{idMusica:guid}")]  
        public async Task<ActionResult> ApagarMusica([FromRoute] Guid idMusica)
        {
            try
            {
                await _musicaService.Remover(idMusica);

                return Ok();
            }
             catch (MusicaNaoCadastradaException ex)
            
            {
                return NotFound("Não existe este musica");
            }



        }
   
    }   

}
