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
using MoreLinq;

namespace IHaveNoIdeaWhatImDoingAnyMore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel _vm;
        LoginView _lv = new LoginView();
        AdminView _av = new AdminView();
        Student student = new Student();

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
            }
            catch (Exception)
            {

                Hide();
            }         
                nameTextBox.Content = _vm.user.username;
                if (_vm.user.user_access_rank == 1)
                {
                    Hide();
                    _av.Show();
                }
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSet eDiaryDataSet = ((IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSet)(this.FindResource("eDiaryDataSet")));
            // Load data into the table Class. You can modify this code as needed.
            IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSetTableAdapters.ClassTableAdapter eDiaryDataSetClassTableAdapter = new IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSetTableAdapters.ClassTableAdapter();
            eDiaryDataSetClassTableAdapter.Fill(eDiaryDataSet.Class);
            System.Windows.Data.CollectionViewSource classViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classViewSource")));
            classViewSource.View.MoveCurrentToFirst();
            // Load data into the table Student. You can modify this code as needed.
            IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSetTableAdapters.StudentTableAdapter eDiaryDataSetStudentTableAdapter = new IHaveNoIdeaWhatImDoingAnyMore.eDiaryDataSetTableAdapters.StudentTableAdapter();
            eDiaryDataSetStudentTableAdapter.Fill(eDiaryDataSet.Student);
            System.Windows.Data.CollectionViewSource classStudentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classStudentViewSource")));
            classStudentViewSource.View.MoveCurrentToFirst();
        }
    }
}
