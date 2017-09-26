using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace DemoMvvmcross.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<Core.ViewModels.MainViewModel>
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            System.Console.WriteLine("DemoMvvmcross.iOS.Views.ViewDidLoad");

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(TextField).To(vm => vm.Text);
            //set.Bind(Button).To(vm => vm.ResetTextCommand);
            set.Bind(Button).To(ViewModel => ViewModel.PrintTextCommand);
            set.Apply();
        }
    }
}
