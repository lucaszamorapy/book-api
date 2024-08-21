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

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> /*tipo de resposta*/ resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(x => x.Autor).Where(x =>  x.Autor.Id == idAutor).ToListAsync();
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Os livros foi coletado com êxito pelo livro";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
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

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEditado)
        {
            ResponseModel<List<LivroModel>> /*tipo de resposta*/ resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == livroEditado.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                livro.Titulo = livroEditado.Titulo;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = $"Livro {livro.Id} alterado com êxito";
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

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> /*tipo de resposta*/ resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = $"Livro {livro.Id} removido com êxito";
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

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> /*tipo de resposta*/ resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados";
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
