using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IAutorInterface
    {

        Task<ResponseModel<List<AutorModel>>> BuscarAutoresTodos();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int IdLivroAutor);


    }
}
