using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Fragment = Android.Support.V4.App.Fragment;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Tangent.Employee.Droid.Fragments;
using SimpleInjector;
using Tangent.Employee.Droid.Application;
using Tangent.Employee.Core.Services.Interface;
using System;
using Tangent.Employee.Core.Services.Implementation;
using System.Collections.Generic;
using Tangent.Employee.Core.Models;
using Android.Support.V4.View;
using Tangent.Employee.Core.Helpers;
using Android.Content;

namespace Tangent.Employee.Droid
{
    [Activity(Label = "Tangent", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(MainActivity).Name;

        private DrawerLayout _drawer;
        private ActionBarDrawerToggle _drawerToggle;
        private Toolbar _toolBar;
        private NavigationView _navigationView;

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
            _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            _toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetupNavigationDrawer();

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.maincontent, DashboardFragment.NewInstance(_employeeService, onEmployeeTypeSelected, onReviewTileSelected))
                .Commit();
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

            _navigationView.NavigationItemSelected += OnNavigationViewItemSelected;
        }

        void OnNavigationViewItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            Fragment fragment = null;

            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.nav_dashboard:
                    fragment = DashboardFragment.NewInstance(_employeeService, onEmployeeTypeSelected, onReviewTileSelected);
                    break;
                case Resource.Id.my_profile:
                    fragment = new UserProfileFragment();
                    break;
                case Resource.Id.nav_logout:
                    ShowLogOutConfirmationDialog();
                    break;
            }

            if (fragment != null)
            {
                ReplaceFragment(fragment);
            }

            _drawer.CloseDrawer(GravityCompat.Start);
        }

        private void ShowLogOutConfirmationDialog()
        {
            var dialog = new AlertDialog.Builder(this)
                    .SetTitle("Logout")
                    .SetMessage("Are you sure you want to Logout?")
                    .SetCancelable(false)
                    .SetPositiveButton("YES", OnLogOut)
                    .SetNegativeButton("CANCEL", (sender, e) => { })
                    .Create();
            dialog.Show();
        }

        private void OnLogOut(object sender, DialogClickEventArgs e)
        {
            var sharedPreferences = GetSharedPreferences(Constant.Authentication, FileCreationMode.Private);
            sharedPreferences.Edit().Remove(Constant.AccessToken).Commit();
            Finish();
        }
        
        private void onEmployeeTypeSelected(List<Core.Models.Employee> employees)
        {
            Fragment fragment = EmployeesCategoryFragment.NewInstance(employees, onEmployeeSelected);
            ReplaceFragment(fragment);
        }

        private void onEmployeeSelected(Core.Models.Employee employee)
        {
            Fragment fragment = EmployeeDetailsFragment.NewInstance(employee);
            ReplaceFragment(fragment);
        }

        private void onReviewTileSelected(List<Review> reviews)
        {
            Fragment fragment = ReviewsFragment.NewInstance(reviews, onReviewSelected);
            ReplaceFragment(fragment);
        }

        private void onReviewSelected(Review review)
        {
            Fragment fragment = ReviewDetailsFragment.NewInstance(review);
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

