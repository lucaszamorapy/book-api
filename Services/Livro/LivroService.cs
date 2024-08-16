using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Dto.Autor;
using WebApi8.Dto.Livro;
using WebApi8.Models;

namespace WebApi8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> /*tipo de resposta*/ resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == idLivro);
                resposta.Status = true;
                resposta.Dados = livro;
                resposta.Mensagem = "O livro foi coletado com êxito";
                return resposta;
            }
            catch (Exception ex) 
            { 
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<LivroModel>> CriarLivro(LivroCriacaoDto novoLivro)
        {

            ResponseModel<LivroModel> /*tipo de resposta*/ resposta = new ResponseModel<LivroModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == novoLivro.Autor.Id);

                if (autor == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Nenhum registro de autor localizado";
                    return resposta;
                }

                var livro = new LivroModel();
                {
                    livro.Titulo = novoLivro.Titulo;
                    livro.Autor = autor;
                };

                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                resposta.Status = true;
                resposta.Dados = livro;
                resposta.Mensagem = "O livro foi criado com êxito";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                if (ex.InnerException != null)
                {
                    resposta.Mensagem += " Inner Exception: " + ex.InnerException.Message;
                }
                return resposta;
            }
        }

        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ExluirLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }

    }
}
