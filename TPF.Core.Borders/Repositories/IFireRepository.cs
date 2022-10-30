using Microsoft.AspNetCore.Http;
using TPF.Core.Borders.Dtos;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireRepository
    {
        Task<GetFireResponse> GetFire(IFormFile img);
    }
}
