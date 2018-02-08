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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        eDiaryDataSet eDiaryDataSet = new eDiaryDataSet();
        eDiaryDataSetTableAdapters.StudentTableAdapter StudentContext = new eDiaryDataSetTableAdapters.StudentTableAdapter();
        eDiaryDataSetTableAdapters.TeacherTableAdapter TeacherContext = new eDiaryDataSetTableAdapters.TeacherTableAdapter();

        public AdminView()
        {
            InitializeComponent();
        }

        private void teachersOrStudentsButton(object sender, RoutedEventArgs e)
        {
            if (teacherDataGrid.IsVisible == false)
            {
                studentDataGrid.Visibility = Visibility.Hidden;
                teacherDataGrid.Visibility = Visibility.Visible;
                studentOrTeacers.Content = "Diákok";
            }
            else
            {
                teacherDataGrid.Visibility = Visibility.Hidden;
                studentDataGrid.Visibility = Visibility.Visible;
                studentOrTeacers.Content = "Tanárok";
            }

        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            StudentContext.Update(eDiaryDataSet);
            TeacherContext.Update(eDiaryDataSet);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            eDiaryDataSet = ((eDiaryDataSet)(FindResource("eDiaryDataSet")));
            // Student Load
            StudentContext.Fill(eDiaryDataSet.Student);
            CollectionViewSource studentViewSource = ((CollectionViewSource)(FindResource("studentViewSource")));
            studentViewSource.View.MoveCurrentToFirst();
            // Teacher loand 
            TeacherContext.Fill(eDiaryDataSet.Teacher);
            CollectionViewSource teacherViewSource = ((CollectionViewSource)(FindResource("teacherViewSource")));
            teacherViewSource.View.MoveCurrentToFirst();

        }

        private void AdminClosingBtn(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki akar lépni?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
