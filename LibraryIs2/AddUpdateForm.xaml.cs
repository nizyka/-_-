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

namespace LibraryIs2
{
    /// <summary>
    /// Логика взаимодействия для AddUpdateForm.xaml
    /// </summary>
    public partial class AddUpdateForm : Window
    {
        PM05Book book;
        public AddUpdateForm(PM05Book pM05Book)
        {
            InitializeComponent();
            book = pM05Book;
            DataContext = book;
            sectionComboBox.ItemsSource = DataBase.GetContext().PM05Section.ToList();
            publisherComboBox.ItemsSource = DataBase.GetContext().PM05Publisher.ToList();
        }
        public AddUpdateForm()
        {
            InitializeComponent();
            book = new PM05Book();
            DataContext = book;
            sectionComboBox.ItemsSource = DataBase.GetContext().PM05Section.ToList();
            publisherComboBox.ItemsSource = DataBase.GetContext().PM05Publisher.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!DataBase.GetContext().PM05Book.Contains(book))
                    DataBase.GetContext().PM05Book.Add(book);
                DataBase.GetContext().SaveChanges();
                ((MainWindow)this.Owner).UpdateCatalogBook();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
