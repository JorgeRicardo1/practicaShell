using MvvmHelpers;
using MvvmHelpers.Commands;
using practicaShell.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace practicaShell.ViewModels
{
    public class CoffeEquipementViewModel : BaseViewModel
    {

        //COMANDOS
        public ObservableCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeGroups { get;  }
        public AsyncCommand RefreshCommand { get;}
        public AsyncCommand<Coffee> FavoriteCommand { get;}
        public Command LoadMoreCommand { get;}
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        //CONSTRUCTOR
        public CoffeEquipementViewModel()
        {
            Title = "Coffe equipement";

            Coffee = new ObservableCollection<Coffee>();
            CoffeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://i.ibb.co/VNjKrpG/coffe-Image.jpg";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue bottle", Name = "kenya Kiambu", Image = image });

            CoffeGroups.Add(new Grouping<string, Coffee>("Blue bottle", new[] { Coffee[2] }));
            CoffeGroups.Add(new Grouping<string, Coffee>("Yes Pls", Coffee.Take(2)));

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            LoadMoreCommand = new Command(LoadMore);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            ClearCommand = new Command(Clear);
            SelectedCommand = new AsyncCommand<object>(Selected);
        }

        //VARIABLES
        Coffee _previouslySelected;
        Coffee _selectedCoffe;

        
        //OBJETOS
        public Coffee SelectedCoffe
        {
            get => _selectedCoffe;
            set => SetProperty(ref _selectedCoffe, value);
        }

        //PROCESOS

        async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
            {
                return;
            }
            await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "Ok");
        }

        async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
            {
                return;
            }
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "Ok");
        }

        void LoadMore()
        {
            if (Coffee.Count >= 15)
            {
                return;
            }
            var image = "https://i.ibb.co/VNjKrpG/coffe-Image.jpg";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue bottle", Name = "kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue bottle", Name = "kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue bottle", Name = "kenya Kiambu", Image = image });
            CoffeGroups.Clear();

            CoffeGroups.Add(new Grouping<string, Coffee>("Blue bottle", Coffee.Where(c => c.Roaster == "Blue bottle")));
            CoffeGroups.Add(new Grouping<string, Coffee>("Yes Pls", Coffee.Where(c => c.Roaster == "Yes Plz")));
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Coffee.Clear();
            LoadMore();

            IsBusy = false;
        }

        void DelayLoadMore()
        {
            if (Coffee.Count < 10)
            {
                return;
            }
            LoadMore();
        }

        void Clear()
        {
            Coffee.Clear();
            CoffeGroups.Clear();
        }
    }
}
