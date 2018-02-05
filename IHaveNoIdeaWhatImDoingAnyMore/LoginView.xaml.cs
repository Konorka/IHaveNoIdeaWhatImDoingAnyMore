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
using System.Windows.Shapes;

namespace IHaveNoIdeaWhatImDoingAnyMore
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        
        public LoginViewModel ViewModel { get; }
        public LoginView()
        {
            
            InitializeComponent();
            ViewModel = new LoginViewModel();
            DataContext = ViewModel;
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            ViewModel.Password = passwordPasswordBox.Password;
            if (ViewModel.Login())
            {
                Close();
                _mw.Show();
            }
            else
                MessageBox.Show("Nem megfelelő adatok");
        }
    }
}
