using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practicaShell.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GestionPedidos : ContentPage
	{
		public GestionPedidos ()
		{
			InitializeComponent ();
		}

        private async void BtnVlver_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("//EquipementPage");
            //try
            //{
            //             await Shell.Current.GoToAsync("//EquipementPage");
            //         }
            //catch (Exception)
            //{

            //             await Shell.Current.GoToAsync("//EquipementPage2");
            //         }
        }

        private async void BtnIrATab_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("//InfoCliente");
            //try
            //{
            //             await Shell.Current.GoToAsync("///InfoCliente2");
            //         }
            //catch (Exception)
            //{

            //             await Shell.Current.GoToAsync("//InfoCliente");
            //         }
        }
    }
}