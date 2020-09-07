namespace Cherry.Lib.Core.App.Discovery
{
    public enum PreferedView
    {
        None,
        List,
        Cars,
    }

    public enum Priority
    {
        Low = 0,
        Middle = 1,
        High = 2
    }
    
    public interface IMetaInfo
    {
        public string DisplayName { get; set; }
        
        string Icon { get; set; }
        string Category { get; set; }
        PreferedView PreferedView { get; set; }
        Priority Priority { get; set; }
    }

    public class MetaInfo : IMetaInfo
    {
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public string Category { get; set; }
        public PreferedView PreferedView { get; set; }
        public Priority Priority { get; set; }
    }
}