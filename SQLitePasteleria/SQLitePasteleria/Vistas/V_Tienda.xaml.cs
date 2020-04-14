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
    public partial class V_Tienda : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_Tienda()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnRegistroT.Clicked += BtnRegistroT_Clicked;
            btnBuscarT.Clicked += BtnBuscarT_Clicked;
        }

        private void BtnBuscarT_Clicked(object sender, EventArgs e)
        {
            try
            {
                var rutaDB = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.MyDocuments), "PasteleriaSQLite.db3");
                var db = new SQLiteConnection(rutaDB);
                db.CreateTable<T_Tiendas>();
                IEnumerable<T_Tiendas> resultado = SELECT_WHERE(db, txtNombret.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new V_TiendaB());
                    DisplayAlert("Aviso", "Existen tiendas con ese nombre", "Ok");
                }
                else
                {
                    DisplayAlert("Aviso", "NO existente tiendas con ese nombre", "Ok");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private IEnumerable<T_Tiendas> SELECT_WHERE(SQLiteConnection db, string NombreTienda)
        {
            return db.Query<T_Tiendas>("SELECT * FROM T_Tiendas WHERE NombreTienda = ?", NombreTienda);
        }

        private void BtnRegistroT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_TiendaR());
        }
    }


}