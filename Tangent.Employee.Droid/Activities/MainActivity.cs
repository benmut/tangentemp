using Android.App;
using Android.Widget;
using Android.OS;

namespace Tangent.Employee.Droid
{
    [Activity(Label = "Tangent.Employee.Droid")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

