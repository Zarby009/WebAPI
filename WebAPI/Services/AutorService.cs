using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class AutorService : IAutorInterface
    {

        private readonly AppDBContext _dbcontext;
        public AutorService(AppDBContext appDB)
        {
            _dbcontext = appDB;
        }



        public async Task<ResponseModel<List<AutorModel>>> BuscarAutoresTodos()
        {
            ResponseModel< List < AutorModel >> response = new ResponseModel<List<AutorModel>> ();
            try { 
                var autores = await _dbcontext.Autores.ToListAsync();
                response.Dados = autores;
                response.Status = true;
                response.Mensagem = "Todos os dados foram coletados";
                return response;
            
            }catch (Exception ex) {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int IdLivroAutor)
        {
            throw new NotImplementedException();
        }
    }
}
