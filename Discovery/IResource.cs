using System;

namespace Cherry.Lib.Core.App.Discovery
{
    public interface IResource
    {
        public Type QueryView();
    }
}