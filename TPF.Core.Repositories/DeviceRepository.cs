using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Repositories.Helpers;

namespace TPF.Core.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IRepositoryHelper _helper;

        public DeviceRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task Insert(bool isFogoBicho, decimal probability)
        {
            const string sql = @"INSERT INTO Device
									()";
        }
    }
}
