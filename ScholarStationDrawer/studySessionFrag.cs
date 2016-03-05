
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ScholarStationDrawer
{
	public class studySessionFrag : Fragment,Android.App.DatePickerDialog.IOnDateSetListener//,Android.App.TimePickerDialog.IOnTimeSetListener
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
			View view = inflater.Inflate(Resource.Layout.studySessionLayout, container, false);
			view.FindViewById<EditText>(Resource.Id.date).Click += (object sender, EventArgs e) => 
			{
				var dialog = new datePicker(Activity,DateTime.Now,this);
				dialog.Show(FragmentManager,null);
			};
//			view.FindViewById<EditText>(Resource.Id.time).Click += (object sender, EventArgs e) => 
//			{
//				var dialog = new timePicker(Activity,this,DateTime.Now.Hour,DateTime.Now.Minute,false);
//				dialog.Show(FragmentManager,null);
//			};
			return view;
		}

		public void OnDateSet(DatePicker view, int year, int month, int day)
		{
			var date = new DateTime (year, month + 1, day);
			View.FindViewById<EditText> (Resource.Id.date).Text = date.ToString ("yyyy MMMMM dd");

		}

//		public void OnTimeSet(TimePicker view, int hour, int minute)
//		{
//			view.FindViewById<EditText> (Resource.Id.time).Text = string.Format("{0}:{1}",hour,minute.ToString());
//		}
	}
}

