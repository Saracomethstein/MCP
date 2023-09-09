using System.Windows;

namespace Client.Views
{
    public partial class LoginWindowView : Window
    {
        public LoginWindowView()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
