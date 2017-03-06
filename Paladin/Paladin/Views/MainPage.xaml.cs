using Paladin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paladin.Views
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      lvCharacters.ItemsSource = BuildListViewCharacters();
    }

    async void LvCharacters_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      CharactersListDto selectedItem = (CharactersListDto)e.Item;
      var charDetailsPage = new CharacterDetails();
      charDetailsPage.BindingContext = selectedItem;
      await Navigation.PushAsync(charDetailsPage);
    }

    internal List<CharactersListDto> BuildListViewCharacters()
    {
      List<CharactersListDto> chars = new List<CharactersListDto>();
      chars.Add(new CharactersListDto { Name = "Viktor", Icon = "" });
      chars.Add(new CharactersListDto { Name = "Ying", Icon = "" });
      return chars;
    }

  }
}
