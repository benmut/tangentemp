using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using SimpleInjector;
using Tangent.Employee.Core.Helpers;
using Tangent.Employee.Core.Services.Implementation;
using Tangent.Employee.Core.Services.Interface;

namespace Tangent.Employee.Droid.Application
{
    [Application]
    public class TangentEmployeeApplication : Android.App.Application
    {
        public static Container Container { get; set; }

        public string AccessToken
        {
            get
            {
                // Retrieve Token from Shared preferences
                var sharedPreferences = GetSharedPreferences(Constant.Authentication, FileCreationMode.Private);
                return sharedPreferences.GetString(Constant.AccessToken, string.Empty);
            }
        }

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
            Container.Register<IEmployeeService, EmployeeService>(Lifestyle.Singleton);
            Container.Register<IProfileService, ProfileService>(Lifestyle.Singleton);

            // 3. Verify your configuration
            Container.Verify();
        }
    }
}
