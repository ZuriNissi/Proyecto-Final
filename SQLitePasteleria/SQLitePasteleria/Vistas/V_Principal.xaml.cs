using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Principal : ContentPage
    {
        public V_Principal()
        {
            InitializeComponent();
            btnProductos.Clicked += BtnProductos_Clicked;
            btnTiendas.Clicked += BtnTiendas_Clicked;
            btnPasteles.Clicked += BtnPasteles_Clicked;
        }

        private void BtnPasteles_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_Pastel());
        }

        private void BtnTiendas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_Tienda());
        }

        private void BtnProductos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_Productos());
        }
    }
}