using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Shared.Helpers;

namespace TPF.Core.Borders.UseCases.Fire
{
    public interface IGetFiresUseCase : IUseCase<Guid, IEnumerable<FireDto>> { }
}
