namespace TPF.Core.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task Insert(bool isFogoBicho, decimal probability);
    }
}
