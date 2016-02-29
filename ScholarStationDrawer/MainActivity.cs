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
			navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

			var drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
			drawerLayout.SetDrawerListener (drawerToggle);
			drawerToggle.SyncState ();

			var ft = FragmentManager.BeginTransaction ();
			ft.AddToBackStack (null);
			ft.Add (Resource.Id.FragmentLayout, new homeFragment ());
			ft.Commit ();

			}

		void NavigationView_NavigationItemSelected (object sender, NavigationView.NavigationItemSelectedEventArgs e)
		{
			var ft = FragmentManager.BeginTransaction ();
			ft.AddToBackStack (null);
			switch (e.MenuItem.ItemId) {
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
		}
		public override void OnBackPressed ()
		{
			if(FragmentManager.BackStackEntryCount!= 0) {
				FragmentManager.PopBackStack ();// fragmentManager.popBackStack();
			} else {
				base.OnBackPressed ();
			}  
		}
	}
}


