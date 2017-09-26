using DemoMvvmcross.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace DemoMvvmcross.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.RegisterType<IThing, Thing>();

			RegisterAppStart<ViewModels.MainViewModel>();
        }


    }
}
