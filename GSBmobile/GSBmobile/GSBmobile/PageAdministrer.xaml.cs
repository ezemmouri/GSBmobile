using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace GSBmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAdministrer : ContentPage
    {
        public Categorie categorie;
        public PageAdministrer(Categorie laCategorie)
        {
            InitializeComponent();
            categorie = laCategorie;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            {
                if (listeCategAntibio.SelectedItem != null)
                {
                    
                    bool kilosSaisi = false;
                    Antibio antibio = listeCategAntibio.SelectedItem as Antibio;
                    //txtMoyNombre.Text = Convert.ToString(DataAntibio.getMoyNombreParJour(categorie));
                    if (antibio is AntibioParKilo)
                    {
                        if (entPoids.Text != null)
                        {
                            kilosSaisi = true;
                        }
                    }
                    else 
                    // si l'antibio est par prise
                    {
                        kilosSaisi = true;
                    }
                    if (kilosSaisi)
                    {
                        int nombreParJour = antibio.getNombre();
                        if (antibio is AntibioParKilo)
                        {
                            AntibioParKilo d = (AntibioParKilo)antibio;
                            txtResultat.Text = "La quantité est de :" + (d.getDoseKilo() * Convert.ToInt32(entPoids.Text)).ToString() + " mg " + nombreParJour.ToString() + " fois par jour";
                        }
                        else
                        {
                            AntibioParPrise d = (AntibioParPrise)antibio;
                            txtResultat.Text = "La quantité est de :" + (d.getDosePrise()).ToString() + " mg " + nombreParJour.ToString() + " fois par jour";
                        }
                    }
                    else
                    {
                        txtResultat.Text = "Saisir le nombre de kilos";
                    }
                }
                else
                {
                    txtResultat.Text = "Selectionner un antibiotique";
                }
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public List<Categorie> lesCategories;
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            DataAntibio.initialiser();
            txtT.Text = categorie.getLibelle();
            Categorie categ = new Categorie(txtT.Text);
            listeCategAntibio.ItemsSource = DataAntibio.getAntibiotiquesUneCateg(categ).ToList();
        }

        private void ListeCategAntibio_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}