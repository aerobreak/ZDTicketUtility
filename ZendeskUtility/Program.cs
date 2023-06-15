using log4net.Config;

namespace ZendeskUtility
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
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log4net.Config.XmlConfigurator.Configure();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}