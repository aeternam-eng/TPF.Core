namespace TPF.Core.Borders.Repositories
{
    public interface IFireDataRepository
    {
        Task Insert(bool isFogoBicho, decimal probability, Guid deviceId);
    }
}
