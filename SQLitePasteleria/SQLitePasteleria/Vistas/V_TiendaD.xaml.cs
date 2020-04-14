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
    public partial class V_TiendaD : ContentPage
    {
       
        public int idSeleccionado;
        public string NombreTiendaSeleccionado, CalleTiendaSeleccionado,
            NumeroExSeleccionado, NumeroInSeleccionado, ColoniaSeleccionado;
        private SQLiteAsyncConnection conexionn;
        IEnumerable<T_Tiendas> ResuladoDeleteD;
        IEnumerable<T_Tiendas> ResultadoUpdateD;
        public V_TiendaD(int Id, string nombretienda, string calletienda, string numeroex, string numeroin, string colonia)
        {
            InitializeComponent();
            conexionn = DependencyService.Get<ISQLiteDB>().GetConnection();
            idSeleccionado = Id;
            NombreTiendaSeleccionado = nombretienda;
            CalleTiendaSeleccionado = calletienda;
            NumeroExSeleccionado = numeroex;
            NumeroInSeleccionado = numeroin;
            ColoniaSeleccionado = colonia;

            btn_Actualizar.Clicked += Btn_Actualizar_Clicked;
            btn_Eliminar.Clicked += Btn_Eliminar_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensajes.Text = "Id: " + idSeleccionado;
            txtNombretd.Text = NombreTiendaSeleccionado;
            txtcalletd.Text = CalleTiendaSeleccionado;
            txtNumextd.Text = NumeroExSeleccionado;
            txtNumintd.Text = NumeroInSeleccionado;
            txtColoniatd.Text = ColoniaSeleccionado;
        }

        private void Btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResuladoDeleteD = Delete(db, idSeleccionado);
            DisplayAlert("Confirmacion", "La tienda se elimino correctamente", "ok");
            LimpiarD();

        }

        private void Btn_Actualizar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PasteleriaSQLite.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoUpdateD = Update(db, txtNombretd.Text, txtcalletd.Text, txtNumextd.Text,
            txtNumintd.Text, txtColoniatd.Text, idSeleccionado);
            DisplayAlert("Confirmacion", "La tienda se actualizo correctamente", "ok");
        }

        private IEnumerable<T_Tiendas> Delete(SQLiteConnection db, int id)
        {
            return db.Query<T_Tiendas>("DELETE FROM T_Tiendas where Id = ?", id);
        }

        private IEnumerable<T_Tiendas> Update(SQLiteConnection db, string nombretienda, string
            CalleTienda, string NumeroEx, string NumeroIn, string Colonia, int id)
        {
            return db.Query<T_Tiendas>("UPDATE T_Tiendas SET NombreTienda = ?, CalleTienda = ?,NumeroIn = ? ,NumeroEn = ? ,Colonia = ? " +
                "where Id = ?", nombretienda, CalleTienda, NumeroIn, NumeroEx, Colonia,id);
        }

        public void LimpiarD()
        {
            lblMensajes.Text = "";
            txtNombretd.Text = "";
            txtcalletd.Text = "";
            txtNumintd.Text = "";
            txtNumextd.Text = "";
            txtColoniatd.Text = "";
        }
    }
}