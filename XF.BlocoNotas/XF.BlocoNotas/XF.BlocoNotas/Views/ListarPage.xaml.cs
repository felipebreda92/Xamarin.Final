using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.BlocoNotas.Models;
using XF.BlocoNotas.Services;

namespace XF.BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarPage : ContentPage
    {
        public ListarPage()
        {
            InitializeComponent();
            ListarNotas();
        }

        public void ListarNotas()
        {
            try
            {
                var dbNotasServices = new DbNotasServices();
                ListaNotas.ItemsSource = dbNotasServices.List();
            }
            catch (Exception e)
            {
                DisplayAlert("Erro", e.Message, "Fechar");
            }
        }

        private void ListaNotas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var notaSelecionada = (Nota)ListaNotas.SelectedItem;
            var page = (MasterDetailPage)Application.Current.MainPage;
            page.Detail = new NavigationPage(new CadastrarPage(notaSelecionada));
        }
    }
}