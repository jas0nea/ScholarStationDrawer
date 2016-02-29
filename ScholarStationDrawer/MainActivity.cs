using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget; 
using Android.Support.V7.App;
using Android.Views; 

namespace ScholarStationDrawer
{
	[Activity (Label = "ScholarStationDrawer", Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		//int count = 1;
		DrawerLayout drawerLayout;
		NavigationView navigationView;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

			var toolbar = FindViewById<Toolbar> (Resource.Id.app_bar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetTitle (Resource.String.app_name);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetDisplayShowHomeEnabled(true);

			// Attach item selected handler to navigation view
			navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			navigationView.NavigationItemSelected += (sender, e) => {
				e.MenuItem.SetChecked(true);
				var ft = FragmentManager.BeginTransaction ();
				ft.AddToBackStack (null);
				switch(e.MenuItem.ItemId)
				{
				case Resource.Id.nav_home:
					ft.Replace (Resource.Id.FragmentLayout, new homeFragment ()); 
					ft.AddToBackStack (null);
					ft.Commit ();
					break;
				case Resource.Id.nav_profile:
					ft.Replace (Resource.Id.FragmentLayout, new studentProfileFrag ());
					ft.AddToBackStack (null);
					ft.Commit ();
					break;
				case Resource.Id.nav_study:
					ft.Replace (Resource.Id.FragmentLayout, new studySessionFrag ());
					ft.AddToBackStack (null);
					ft.Commit ();
					break;
				}
					

				drawerLayout.CloseDrawers();

			};

			var drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
			drawerLayout.SetDrawerListener (drawerToggle);
			drawerToggle.SyncState ();
				
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) 
			{
			case Android.Resource.Id.Home:
				drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}

	}
}


