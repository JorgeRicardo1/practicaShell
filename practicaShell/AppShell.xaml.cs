using practicaShell.Views;
using Xamarin.Forms;

namespace practicaShell
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("GestionPedidos3", typeof(GestionPedidos));
            Routing.RegisterRoute(nameof(InfoCliente), typeof(InfoCliente));
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//TabBar");
        }
    }
}
