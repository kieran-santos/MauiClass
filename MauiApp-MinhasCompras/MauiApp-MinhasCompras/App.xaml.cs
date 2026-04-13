using System.Globalization;
using MauiApp_MinhasCompras.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp_MinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper? _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string caminho_do_arquivo = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compars.db3"
                        );

                    _db = new SQLiteDatabaseHelper(caminho_do_arquivo);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}