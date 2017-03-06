using SQLite.Net;
using Xamarin.Forms;

namespace Paladin.Database
{
  public class PaladinDb
  {
    private SQLiteConnection _connection;
    public SQLiteConnection Connection
    {
      get
      {
        if (_connection == null)
        {
          _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        return _connection;
      }
    }

    public PaladinDb()
    {

    }

    public void CreateTables()
    {
      Connection.CreateTable<Character>();
    }


  }
}
