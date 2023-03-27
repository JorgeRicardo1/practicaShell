using practicaShell.Models;
using practicaShell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practicaShell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeEquipementPage : ContentPage
    {
        public CoffeEquipementPage()
        {
            InitializeComponent();
            
            //BindingContext = new CoffeEquipementViewModel();
            //LabelCount.Text = "hello from code behind";
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffe = ((ListView)sender).SelectedItem as Coffee;
            if (coffe == null)
            {
                return;
            }
            await DisplayAlert("Coffe selected", coffe.Name, "Ok");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var coffe = ((MenuItem)sender).BindingContext as Coffee;
            if (coffe == null)
            {
                return;
            }
            await DisplayAlert("Coffe favorited", coffe.Name, "Ok");
        }
    }
}