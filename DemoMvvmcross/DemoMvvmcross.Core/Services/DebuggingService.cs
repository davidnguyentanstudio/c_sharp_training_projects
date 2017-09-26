using System;
using System.Diagnostics;

namespace DemoMvvmcross.Core.Services
{
    public class DebuggingService : IDebuggingService
    {
        IPrintConsoleService _printConsoleService;
        public IPrintConsoleService PrintConsoleService
        {
            get => _printConsoleService;
            set => _printConsoleService = value;
        }

        public DebuggingService(IPrintConsoleService printConsoleService)
        {
            this._printConsoleService = printConsoleService;
        }

        public void Print(object any)
        {
            var text = this.PrintConsoleService.Convert(any);
            Debug.WriteLine(text);
        }
    }
}
