using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace GSBmobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            initialisation();

        }

        private async void initialisation()
        {
            HttpClient wc = new HttpClient();
            var reponse = await wc.GetStringAsync("https://apievangsb.000webhostapp.com/categories.php");
            List<Categorie> lesCategories = JsonConvert.DeserializeObject<List<Categorie>>(reponse);
            listeCateg.ItemsSource = lesCategories;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            DataAntibio.initialiser();
            listeCateg.ItemsSource = DataAntibio.getLesCategories().ToList();
        }

        private void ListeCateg_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new PageAdministrer(listeCateg.SelectedItem as Categorie));
        }
    }
}
