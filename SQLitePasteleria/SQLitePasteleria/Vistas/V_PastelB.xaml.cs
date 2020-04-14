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
    public partial class V_PastelB : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<T_Pasteles> TablaTiendas;
        public V_PastelB()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            ListaPasteles.ItemSelected += ListaPasteles_ItemSelected;
        }
        private void ListaPasteles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (T_Pasteles)e.SelectedItem;
            var item = Obj.Id.ToString();
            var NombrePastel = Obj.NombrePastel;
            var DescripcionPastel = Obj.DescripcionPastel;
            var PrecioPastel = Obj.PrecioPastel;
            
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new V_PastelD(ID, NombrePastel, DescripcionPastel, PrecioPastel));
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResultRegistros = await conexion.Table<T_Pasteles>().ToListAsync();
            TablaTiendas = new ObservableCollection<T_Pasteles>(ResultRegistros);
            ListaPasteles.ItemsSource = TablaTiendas;
            base.OnAppearing();
        }
    }
}