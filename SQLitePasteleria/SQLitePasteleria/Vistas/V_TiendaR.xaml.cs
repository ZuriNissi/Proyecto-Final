using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePasteleria.Tablas;
using SQLitePasteleria.Datos;

namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_TiendaR : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_TiendaR()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnGuardarT.Clicked += BtnGuardarT_Clicked;
        }

        private void BtnGuardarT_Clicked(object sender, EventArgs e)
        {
            var DatosTienda = new T_Tiendas
            {
                NombreTienda = txtNombret.Text,
                CalleTienda = txtcallet.Text,
                NumeroEx = txtNumext.Text,
                NumeroIn = txtNumint.Text,
                Colonia = txtColoniat.Text
            };
            conexion.InsertAsync(DatosTienda);
            limpiarFormulario();
            DisplayAlert("Confirmación", "Tienda registrada correctamente", "Ok");
        }

        private void limpiarFormulario()
        {
            txtNombret.Text = "";
            txtcallet.Text = "";
            txtNumext.Text = "";
            txtNumint.Text = "";
            txtColoniat.Text = "";
        }
    }
}
   