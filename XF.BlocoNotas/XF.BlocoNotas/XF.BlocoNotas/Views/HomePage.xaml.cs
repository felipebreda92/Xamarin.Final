using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var page = (MasterDetailPage)Application.Current.MainPage;
            page.Detail = new NavigationPage(new CadastrarPage());
            page.IsPresented = false;
        }

        private void TapGestureRecognizer_OnTapped_1(object sender, EventArgs e)
        {
            var page = (MasterDetailPage)Application.Current.MainPage;
            page.Detail = new NavigationPage(new ListarPage());
            page.IsPresented = false;
        }
    }
}