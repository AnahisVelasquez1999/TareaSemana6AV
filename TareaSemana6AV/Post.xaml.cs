using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSemana6AV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Post : ContentPage
    {
        public Post()
        {
            InitializeComponent();
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.1.10/moviles/post.php", "POST", parametros);
                await DisplayAlert("alerta", "Dato Ingresado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}