using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Autor;
using WebApi8.Dto.Livro;
using WebApi8.Models;
using WebApi8.Services.Autor;
using WebApi8.Services.Livro;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly ILivroInterface _livrointerface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livrointerface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivro()
        {
            var livro = await _livrointerface.ListarLivros();
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorId/${idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livrointerface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarAutorPorIdLivro(int idAutor)
        {
            var livro = await _livrointerface.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDto novoLivro)
        {
            var livro = await _livrointerface.CriarLivro(novoLivro);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEditado)
        {
            var livro = await _livrointerface.EditarLivro(livroEditado);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idLivro)
        {
            var autorExcluido = await _livrointerface.ExcluirLivro(idLivro);
            return Ok(autorExcluido);
        }
    }
}
