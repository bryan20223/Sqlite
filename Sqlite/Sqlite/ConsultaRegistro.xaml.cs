using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using Sqlite.Model;

namespace Sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiantes> TablaEstudiantes;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }


        public async void Datos() {

            var Resultado = await con.Table<Estudiantes>().ToListAsync();
            TablaEstudiantes = new ObservableCollection<Estudiantes>(Resultado);
            ListaEstudiantes.ItemsSource = TablaEstudiantes;
    }

            private void ListaEstudiantes_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiantes)e.SelectedItem;
            var item = Obj.Id.ToString();
            var Idseleccionado =Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(Idseleccionado));
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}