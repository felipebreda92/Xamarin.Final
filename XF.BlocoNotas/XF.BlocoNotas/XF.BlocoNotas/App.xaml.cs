using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.BlocoNotas.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF.BlocoNotas
{
    public partial class App : Application
    {
        public static string DbName;
        public static string DbPath;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
