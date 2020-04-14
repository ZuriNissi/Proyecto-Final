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
    public partial class V_Productos : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_Productos()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnBuscaP.Clicked += btnBuscaP_Clicked;
            btnRegistP.Clicked += btnRegistP_Clicked;
        }

        private void btnBuscaP_Clicked(object sender, EventArgs e)
        {
            try
            {
                var rutaDB = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.MyDocuments), "PasteleriaSQLite.db3");
                var db = new SQLiteConnection(rutaDB);
                db.CreateTable<T_Productos>();
                IEnumerable<T_Productos> resultado = SELECT_WHERE(db, txtNombrep.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new V_ProductosB());
                    DisplayAlert("Aviso", "Existen productos con ese nombre", "Ok");
                }
                else
                {
                    DisplayAlert("Aviso", "NO existente productos con ese nombre", "Ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<T_Productos> SELECT_WHERE(SQLiteConnection db, string nombre)
        {
            return db.Query<T_Productos>("SELECT * FROM T_Productos WHERE Nombre =?", nombre);
        }

        private void btnRegistP_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_ProductosR());
        }
    }
}