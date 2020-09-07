namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResourceView
    {
        object Resource { get; set; }
    }
    
    public interface IResourceView<T>: IResourceView
    {
        new T Resource { get; set; }
    }
}