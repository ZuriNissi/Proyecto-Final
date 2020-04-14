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
    public partial class V_PastelR : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_PastelR()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnGuardarPas.Clicked += btnGuardarPas_Clicked;
        }

        private void btnGuardarPas_Clicked(object sender, EventArgs e)
        {
            var DatosPasteles = new T_Pasteles
            {
                NombrePastel = txtNombrePast.Text,
                DescripcionPastel = txtDescripcionPast.Text,
               PrecioPastel = txtPrecioPast.Text
                
            };
            conexion.InsertAsync(DatosPasteles);
            limpiarFormulario();
            DisplayAlert("Confirmación", "Pastel registrada correctamente", "Ok");
        }

        private void limpiarFormulario()
        {
            txtNombrePast.Text = "";
            txtDescripcionPast.Text = "";
            txtPrecioPast.Text = "";
         
        }
    }
}
