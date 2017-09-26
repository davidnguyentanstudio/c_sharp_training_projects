using System;
using System.Diagnostics;
using DemoMvvmcross.Core.Models;

namespace DemoMvvmcross.Core.Services
{
    public class PrintConsoleService : IPrintConsoleService
    {
        private IPrefix _prefix;
        public IPrefix Prefix
        {
            get => _prefix;
            set => _prefix = value;
        }

        public PrintConsoleService(IPrefix prefix)
        {
            this._prefix = prefix;
        }

        public string Convert(object any)
        {
            return this.Prefix.Text + ": " + any.ToString();
        }
    }
}
