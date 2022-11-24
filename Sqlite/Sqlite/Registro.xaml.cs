using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite;
using Sqlite.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con; 
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

       

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiantes { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contraseña = txtContraseña.Text };
                con.InsertAsync(datosRegistro);
                DisplayAlert("Mensaje","Ingreso correcto", "cerrar");

                txtUsuario.Text = "";
                txtNombre.Text = "";
                txtContraseña.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Mensaje", ex.Message, "cerrar");
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}