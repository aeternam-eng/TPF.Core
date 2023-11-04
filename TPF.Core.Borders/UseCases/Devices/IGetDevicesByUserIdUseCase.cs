using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Shared.Helpers;

namespace TPF.Core.Borders.UseCases.Devices;

public interface IGetDevicesByUserIdUseCase : IUseCase<Guid, GetDevicesResponse> { }
