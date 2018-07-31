using System;
using Android.App;
using Android.Runtime;
using SimpleInjector;
using Tangent.Employee.Core.Services.Implementation;
using Tangent.Employee.Core.Services.Interface;

namespace Tangent.Employee.Droid.Application
{
    [Application]
    public class TangentEmployeeApplication : Android.App.Application
    {
        public static Container Container { get; set; }

        public TangentEmployeeApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            // 1. Create a new Simple Injector Container
            Container = new Container();

            // 2. Configure the container
            Container.Register<IUserService, UserService>(Lifestyle.Singleton);

            // 3. Verify your configuration
            Container.Verify();
        }
    }
}
