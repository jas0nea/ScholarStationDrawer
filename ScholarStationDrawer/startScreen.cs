﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScholarStationDrawer
{
	[Activity (Label = "Scholar Station", MainLauncher = true, Icon = "@mipmap/icon")]		
	public class StartScreenActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.startScreen);
			Button signIn = FindViewById<Button> (Resource.Id.SignIn);
			Button signUp = FindViewById<Button> (Resource.Id.SignUp);

			var path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			var filename = Path.Combine (path, "test.txt");
			File.WriteAllText (filename, "Jason");

			var imageView = FindViewById<ImageView> (Resource.Id.imageView1);
			imageView.SetImageResource (Resource.Drawable.mriknow2);
			signIn.Click += delegate(object sender, EventArgs e) {
				Intent intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);
			};

		}
	}
}

