using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Autor;
using WebApi8.Models;
using WebApi8.Services.Autor;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorinterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorinterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autor = await _autorinterface.ListarAutores();
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autores = await _autorinterface.BuscarAutorPorId(idAutor);
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorinterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }
        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto novoAutor)
        {
            var autor = await _autorinterface.CriarAutor(novoAutor);
            return Ok(autor);
        }
        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autor)
        {
            var autorEditado = await _autorinterface.EditarAutor(autor);
            return Ok(autorEditado);
        }
        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autorExcluido = await _autorinterface.ExluirAutor(idAutor);
            return Ok(autorExcluido);
        }
    }
}
