namespace AplicacionApuntes2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AllNotesPage), typeof(Views.AllNotesPage));
        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}
