namespace CitasMedicas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SolicitarCitaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SolicitarCita());
        }

        private async void VerCitasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ConsultaCitasPage());
        }
    }
}
