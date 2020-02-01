using System;
using System.Linq;
using System.Threading.Tasks;

namespace Interworks.API.Interfaces {
    public interface IRepositoryAsyncOut<TModel> where TModel : IPrimaryModel {
        IQueryable<TModel> find();
        Task<TModel> findAsync(Guid id);
        Task<bool> deleteAsync(Guid id);
    }
        
    public interface IRepositoryAsync<TModel> : IRepositoryAsyncOut<TModel> where TModel : IPrimaryModel {
        Task<TModel> createAsync(TModel tObject);
        Task<TModel> updateAsync(TModel tObjext);
    }
}