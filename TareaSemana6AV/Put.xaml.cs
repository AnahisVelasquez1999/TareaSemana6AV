using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaSemana6AV.Ws;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSemana6AV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {

        public Put(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtEdad.Text = Convert.ToString(edad);
            txtCodigo.Text = Convert.ToString(codigo);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.1.10/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                await DisplayAlert("Warning", "Dato Actualizado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Remove(txtCodigo.Text);
                parametros.Remove(txtNombre.Text);
                parametros.Remove(txtApellido.Text);
                parametros.Remove(txtEdad.Text);
                cliente.UploadValues("http://192.168.1.10/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "DELETE", parametros);
                await DisplayAlert("Warning", "Dato Eliminado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }
    }
}