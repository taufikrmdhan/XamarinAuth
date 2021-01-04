using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EDMTDialog;
using Refit;
using XamarinAuth.API;
using XamarinAuth.Model;


namespace XamarinAuth
{
    [Activity(Label = "ActivityRegister")]
    public class ActivityRegister : Activity
    {
        EditText etUsername, etPassword;
        Button btnRegister;
        XamarinAPI xamarinAPI;

        Android.Support.V7.App.AlertDialog alertDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);

            xamarinAPI = RestService.For<XamarinAPI>("http://localhost:5000");

            alertDialog = new EDMTDialogBuilder().SetContext(this).Build();

            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            etUsername = FindViewById<EditText>(Resource.Id.etUsername);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

            btnRegister.Click += async delegate
            {
                alertDialog.Show();

                TbUser user = new TbUser();
                user.UserName = etUsername.Text;
                user.Password = etPassword.Text;

                var result = await xamarinAPI.RegisterUser(user);
                if (result.Contains("Successfully"))
                    Finish();
                Toast.MakeText(this, result, ToastLength.Short).Show();
                alertDialog.Dismiss();
            };
            // Create your application here
        }
    }
}