using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResourceResolver
    {
        Task<object> ResolveResource(string resourcePath);
    }

    public interface IRootResolver : IResourceResolver
    {
        
    }

    public class RootResolver : IRootResolver
    {
        private readonly IEnumerable<IResourceResolver> _resolvers;

        public RootResolver(IEnumerable<IResourceResolver> resolvers)
        {
            _resolvers = resolvers;
        }
        
        public async Task<object> ResolveResource(string resourcePath)
        {
            var resources = await Task.WhenAll(_resolvers.Select(r => r.ResolveResource(resourcePath)));
            var resource = resources.FirstOrDefault(r => r != null);
            return Task.FromResult(resource);
        }
    }
}