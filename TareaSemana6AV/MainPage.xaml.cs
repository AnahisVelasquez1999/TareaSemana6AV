using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaSemana6AV.Ws;
using Xamarin.Forms;

namespace TareaSemana6AV
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.10/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<TareaSemana6AV.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<TareaSemana6AV.Ws.Datos> posts = JsonConvert.DeserializeObject<List<TareaSemana6AV.Ws.Datos>>(content);
            _post = new ObservableCollection<TareaSemana6AV.Ws.Datos>(posts);

            MLSView.ItemsSource = _post;
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Post());
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            TareaSemana6AV.Ws.Datos club = (TareaSemana6AV.Ws.Datos)lv.SelectedItem;
            await Navigation.PushModalAsync(new Put(club.codigo, club.nombre, club.apellido, club.edad));
        }
    }
}
