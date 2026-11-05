using System.Text.Json;
using CitasMedicas.Model;

namespace CitasMedicas.Pages;

public partial class ConsultaCitasPage : ContentPage
{
    public ConsultaCitasPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        string rutaCitas = Path.Combine(FileSystem.AppDataDirectory, "citas.json");

        List<Cita> citas = new List<Cita>();
        if (File.Exists(rutaCitas))
        {
            string json = File.ReadAllText(rutaCitas);
            citas = JsonSerializer.Deserialize<List<Cita>>(json) ?? new List<Cita>();
        }

        // Si la lista está vacía, el EmptyView muestra el texto solo
        ListaCitas.ItemsSource = citas;
    }
}
