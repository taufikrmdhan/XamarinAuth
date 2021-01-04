using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using XamarinAuth.Model;

namespace XamarinAuth.API
{
    interface XamarinAPI
    {
        [Post("/api/register")]
        Task<string> RegisterUser([Body]TbUser user);
    }
}