using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores(); //vai retornar uma lista dos autores do tipo modelo de autor
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor); //retornar autor pelo id
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro); //autor pelo livro id
    }
}