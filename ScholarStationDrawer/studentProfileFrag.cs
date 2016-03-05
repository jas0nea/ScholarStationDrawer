
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ScholarStationDrawer
{
	public class studentProfileFrag : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);



			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			View view = inflater.Inflate(Resource.Layout.studentProfileLayout, container, false);
			TextView firstname = view.FindViewById<TextView> (Resource.Id.StudentFName);
			var path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			var filename = Path.Combine (path, "test.txt");
			var fname = File.ReadAllText (filename);
			firstname.Text = fname;
			return view;
		}
	}
}

