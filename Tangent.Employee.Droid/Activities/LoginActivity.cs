using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SimpleInjector;
using Tangent.Employee.Core.Helpers;
using Tangent.Employee.Core.Services.Implementation;
using Tangent.Employee.Core.Services.Interface;
using Tangent.Employee.Droid.Application;
using Tangent.Employee.Droid.Utils;

namespace Tangent.Employee.Droid.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(LoginActivity).Name;

        EditText _etUserName;
        EditText _etUserPassword;
        Button _btnLogin;

        IUserService _userService;
        IProfileService _profileService;

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
            SetContentView(Resource.Layout.activity_login);

            _userService = Container.GetInstance<UserService>();
            _profileService = Container.GetInstance<ProfileService>();

            _etUserName = FindViewById<EditText>(Resource.Id.et_username);
            _etUserPassword = FindViewById<EditText>(Resource.Id.et_password);
            _btnLogin = FindViewById<Button>(Resource.Id.btn_login);

            _btnLogin.Click += Login_OnClickAsync;
            _btnLogin.Enabled = false;

            _etUserName.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Text.ToString()) && !string.IsNullOrEmpty(_etUserPassword.Text))
                {
                    _btnLogin.Enabled = true;
                }
                else
                {
                    _btnLogin.Enabled = false;
                }
            };

            _etUserPassword.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Text.ToString()) && !string.IsNullOrEmpty(_etUserName.Text))
                {
                    _btnLogin.Enabled = true;
                }
                else
                {
                    _btnLogin.Enabled = false;
                }
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private async void Login_OnClickAsync(object sender, EventArgs e)
        {
            var username = _etUserName.Text;
            var password = _etUserPassword.Text;

            // Hide Softkeyboard & disable button
            Helpers.HideSoftKeyboard(this, this);
            _btnLogin.Enabled = false;

            var progressDialog = ProgressDialog.Show(this, null, GetString(Resource.String.txt_loggin_in));
            progressDialog.Show();
            var accessToken = await _userService.GetAccessTokenAsync(username, password);

            if(!string.IsNullOrEmpty(accessToken))
            {
                UserProfileSingleton.Instance.SetUserProfile(await _profileService.GetUserProfile(accessToken));
                progressDialog.Dismiss();

                // Save Token to Shared preferences
                var sharedPreferences = GetSharedPreferences(Constant.Authentication, FileCreationMode.Private);
                var editor = sharedPreferences.Edit();
                editor.PutString(Constant.AccessToken, accessToken);
                editor.Commit();

                StartActivity(typeof(MainActivity));
            }
            else
            {
                progressDialog.Dismiss();
                DisplayPermissionDeniedError();
            }
            _etUserPassword.Text = "";
        }

        private void DisplayPermissionDeniedError()
        {
            Helpers.ShowDialog(this, GetString(Resource.String.permission_denied_title), GetString(Resource.String.error_incorrect_credentials));
        }
    }
}

