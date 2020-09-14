using System;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResource
    {
        public string Icon { get; }
        public string DisplayName { get; }
        public string[] Keywords { get; }
        public bool WithHeader { get; }
        public Type QueryView();
    }
}