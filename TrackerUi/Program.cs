namespace TrackerUi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Tourament_library.globalConfig.InitializingConnection(Tourament_library.DatabaseType.TextFile);
            ApplicationConfiguration.Initialize();
            Application.Run(new CreatTour());
        }
    }
}