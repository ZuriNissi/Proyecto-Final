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
    public partial class V_ProductosR : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_ProductosR()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnGuardarR.Clicked += BtnGuardarR_Clicked;
        }

        private void BtnGuardarR_Clicked(object sender, EventArgs e)
        {
           var DatosProducto = new T_Productos { Nombre = txtNombrep.Text, Precio = txtPreciop.Text,
               Descripcion = txtDescripcionp.Text, Cantidad = txtCantidadp.Text};
            conexion.InsertAsync(DatosProducto);
            limpiarformulario();
            DisplayAlert("Confirmación","Producto registrado correctamente","Ok");
        }

        private void limpiarformulario()
        {
            txtNombrep.Text = "";
            txtPreciop.Text = "";
            txtDescripcionp.Text = "";
            txtCantidadp.Text = "";
        }
    }
}