using filmLibrary.Model;
using filmLibrary.Service;
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

namespace filmLibrary
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private MainWindow mainWindow;

        public SearchWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void searchByButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if ("Search by title".Equals(button.Content.ToString()))
                {
                    string[] filmTitleWords = searchByTitleTextBox.Text.ToLower().Split(' ');
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByTitle(filmTitleWords);
                    mainWindow.setItemSource(filteredFilms);
                }
                if ("Search by company".Equals(button.Content.ToString()))
                {
                    string[] filmCompanyWords = searchByCompanyTextBox.Text.ToLower().Split(' ');
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByCompany(filmCompanyWords);
                    mainWindow.setItemSource(filteredFilms);
                }
                if ("Search by year".Equals(button.Content.ToString()))
                {
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByYear(int.Parse(searchByYearTextBox.Text));
                    mainWindow.setItemSource(filteredFilms);
                }
                if ("Search by duration".Equals(button.Content.ToString()))
                {
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByDuration(int.Parse(searchByDurationTextBox.Text));
                    mainWindow.setItemSource(filteredFilms);
                }
                if ("Search by format".Equals(button.Content.ToString()))
                {
                    string[] filmFormatWords = searchByFormatTextBox.Text.ToLower().Split(' ');
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByFormat(filmFormatWords);
                    mainWindow.setItemSource(filteredFilms);
                }
                if ("Search by quality".Equals(button.Content.ToString()))
                {
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByQuality(int.Parse(searchByQualityTextBox.Text));
                    mainWindow.setItemSource(filteredFilms);
                }
            }
            Close();
        }
    }
}
