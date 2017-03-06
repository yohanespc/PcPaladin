using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Paladin.Database
{
  public class CharacterDl
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
    public CharacterDl(SQLiteConnection connection)
    {
      _connection = connection;
    }

    public void AddCharacter(string name, string iconPath)
    {
      bool exist = Connection.Table<Character>().Where(x => x.Name == name && x.IconPath == iconPath).Any();

      if (!exist)
      {
        Character lastChar = Connection.Table<Character>().OrderByDescending(x => x.CharacterID).FirstOrDefault();
        int id = 0;

        if (lastChar != null)
        {
          id = lastChar.CharacterID + 1;
        }

        Character newChar = new Character
        {
          CharacterID = id,
          Name = name,
          IconPath = iconPath
        };
        Connection.Insert(newChar);
      }
    }

    public int DeleteCharacter(long id)
    {
      return _connection.Delete<Character>(id);
    }

    public int DeleteAllCharacters()
    {
      return _connection.DeleteAll<Character>();
    }

    public IEnumerable<Character> GetCharacters()
    {
      return (from t in _connection.Table<Character>() select t);
    }
  }
}
