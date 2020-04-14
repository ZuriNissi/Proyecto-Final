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
using System.Collections.ObjectModel;
using System.IO;


namespace SQLitePasteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_ProductosB : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<T_Productos> TablaProductos;
        public V_ProductosB()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            ListaProductos.ItemSelected += ListaProductos_ItemSelected;
        }

        private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (T_Productos)e.SelectedItem;
            var item = Obj.Id.ToString();
            var Nombre = Obj.Nombre;
            var Precio = Obj.Precio;
            var Descripcion = Obj.Descripcion;
            var Cantidad = Obj.Cantidad;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new V_ProductosE(ID, Nombre, Precio, Descripcion, Cantidad));
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResultRegistros = await conexion.Table<T_Productos>().ToListAsync();
            TablaProductos = new ObservableCollection<T_Productos>(ResultRegistros);
            ListaProductos.ItemsSource = TablaProductos;
            base.OnAppearing();
        }
    }
}