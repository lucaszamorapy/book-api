using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Dto.Autor;
using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> /*tipo de resposta*/ resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == idAutor);
                resposta.Dados = autor;
                resposta.Mensagem = "O autor foi coletado com êxito";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
           
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> /*tipo de resposta*/ resposta = new ResponseModel<AutorModel>();
            try 
            {
                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "O autor foi coletado com êxito pelo livro";
                resposta.Status = true;
                return resposta;
            } 
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> /*tipo de resposta*/ resposta = new ResponseModel<List<AutorModel>>();   
            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto novoAutor)
        {
            ResponseModel<AutorModel> /*tipo de resposta*/ resposta = new ResponseModel<AutorModel>();
            try
            {
               var autor = new AutorModel();
                {
                    autor.Nome = novoAutor.Nome;
                    autor.Sobrenome = novoAutor.Sobrenome;
                }

                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = autor;
                resposta.Mensagem = "Autor criado com êxito";
                resposta.Status = true;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
    }
}
