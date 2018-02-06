using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHaveNoIdeaWhatImDoingAnyMore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel _vm;
        LoginView _lv = new LoginView();
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                var loginView = new LoginView();
                loginView.ShowDialog();
                 _vm = new MainViewModel
                 {
                user = loginView.ViewModel.AuthenticatedUser
                  };
             DataContext = _vm;
            nameTextBox.Content = _vm.user.username;
            }
            catch (Exception)
            {

                Close();
            }
           
        }

        private void LogoutBtnClick(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView(true);
            Close();
            loginView.ShowDialog();
            if (loginView.ViewModel.AuthenticatedUser != null)
            {
                _vm.user = loginView.ViewModel.AuthenticatedUser;
                Show();
            }
            else
                Close();
        }
    }
}
