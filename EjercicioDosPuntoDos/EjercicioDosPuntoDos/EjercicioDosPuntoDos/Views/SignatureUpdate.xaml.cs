using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EjercicioDosPuntoDos.Models;
using SignaturePad.Forms;
using Xamarin.Essentials;
using System.IO;

namespace EjercicioDosPuntoDos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignatureUpdate : ContentPage
    {
        CancellationTokenSource cts;

        public SignatureUpdate()
        {
            InitializeComponent();
        }

        byte[] ImageBytes;

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {

            Stream Image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);

            try
            {
                //convertimos imagen a base 64
                var image = await PadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                var mStream = (MemoryStream)image;
                byte[] data = mStream.ToArray();
                string base64Val = Convert.ToBase64String(data);
                ImageBytes = Convert.FromBase64String(base64Val);


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }


            var firma = new Signatures
            {
                Nombre = nombre.Text,
                Descripcion = descripcion.Text,
                Imagen = ImageBytes

            };



            if (String.IsNullOrEmpty(nombre.Text) || String.IsNullOrEmpty(descripcion.Text))
            {
                await DisplayAlert("Aviso", "Favor no dejar campos vacios", "Ok");

            }
            else
            {
                await DisplayAlert("Aviso", "Firma Registrada con Exito!!!", "Ok");
                await App.BaseDatos.GuardarFirma(firma);
                PadView.Clear();
                nombre.Text = "";
                descripcion.Text = "";
            }

            await Navigation.PopAsync();
        }

        
    }
}