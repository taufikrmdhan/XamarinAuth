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

namespace XamarinAuth.Model
{
    class TbUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}