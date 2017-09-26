using System;
using DemoMvvmcross.Core.Models;

namespace DemoMvvmcross.Core.Services
{
    public interface IPrintConsoleService
    {
        IThing Prefix { get; set; }

        string Convert(object any);
    }
}
