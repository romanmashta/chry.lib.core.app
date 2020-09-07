namespace Cherry.Lib.Core.App.Discovery
{
    public interface IDiscoveryItem
    {
        string ResourcePath { get; set; }
        IMetaInfo MetaInfo { get; set; }
    }

    public class DiscoveryItem : IDiscoveryItem
    {
        public string ResourcePath { get; set; }
        public IMetaInfo MetaInfo { get; set; } = new MetaInfo();
    }
}