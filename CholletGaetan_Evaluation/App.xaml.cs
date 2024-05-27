using System;
using System.Windows;

namespace CholletGaetan_Evaluation
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            bool? result = loginWindow.ShowDialog();

            if (result != true)
            {
                Shutdown();

            }
        }
    }
}
