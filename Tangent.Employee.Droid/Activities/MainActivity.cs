using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Fragment = Android.Support.V4.App.Fragment;
using Tangent.Employee.Droid.Fragments;
using SimpleInjector;
using Tangent.Employee.Droid.Application;
using Tangent.Employee.Core.Services.Interface;
using System;
using Tangent.Employee.Core.Services.Implementation;
using System.Collections.Generic;

namespace Tangent.Employee.Droid
{
    [Activity(Label = "Tangent", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(MainActivity).Name;

        private DrawerLayout _drawer;
        private ActionBarDrawerToggle _drawerToggle;
        private Toolbar _toolBar;

        IEmployeeService _employeeService;

        private static Container Container
        {
            get
            {
                return TangentEmployeeApplication.Container;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            IocContainterGetInstances();

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            _toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetupNavigationDrawer();

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.maincontent, DashboardFragment.NewInstance(_employeeService, OnTileSelected))
                .Commit();

            //ReplaceFragment(DashboardFragment.NewInstance(_employeeService, OnTileSelected));
        }

        private void IocContainterGetInstances()
        {
            _employeeService = Container.GetInstance<EmployeeService>();
        }

        private void SetupNavigationDrawer()
        {
            SetSupportActionBar(_toolBar);
            _drawerToggle = new ActionBarDrawerToggle(this, _drawer, _toolBar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            _drawerToggle.DrawerIndicatorEnabled = true;
            _drawer.AddDrawerListener(_drawerToggle);
            _drawerToggle.SyncState(); 
        }

        private void OnTileSelected(List<Core.Models.Employee> employees)
        {
            Fragment fragment = EmployeesCategoryFragment.NewInstance(employees);
            ReplaceFragment(fragment);
        }

        private void ReplaceFragment(Fragment fragment)
        {
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.maincontent, fragment)
                .AddToBackStack(null)
                .Commit();
        }
    }
}

