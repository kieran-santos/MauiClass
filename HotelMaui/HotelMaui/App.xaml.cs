using HotelMaui.Models;

namespace HotelMaui
{
    public partial class App : Application
    {
        public static List<Usuario> lista_usuarios = new();
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window w = new Window(new AppShell())
            {
                Height = 600,
                Width = 300
            };

            return w;
        }
    }
}