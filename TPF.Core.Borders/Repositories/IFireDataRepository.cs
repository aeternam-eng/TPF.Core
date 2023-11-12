using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireDataRepository
    {
        Task Insert(dynamic model);
    }
}
