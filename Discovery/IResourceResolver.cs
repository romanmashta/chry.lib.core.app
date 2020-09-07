using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResourceResolver
    {
        Task<IResource> ResolveResource(string resourcePath);
    }

    public interface IRootResolver : IResourceResolver
    {
        
    }

    public class RootResolver : IRootResolver
    {
        private readonly IEnumerable<IResourceResolver> _resolvers;
        private readonly ILogger _log;

        public RootResolver(IEnumerable<IResourceResolver> resolvers, ILogger log)
        {
            _resolvers = resolvers;
            _log = log;
        }
        
        public async Task<IResource> ResolveResource(string resourcePath)
        {
            var resources = await Task.WhenAll(_resolvers.Select(r => r.ResolveResource(resourcePath)));
            var resource = resources.FirstOrDefault(r => r != null);
            Log.Information("Root resolved resource with type {@type}", resource?.GetType().FullName);
            return resource;
        }
    }
}