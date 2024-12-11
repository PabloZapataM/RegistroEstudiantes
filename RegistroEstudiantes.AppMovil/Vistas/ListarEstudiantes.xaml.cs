using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using RegistroEstudiantes.Modelos.Modelos;

namespace RegistroEstudiantes.AppMovil.Vistas;

public partial class ListarEstudiantes : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://registroestudiantes-8d55e-default-rtdb.firebaseio.com/");
    public ObservableCollection<Estudiante> Lista { get; set; } = new ObservableCollection<Estudiante>();
	public ListarEstudiantes()
	{
		InitializeComponent();
        BindingContext = this;
        CargarLista();
	}

    private void CargarLista()
    {
        client.Child("Estudiantes").AsObservable<Estudiante>().Subscribe((estudiante) =>
        {
            if (estudiante != null)
            {
                Lista.Add(estudiante.Object);
            }
        });
    }

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void NuevoEstudianteBoton_Clicked(object sender, EventArgs e)
    {

    }
}