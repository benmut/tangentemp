using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Tangent.Employee.Droid.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        EditText _etUserName;
        EditText _etUserPassword;
        Button _btnLogin;

        static readonly string TAG = typeof(LoginActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            _etUserName = FindViewById<EditText>(Resource.Id.et_username);
            _etUserPassword = FindViewById<EditText>(Resource.Id.et_password);
            _btnLogin = FindViewById<Button>(Resource.Id.btn_login);

        }
    }
}

