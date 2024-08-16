using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("ListarLivro/${idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livrointerface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDto novoLivro)
        {
            var livro = await _livrointerface.CriarLivro(novoLivro);
            return Ok(livro);
        }
    }
}
