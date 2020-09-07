using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cherry.Lib.Core.App.Root
{
    public class RootViewProvider<T>: IRootViewProvider
    {
        public Type View => typeof(T);
    }
}