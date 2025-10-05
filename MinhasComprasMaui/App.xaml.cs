using Minhas_ComprasMAUI.Helpers;

namespace MinhasComprasMaui
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db 
        {
            get
            { 
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), 
                        "baanco_sqlite_compras.db3"
                    );
                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }
            

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());
            
            //MainPage = new AppShell();
        }
    }
}
