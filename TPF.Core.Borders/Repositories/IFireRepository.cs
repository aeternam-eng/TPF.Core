using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireRepository
    {
        Task<GetFireResponse> AnalyzeImage(MeasurementData data);
    }
}
