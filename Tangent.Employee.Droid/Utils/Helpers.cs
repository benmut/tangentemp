using System;
using Android.App;
using Android.Content;
using Android.Views.InputMethods;

namespace Tangent.Employee.Droid.Utils
{
    public class Helpers
    {
        public static void ShowDialog(Activity activity, string title, string message)
        {
            activity.RunOnUiThread(() =>
            {
                var dialog = new Android.Support.V7.App.AlertDialog.Builder(activity)
                                            .SetTitle(title)
                                            .SetMessage(message)
                                            .SetCancelable(false)
                                            .SetPositiveButton(activity.GetString(Resource.String.txt_ok), (sender, e) => { })
                                            .Create();
                dialog.Show();
            });
        }

        public static void HideSoftKeyboard(Context context, Activity activity)
        {
            var inputMethodManger = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (activity.CurrentFocus != null)
            {
                inputMethodManger.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, HideSoftInputFlags.None);
            }
        }
    }
}
