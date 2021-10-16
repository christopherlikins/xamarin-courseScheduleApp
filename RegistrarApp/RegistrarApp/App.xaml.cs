using RegistrarApp.Models;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;

namespace RegistrarApp
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(FileSystem.AppDataDirectory, "RegistrarAppData.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
