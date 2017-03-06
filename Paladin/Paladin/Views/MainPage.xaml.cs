using Paladin.Database;
using Paladin.Model;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Paladin.Views
{
  public partial class MainPage : ContentPage
  {
    PaladinDb _database { get; set; }
    Character SelectedCharacter { get; set; }

    public MainPage(PaladinDb database)
    {
      InitializeComponent();
      _database = database;
      lvCharacters.ItemsSource = BuildListViewCharacters();

    }

    async void LvCharacters_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      SelectedCharacter = (Character)e.Item;
      //var charDetailsPage = new CharacterDetails();
      //charDetailsPage.BindingContext = selectedItem;
      //await Navigation.PushAsync(charDetailsPage);
    }

    internal List<Character> BuildListViewCharacters()
    {
      CharacterDl dl = new CharacterDl(_database.Connection);
      dl.DeleteAllCharacters();

      Character viktor = new Character
      {
        Name = "Viktor",
        IconPath = "viktor.png"
      };

      Character ying = new Character
      {
        Name = "Ying",
        IconPath = "ying.png"
      };

      dl.AddCharacter("Viktor", "viktor.png");
      dl.AddCharacter("Ying", "ying.png");

      List<Character> chars = dl.GetCharacters().ToList();

      return chars;
    }

    private void btnDeleteCharacterClicked(object sender, System.EventArgs e)
    {
      if (SelectedCharacter != null)
      {
        CharacterDl dl = new CharacterDl(_database.Connection);
        int result = dl.DeleteCharacter(SelectedCharacter.CharacterID);
        if (result == 1)
        {
          List<Character> chars = dl.GetCharacters().ToList();
          lvCharacters.ItemsSource = chars;
        }
      }
    }

    private void btnAddCharacter_Clicked(object sender, System.EventArgs e)
    {

    }
  }
}
