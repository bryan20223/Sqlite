using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite.Model;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiantes> Borrar;
        IEnumerable<Estudiantes> Actualizar;

        public Elemento(int id)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<DataBase>().GetConnection();

        }


        public static IEnumerable<Estudiantes> Borrar1(SQLiteConnection db, int id) {

            return db.Query<Estudiantes>("Delete from Estudiantes Where id = ?", id);


        }

        public static IEnumerable<Estudiantes>actualizar(SQLiteConnection db, int id, string Nombre, string usuario,string contraseña)
        {
            return db.Query<Estudiantes>("Update Estudiantes set Nombre = ?, Usuario = ?, Contraseña = ? where id = ? ", Nombre, usuario, contraseña,id); 
        


        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                Actualizar = actualizar(db, idSel, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
                DisplayAlert("mensaje ", "actualizado", "ok");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
            Borrar = Borrar1(db, idSel);
            DisplayAlert("mensaje ", "eliminar", "ok");


        }
    }
}