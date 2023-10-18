using Client.ViewModel;
using System.Windows;

namespace Client.Model
{
    public class GeneralCommands : ViewModelBase
    {
        public static void MiniApp()
        {
            var window = System.Windows.Application.Current.Windows[0];

            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        public static void CloseApp()
        {
            Service.Message("The client has completed its work.");
            Service.DeleteEvents();
            Service.DeleteUsers();
            System.Windows.Application.Current.Shutdown();
        }
    }
}