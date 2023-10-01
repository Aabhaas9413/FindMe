namespace DataAccess.Common.Interface
{
    public interface IGetData<T>
    {
        Task<T?> GetData(string? path);
    }
}