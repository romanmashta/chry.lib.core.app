using System;

namespace Cherry.Lib.Core.App.Root
{
    public interface IRootViewProvider
    {
        Type View { get; }
    }
}