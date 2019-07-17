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
    public partial class CadastrarPage : ContentPage
    {
        public CadastrarPage()
        {
            InitializeComponent();
        }

        public CadastrarPage(Nota nota)
        {
            InitializeComponent();
            btnSalvar.Text = "Alterar";
            txtCodigo.IsVisible = true;

            txtTitulo.Text = nota.Titulo;
            txtDados.Text = nota.Dados;
            txtCodigo.Text = nota.Id.ToString();
            swtFavorito.IsToggled = nota.Favorito;
        }

        private void BtnSalvar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var nota = new Nota
                {
                    Titulo = txtTitulo.Text,
                    Dados = txtDados.Text,
                    Favorito = swtFavorito.IsToggled
                };

                var dbNotasServices = new DbNotasServices();

                if (btnSalvar.Text.Equals("Salvar"))
                {
                    dbNotasServices.Insert(nota);
                }
                else if (btnSalvar.Text.Equals("Alterar"))
                {
                    nota.Id = int.Parse(txtCodigo.Text);
                    dbNotasServices.Update(nota);
                }

                DisplayAlert("Retorno da operção", dbNotasServices.StatusMessage, "OK");


                var page = (MasterDetailPage)Application.Current.MainPage;
                page.Detail = new ListarPage();

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Fechar");

            }
        }

        private void BtnCancelar_OnClicked(object sender, EventArgs e)
        {
            var page = (MasterDetailPage)Application.Current.MainPage;
            page.Detail = new HomePage();
        }
    }
}