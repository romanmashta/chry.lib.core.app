using System.Collections.Generic;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IDiscoveryService
    {
        IEnumerable<IDiscoveryItem> Items { get; }
    }
}