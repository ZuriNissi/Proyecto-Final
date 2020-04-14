using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLitePasteleria.Datos;
using SQLitePasteleria.Tablas;
using SQLite;
using System.IO;

namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_PastelD : ContentPage
    {

        public int idSeleccionado;
        public string NombrePastelSeleccionado, DescripcionPastelSeleccionado,
            PrecioPastelSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<T_Pasteles> ResuladoDeleteP;
        IEnumerable<T_Pasteles> ResuladoUpdateP;
        public V_PastelD(int Id, string NombrePastel, string DescripcionPastel, string PrecioPastel)
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            idSeleccionado = Id;
            NombrePastelSeleccionado = NombrePastel;
            DescripcionPastelSeleccionado = DescripcionPastel;
            PrecioPastelSeleccionado = PrecioPastel;

            btn_Actualizar.Clicked += Btn_Actualizar_Clicked;
            btn_Eliminar.Clicked += Btn_Eliminar_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensajes.Text = "Id: " + idSeleccionado;
            txtNombrePast.Text = NombrePastelSeleccionado;
            txtDescripPas.Text = DescripcionPastelSeleccionado;
            txtPrecioPast.Text = PrecioPastelSeleccionado;
           
        }

        private void Btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResuladoDeleteP = Delete(db, idSeleccionado);
            DisplayAlert("Confirmacion", "La tienda se elimino correctamente", "ok");
            LimpiarD();

        }

        private void Btn_Actualizar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResuladoUpdateP = Update(db, txtNombrePast.Text, txtDescripPas.Text, txtPrecioPast.Text,
            idSeleccionado);
            DisplayAlert("Confirmacion", "La tienda se actualizo correctamente", "ok");
        }

        private IEnumerable<T_Pasteles> Delete(SQLiteConnection db, int id)
        {
            return db.Query<T_Pasteles>("DELETE FROM T_Pasteles where Id = ?", id);
        }

        private IEnumerable<T_Pasteles> Update(SQLiteConnection db, string NombrePastel, string
            DescripcionPastel, string PrecioPastel, int id)
        {
            return db.Query<T_Pasteles>("UPDATE T_Pasteles SET NombrePastel = ?, DescripcionPastel = ?,PrecioPastel = ?  " +
                "where Id = ?", NombrePastel, DescripcionPastel, PrecioPastel, id);
        }

        public void LimpiarD()
        {
            lblMensajes.Text = "";
            txtNombrePast.Text = "";
            txtDescripPas.Text = "";
            txtPrecioPast.Text = "";
           
        }
    }
}