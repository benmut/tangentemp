using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.OS;
using Android.Views;
using Tangent.Employee.Droid.Application;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        public TangentEmployeeApplication App
        {
            get
            {
                return (TangentEmployeeApplication)Activity.Application;
            }
        }

        public string AccessToken
        {
            get
            {
                return App.AccessToken;
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}
