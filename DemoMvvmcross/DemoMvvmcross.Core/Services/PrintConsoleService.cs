using System;
using System.Diagnostics;
using DemoMvvmcross.Core.Models;

namespace DemoMvvmcross.Core.Services
{
    public class PrintConsoleService : IPrintConsoleService
    {
        private IThing _prefix;
        public IThing Prefix
        {
            get => _prefix;
            set => _prefix = value;
        }

        public PrintConsoleService(IThing prefix)
        {
            this._prefix = prefix;
        }

        public string Convert(object any)
        {
            return this.Prefix.Name + ": " + any.ToString();
        }
    }
}
