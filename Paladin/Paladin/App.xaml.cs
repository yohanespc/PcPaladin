
using Paladin.Database;
using Xamarin.Forms;

namespace Paladin
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
      var database = new PaladinDb();
      database.CreateTables();
      MainPage = new NavigationPage(new Paladin.Views.MainPage(database));
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
