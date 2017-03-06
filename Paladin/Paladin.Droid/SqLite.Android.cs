using System;
using System.IO;
using Xamarin.Forms;
using Paladin.Droid;
using SQLite;

[assembly: Dependency(typeof(SqLite))]
namespace Paladin.Droid
{
  public class SqLite : ISQLite
  {
    public SqLite()
    {

    }
    public SQLite.Net.SQLiteConnection GetConnection()
    {
      string fileName = "PcPaladin.db3";
      var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      var path = Path.Combine(documentsPath, fileName);

      var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
      var connection = new SQLite.Net.SQLiteConnection(platform, path);

      return connection;
    }

  }
}