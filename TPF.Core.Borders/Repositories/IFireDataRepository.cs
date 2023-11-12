using TPF.Core.Borders.Dtos;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireDataRepository
    {
        Task Insert(Measurement model);
    }
}
