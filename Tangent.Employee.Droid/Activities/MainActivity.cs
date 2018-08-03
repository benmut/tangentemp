using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Fragment = Android.Support.V4.App.Fragment;
using Tangent.Employee.Droid.Fragments;

namespace Tangent.Employee.Droid
{
    [Activity(Label = "Tangent", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(MainActivity).Name;

        private DrawerLayout _drawer;
        private ActionBarDrawerToggle _drawerToggle;
        private Toolbar _toolBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            _toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetupNavigationDrawer();

            ReplaceFragment(new DashboardFragment());
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

