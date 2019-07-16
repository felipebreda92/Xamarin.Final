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

        private void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                InserirNotas();
                ListarNotas();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Fechar");
            }
        }

        public void ListarNotas()
        {
            var dbNotasServices = new DbNotasServices();
            ListaNotas.ItemsSource = dbNotasServices.List();
        }

        private void InserirNotas()
        {
            var nota = new Nota();
            nota.Titulo = $"Teste - {DateTime.Now}";
            nota.Dados = "Vai que vai";

            var dbNotasServices = new DbNotasServices();
            dbNotasServices.Insert(nota);

            DisplayAlert("Retorno da operção", dbNotasServices.StatusMessage, "Fechar");
        }
    }
}