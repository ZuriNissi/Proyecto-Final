using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePasteleria.Tablas;
using System.IO;
using SQLitePasteleria.Datos;

namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Pastel : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_Pastel()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnBuscaPas.Clicked += btnBuscaPas_Clicked;
            btnRegistPas.Clicked += btnRegistPas_Clicked;
        }

        private void btnBuscaPas_Clicked(object sender, EventArgs e)
        {
            try
            {
                var rutaDB = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.MyDocuments), "PasteleriaSQLite.db3");
                var db = new SQLiteConnection(rutaDB);
                db.CreateTable<T_Pasteles>();
                IEnumerable<T_Pasteles> resultado = SELECT_WHERE(db, txtNombrepas.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new V_PastelB());
                    DisplayAlert("Aviso", "Existen pasteles con ese nombre", "Ok");
                }
                else
                {
                    DisplayAlert("Aviso", "NO existe el pastel con ese nombre", "Ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<T_Pasteles> SELECT_WHERE(SQLiteConnection db, string nombrePastel)
        {
            return db.Query<T_Pasteles>("SELECT * FROM T_Pasteles WHERE NombrePastel =?", nombrePastel);
        }

        private void btnRegistPas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_PastelR());
        }
    }
}