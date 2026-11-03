using CitasMedicas.Models;

namespace CitasMedicas.Pages;

public partial class SolicitarCita : ContentPage
{
	public SolicitarCita()
	{
		InitializeComponent();

		nombre.Text = Preferences.Get("nombre", string.Empty);
        apellidos.Text = Preferences.Get("apellidos", string.Empty);
        numPaciente.Text = Preferences.Get("numPaciente", string.Empty);
        condicionesCheckBox.IsChecked = Preferences.Get("condicionesCheckBox", false);
            


    }

    private async void OnSolicitarCitaClicked(object sender, EventArgs e)
    {
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