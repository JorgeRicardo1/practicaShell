using MvvmHelpers;
using MvvmHelpers.Commands;
using practicaShell.Models;
using practicaShell.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace practicaShell.ViewModels
{
    public class MyCoffeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get;}
        public AsyncCommand AddCommand { get;}
        public AsyncCommand<Coffee> RemoveCommand { get;}

        public MyCoffeViewModel() 
        {
            Title = "My COffe";
            Coffee = new ObservableRangeCollection<Coffee>();

            var image = "https://i.ibb.co/VNjKrpG/coffe-Image.jpg";

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
        }

        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name Of Coffe", "Ok", "Cancel");
            var roaster =await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster Of Coffe", "Ok", "Cancel");

            await CoffeService.AddCoffe(name, roaster);
            await Refresh();
        }


        public async Task Remove(Coffee coffee)
        {
            await CoffeService.RemoveCoffe(coffee.Id);
            await Refresh();
        }

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            Coffee.Clear();

            var coffees = await CoffeService.GetCoffe();

            Coffee.AddRange(coffees);

            IsBusy = false;
        }
    }
}
