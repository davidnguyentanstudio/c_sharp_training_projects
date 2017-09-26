using System.Threading.Tasks;
using DemoMvvmcross.Core.Services;
using MvvmCross.Core.ViewModels;

namespace DemoMvvmcross.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly IDebuggingService _debuggingService;

        public MainViewModel(IDebuggingService debuggingService)
        {
            this._debuggingService = debuggingService;
        }

        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public IMvxCommand PrintTextCommand => new MvxCommand(PrintText);

        private void PrintText()
        {
            this._debuggingService.Print(this.Text);
        }

        public void Print(object any)
        {
            this._debuggingService.Print(any);
        }
    }
}