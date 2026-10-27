namespace CitasMedicas.Pages;

public partial class SolicitarCita : ContentPage
{
	public SolicitarCita()
	{
		InitializeComponent();

		nombre.Text = Preferences.Get("nombre", string.Empty);
        apellidos.Text = Preferences.Get("apellidos", string.Empty);
        numPaciente.Text = Preferences.Get("numPaciente", string.Empty);

    }


	private async void OnSolicitarCitaClicked(object sender, EventArgs e)
    {
        if (this.condicionesCheckBox.IsChecked)
        {
            Preferences.Set("nombre", nombre.Text.Trim());
            Preferences.Set("apellidos", apellidos.Text.Trim());
            Preferences.Set("numPaciente", numPaciente.Text.Trim());
// await DisplayAlert("Cita solicitada", "La cita ha sido solicitada correctamente.", "OK");
        } else
        {
            Preferences.Remove("nombre");
            Preferences.Remove("apellidos");
            Preferences.Remove("numPaciente");
        }
       
    }



}