namespace Cherry.Lib.Core.App.Discovery
{
    public interface IObjectWithRef
    {
        string Ref { get; set; }
    }
    
    public interface INamedEntity
    {
        string Name { get; set; }
    }
}