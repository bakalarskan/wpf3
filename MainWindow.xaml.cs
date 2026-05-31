using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace libraria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Books = new ObservableCollection<Book>();
            this.DataContext = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow= new AddBookWindow();
            addBookWindow.Owner = this;
            if (addBookWindow.ShowDialog() == true)
            {
                if (addBookWindow.book != null)
                {
                    Books.Add(addBookWindow.book);
                    UpdateStats("Book added");
                }
            }
        }

        private void UpdateStats(string statusMess)
        {
            TotalTextBlock.Text = "Total: " + Books.Count.ToString();
            StatusTextBlock.Text = statusMess;
        }
        private void DeleteSelectedBook()
        {
            if (BooksListBox.SelectedItem is Book selectedBook)
            {
                Books.Remove(selectedBook);
                UpdateStats("Book removed");
            }
        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedBook();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteSelectedBook();
            }
        }
    }
}