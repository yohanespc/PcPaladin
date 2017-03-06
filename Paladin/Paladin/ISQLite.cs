using SQLite.Net;

namespace Paladin
{
  interface ISQLite
  {
    SQLiteConnection GetConnection();
  }
}
