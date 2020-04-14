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
    public partial class V_TiendaB : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<T_Tiendas> TablaTiendas;
        public V_TiendaB()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            ListaTiendas.ItemSelected += ListaTiendas_ItemSelected;
        }
        private void ListaTiendas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (T_Tiendas)e.SelectedItem;
            var item = Obj.Id.ToString();
            var NombreTienda = Obj.NombreTienda;
            var CalleTienda = Obj.CalleTienda;
            var NumeroEx = Obj.NumeroEx;
            var NumeroIn = Obj.NumeroIn;
            var Colonia = Obj.Colonia;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new V_TiendaD(ID, NombreTienda, CalleTienda, NumeroEx, NumeroIn, Colonia));
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResultRegistros = await conexion.Table<T_Tiendas>().ToListAsync();
            TablaTiendas = new ObservableCollection<T_Tiendas>(ResultRegistros);
            ListaTiendas.ItemsSource = TablaTiendas;
            base.OnAppearing();
        }
    }
}