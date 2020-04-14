using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePasteleria.Datos;
using SQLitePasteleria.Tablas;
using System.IO;


namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_ProductosE : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, PreSeleccionado, DescSeleccionado,  CanSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<T_Productos> ResultadoDelete;
        IEnumerable<T_Productos> ResultadoUpdate;

        public V_ProductosE(int Id, string Nombre, string Precio, string Descripcion, string Cantidad)
        {

            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            IdSeleccionado = Id;
            NomSeleccionado = Nombre;
            PreSeleccionado = Precio;
            DescSeleccionado = Descripcion;
            CanSeleccionado = Cantidad;
            btn_actualizarP.Clicked += Btn_actualizarP_Clicked;
            btn_eliminarP.Clicked += Btn_eliminarP_Clicked;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = "ID: " + IdSeleccionado;
            txtNombrep.Text = NomSeleccionado;
            txtPreciop.Text = PreSeleccionado;
            txtDescripcionp.Text = DescSeleccionado;
            txtCantidadp.Text = CanSeleccionado;
                
        }

        private void Btn_eliminarP_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.MyDocuments), "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Confirmación","El producto se elimino correctamente","Ok");
            Limpiar();
        }

        private IEnumerable<T_Productos> Delete(SQLiteConnection db, int Id)
        {
            return db.Query<T_Productos>("DELETE FROM T_Productos where Id = ?", Id);

        }

        private void Limpiar()
        {
            lblMensaje.Text = "";
            txtNombrep.Text = "";
            txtPreciop.Text = "";
            txtDescripcionp.Text = "";
            txtCantidadp.Text = "";
        }

        private void Btn_actualizarP_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.MyDocuments), "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoUpdate = Update(db, txtNombrep.Text, txtPreciop.Text,
            txtDescripcionp.Text, txtCantidadp.Text, IdSeleccionado);
            DisplayAlert("Confirmación", "El producto se actualizo correctamente", "Ok");
        }

        private IEnumerable<T_Productos> Update(SQLiteConnection db, string Nombre, string Precio, string Descripcion, string Cantidad, int Id)
        {
            return db.Query<T_Productos>("Update T_Productos Set Nombre = ?, Precio = ?," +
                "Descripcion = ?, Cantidad = ? where id = ?", Nombre, Precio, Descripcion, Cantidad, Id);

        }
    }
}