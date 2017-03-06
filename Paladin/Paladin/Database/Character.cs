using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.Database
{
  public class Character
  {
    [PrimaryKey, AutoIncrement]
    public int CharacterID { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    public Character()
    {

    }
  }
}
