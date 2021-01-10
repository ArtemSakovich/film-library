using filmLibrary.Model;
using filmLibrary.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace filmLibrary
{
    /// <summary>
    /// Interaction logic for InfoWindoW.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(Film selectedFilm)
        {
            InitializeComponent();

            this.DataContext = selectedFilm;

        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow((Film)DataContext);
            addEditWindow.WindowStartupLocation = (WindowStartupLocation)1;

            addEditWindow.Show();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            FilmLibraryService.deleteFilm((Film)DataContext);
            Close();
        }
        private void playThrailerButton_Click(object sender, RoutedEventArgs e)
        {
            Film selectedFilm = new Film();
            selectedFilm = (Film)DataContext;
            Process.Start(selectedFilm.ThrailerPath);
        }
    }
}
