using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Shared.Helpers;

namespace TPF.Core.Borders.UseCases;

public interface IGetUserDevicesUseCase : IUseCase<Guid, IEnumerable<DeviceResponse>> { }
