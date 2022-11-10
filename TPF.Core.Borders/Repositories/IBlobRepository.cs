namespace TPF.Core.Borders.Repositories;

public interface IBlobRepository
{
    Task<string?> UploadBlob(Stream fileStream, string fileName);
}
