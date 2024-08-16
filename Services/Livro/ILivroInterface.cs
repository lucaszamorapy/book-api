using WebApi8.Dto.Autor;
using WebApi8.Dto.Livro;
using WebApi8.Models;

namespace WebApi8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros(); //vai retornar uma lista dos autores do tipo modelo de autor
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro); //retornar autor pelo id
        Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int idAutor); //autor pelo livro id
        Task<ResponseModel<LivroModel>> CriarLivro(LivroCriacaoDto novoLivro);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livro);
        Task<ResponseModel<List<LivroModel>>> ExluirLivro(int idLivro);
    }
}
