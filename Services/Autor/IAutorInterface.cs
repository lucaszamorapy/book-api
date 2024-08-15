using WebApi8.Dto.Autor;
using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores(); //vai retornar uma lista dos autores do tipo modelo de autor
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor); //retornar autor pelo id
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro); //autor pelo livro id
        Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autor);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autor);
        Task<ResponseModel<List<AutorModel>>> ExluirAutor(int idAutor);
    }
}