using System;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResource
    {
        public string Icon { get; set; }
        public string DisplayName { get; set; }
        public string[] Keywords { get; set; }
        
        public Type QueryView();
    }
}