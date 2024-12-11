using Firebase.Database;
using Firebase.Database.Query;
using RegistroEstudiantes.Modelos.Modelos;
namespace RegistroEstudiantes.AppMovil.Vistas;

public partial class CrearEstudiante : ContentPage
{
	FirebaseClient client = new FirebaseClient("https://registroestudiantes-8d55e-default-rtdb.firebaseio.com/");
	public List<Curso> Cursos { get; set; }

	public CrearEstudiante()
	{
		InitializeComponent();
		ListarCurso();
		BindingContext = this;


	}

	private void ListarCurso()
	{
		var cursos = client.Child("Curso").OnceAsync<Curso>();
		Cursos = cursos.Result.Select(x => x.Object).ToList();

	}

	private async void guardarButton_Clicked(object sender, EventArgs e)
	{
		Curso curso = cursoPicker.SelectedItem as Curso;

		var estudiante = new Estudiante
		{
			PrimerNombre = primernombreEntry.Text,
			SegundoNombre = segundonombreEntry.Text,
			PrimerApellido = primerapellidoEntry.Text,
			SegundoApellido = segundoapellidoEntry.Text,
			Edad = int.Parse(edadEntry.Text),
			curso = curso

		};

		try
		{
			await client.Child("Estudiantes").PostAsync(estudiante);
			await DisplayAlert("Exito", $"El estudiante{estudiante.PrimerNombre} {estudiante.PrimerApellido} fue guardado correctamente", "OK");
			await Navigation.PopAsync();
		}
		catch (Exception ex)
		{

			await DisplayAlert("Error", ex.Message, "OK");
		}


	}
} 
