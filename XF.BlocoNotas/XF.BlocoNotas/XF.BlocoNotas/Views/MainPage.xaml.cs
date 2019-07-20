using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnHome_OnClicked(new Object(), new EventArgs());
        }

        private void BtnHome_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CadastrarPage());
            IsPresented = false;
        }

        private void BtnListar_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListarPage());
            IsPresented = false;
        }
    }
}