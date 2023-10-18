using Client.Model;
using System.Windows;

namespace Client.ViewModel
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        private RelayCommand _loginUsersCommand;
        private RelayCommand _closeAppCommand;
        private RelayCommand _minimizedCommand;

        public string Login { get; set; }
        public string Password { get; set; }

        private void LoginUsers()
        {
            var user = new User();

            user.Name = Login;
            user.Password = Password;

            if (Service.CheckUser(user.Name, user.Password))
            {
                var main = new MainWindowView();
                var window = Application.Current.Windows[0];

                if (window != null)
                {
                    main.Show();
                    window.Close();
                }
                Service.Message($"User {Login} authorization was successful.");
            }
            else
            {
                MessageBox.Show("User is not found.");
                Service.Message("User is not found.");
            }
        }

        #region Command

        public RelayCommand LoginUsersCommand
            => _loginUsersCommand ?? (_loginUsersCommand = new RelayCommand(() =>
            {
                LoginUsers();
            }));

        public RelayCommand GetCloseAppCommand
            => _closeAppCommand ?? (_closeAppCommand = new RelayCommand(() =>
            {
                Service.DeleteEvents();
                Service.DeleteUsers();
                Service.Message("The client has completed its work.");
                Application.Current.Shutdown();
            }));
        
        public RelayCommand GetMinimizedCommand
            => _minimizedCommand ?? (_minimizedCommand = new RelayCommand(() =>
            {
                var window = System.Windows.Application.Current.Windows[0];
                if (window != null)
                {
                    window.WindowState = WindowState.Minimized;
                }
            }));

        #endregion
    }
}
