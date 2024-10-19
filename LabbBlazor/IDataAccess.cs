namespace LabbBlazor
{
    public interface IDataAccess <T>
    {
        public Task<IEnumerable<T>> GetDataAsync();
    }
}
