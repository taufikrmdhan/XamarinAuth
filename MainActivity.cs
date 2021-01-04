using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using XamarinAuth.API;
using EDMTDialog;
using Refit;

namespace XamarinAuth
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText etUsername, etPassword;
        Button btnLogin;
        TextView txtRegister;
        XamarinAPI xamarinAPI;

        Android.Support.V7.App.AlertDialog alertDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            xamarinAPI = RestService.For<XamarinAPI>("http://localhost:5000");

            alertDialog = new EDMTDialogBuilder().SetContext(this).Build();

            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            etUsername = FindViewById<EditText>(Resource.Id.etUsername);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            txtRegister = FindViewById<TextView>(Resource.Id.txtRegister);

            txtRegister.Click += delegate
            {
                StartActivity(new Android.Content.Intent(this, typeof(ActivityRegister)));
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}