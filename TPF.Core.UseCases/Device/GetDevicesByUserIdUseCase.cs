using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.Shared.Helpers;
using TPF.Core.Borders.UseCases.Devices;

namespace TPF.Core.UseCases.Device;

public class GetDevicesByUserIdUseCase : IGetDevicesByUserIdUseCase
{
    private readonly IDeviceRepository _deviceRepository;



    async Task<UseCaseResponse<GetDevicesResponse>> IUseCase<Guid, GetDevicesResponse>.Execute(Guid request)
    {
        throw new NotImplementedException();
    }
}
