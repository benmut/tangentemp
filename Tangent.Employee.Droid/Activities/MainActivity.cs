using Android.App;
//using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Tangent.Employee.Droid
{
    [Activity(Label = "Tangent", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(MainActivity).Name;

        private DrawerLayout _drawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            var _toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolBar);

            var _drawerToggle = new ActionBarDrawerToggle(this, _drawer, _toolBar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            _drawerToggle.DrawerIndicatorEnabled = true;
            _drawer.AddDrawerListener(_drawerToggle);
            _drawerToggle.SyncState();
 
        }

        private void SetupNavigationDrawer()
        {
            
        }
    }
}

