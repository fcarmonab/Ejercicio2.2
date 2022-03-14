using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EjercicioDosPuntoDos.Controllers;
using System.IO;

namespace EjercicioDosPuntoDos
{
    public partial class App : Application
    {
        static SignaturesDB basedatos;

        public static SignaturesDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new SignaturesDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return basedatos;

            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
