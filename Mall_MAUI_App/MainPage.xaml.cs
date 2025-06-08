
using Models;
namespace Mall_MAUI_App
{
    public partial class MainPage : ContentPage
    {
        CatalogViewModel catalog = new CatalogViewModel();

        public MainPage()
        {
            InitializeComponent();
        } 

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
