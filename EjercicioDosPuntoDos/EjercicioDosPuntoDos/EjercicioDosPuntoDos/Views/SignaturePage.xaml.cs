using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EjercicioDosPuntoDos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjercicioDosPuntoDos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturePage : ContentPage
    {
        Signatures users = new Signatures();

        public SignaturePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            var listaFirmas = await App.BaseDatos.ListaFirmas();

            ObservableCollection<Signatures> observableCollectionFotos = new ObservableCollection<Signatures>();
            listOfSignatures.ItemsSource = observableCollectionFotos;
            foreach (Signatures imagen in listaFirmas)
            {
                observableCollectionFotos.Add(imagen);
            }

        }

        private async void Signature_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            try
            {
                Models.Signatures item = (Models.Signatures)e.Item;
                var newpage = new Views.SignatureUpdate();
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }


    }
}