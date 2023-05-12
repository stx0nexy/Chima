namespace Catalog.Host.Models.Response
{
    public class ItemsResponse<T>
    {
        public long Count { get; set; }
        public IList<T> Data { get; set; } = new List<T>();
    }
}
