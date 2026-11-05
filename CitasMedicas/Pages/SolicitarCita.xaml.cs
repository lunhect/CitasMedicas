using System.Text.Json;
using CitasMedicas.Model;


namespace CitasMedicas.Pages;

public partial class SolicitarCita : ContentPage
{
	public SolicitarCita()
	{
		InitializeComponent();

        ListaEspecialidades.ItemsSource = CargarEspecialidades();

		nombre.Text = Preferences.Get("nombre", string.Empty);
        apellidos.Text = Preferences.Get("apellidos", string.Empty);
        numPaciente.Text = Preferences.Get("numPaciente", string.Empty);
        condicionesCheckBox.IsChecked = Preferences.Get("condicionesCheckBox", false);
            


    }

    private async void OnSolicitarCitaClicked(object sender, EventArgs e)
    {
        
        if (string.IsNullOrWhiteSpace(nombre.Text) || string.IsNullOrWhiteSpace(apellidos.Text) || string.IsNullOrWhiteSpace(numPaciente.Text))
        {
            await DisplayAlertAsync("Faltan datos", "Introduce nombre, apellidos y número de paciente.", "OK");
            return;


        }

        if (cursoPicker.SelectedItem == null)
        {
            await DisplayAlertAsync("Faltan datos", "Selecciona una preferencia de turno.", "OK");
            return;
        }



        if (ListaEspecialidades.SelectedItem == null) 
        {  
            await DisplayAlertAsync("Faltan datos", "Selecciona una especialidad.", "OK"); 
             return; 
        
        }






        if (this.condicionesCheckBox.IsChecked)
        {

            Preferences.Set("nombre", nombre.Text.Trim());
            Preferences.Set("apellidos", apellidos.Text.Trim());
            Preferences.Set("numPaciente", numPaciente.Text.Trim());
            Preferences.Set("condicionesCheckBox", condicionesCheckBox.IsChecked);

        } else
        {
            Preferences.Remove("nombre");
            Preferences.Remove("apellidos");
            Preferences.Remove("numPaciente");
            Preferences.Remove("condicionesCheckBox");
        }





        var elegida = (Especialidad)ListaEspecialidades.SelectedItem;

        var cita = new Cita
        {

            Nombre = nombre.Text.Trim(),
            Apellidos = apellidos.Text.Trim(),
            NumPaciente = numPaciente.Text.Trim(),
            Turno = (string)cursoPicker.SelectedItem,
            Especialidad = elegida.Nombre,
            Doctor = elegida.Doctor,
            DiasEspera = elegida.DiasEspera,
            FechaSolicitud = DateTime.Now



        };

        string rutaCitas = Path.Combine(FileSystem.AppDataDirectory, "citas.json");

        List<Cita> citas = new List<Cita>();


        if (File.Exists(rutaCitas))
        {


            string json = File.ReadAllText(rutaCitas);
            citas = JsonSerializer.Deserialize<List<Cita>>(json)
                ?? new List<Cita>();


        }

        citas.Add(cita);

        string texto = JsonSerializer.Serialize(citas);
        File.WriteAllText(rutaCitas, texto);

        await DisplayAlertAsync("Cita solicitada",
    $"{cita.Nombre} {cita.Apellidos}, a la mayor brevedad le informaremos de su cita en {cita.Especialidad}. Puede consultar sus citas desde la sección Consulta de citas.",
    "OK");



    }

    private List<Especialidad> CargarEspecialidades()
 {
        return new List<Especialidad>
     {
         new Especialidad { Imagen = "cardiologia.png",   Nombre = "Cardiología",          Doctor = "Dra. Laura Martín",   DiasEspera = 25 },
         new Especialidad { Imagen = "dermatologia.png",  Nombre = "Dermatología",         Doctor = "Dr. Javier Ruiz",     DiasEspera = 40 },
         new Especialidad { Imagen = "oftalmologia.png",  Nombre = "Oftalmología",         Doctor = "Dra. Elena Gómez",    DiasEspera = 32 },
         new Especialidad { Imagen = "traumatologia.png", Nombre = "Traumatología",        Doctor = "Dr. Carlos Navarro",  DiasEspera = 55 },
         new Especialidad { Imagen = "pediatria.png",     Nombre = "Pediatría",            Doctor = "Dra. Marta Sánchez",  DiasEspera = 7 },
         new Especialidad { Imagen = "neurologia.png",    Nombre = "Neurología",           Doctor = "Dr. Andrés López",    DiasEspera = 60 },
         new Especialidad { Imagen = "ginecologia.png",   Nombre = "Ginecología",          Doctor = "Dra. Sofía Torres",   DiasEspera = 21 },
         new Especialidad { Imagen = "otorrino.png",      Nombre = "Otorrinolaringología", Doctor = "Dr. Pablo Hernández", DiasEspera = 35 }
     };
    }


}