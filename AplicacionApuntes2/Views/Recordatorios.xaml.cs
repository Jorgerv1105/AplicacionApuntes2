using AplicacionApuntes2.ViewModels;
namespace AplicacionApuntes2.Views;

public partial class Recordatorios : ContentPage
{
    private RecordatoriosViewModel viewModel;

    public Recordatorios()
    {
        InitializeComponent();
        viewModel = new RecordatoriosViewModel();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.Cargar();
    }
}
