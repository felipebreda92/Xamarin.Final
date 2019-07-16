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
            Detail = new HomePage();
            IsPresented = false;
        }

        private void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            Detail = new CadastrarPage();
            IsPresented = false;
        }

        private void BtnListar_OnClicked(object sender, EventArgs e)
        {
            Detail = new ListarPage();
            IsPresented = false;
        }

        private void BtnSobre_OnClicked(object sender, EventArgs e)
        {
            Detail = new SobrePage();
            IsPresented = false;
        }
    }
}