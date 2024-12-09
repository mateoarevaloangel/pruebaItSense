using BackendPrueba.Models;

namespace BackendPrueba.Repository.Interface
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetStatusAll();
        Task<Status> GetStatus(int productId);
        Task<Status> AddStatus(Status product);
        Task<Status> UpdateStatus(Status product);
        void DeleteStatus(int status);
    }
}
