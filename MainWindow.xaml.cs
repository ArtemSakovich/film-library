using filmLibrary.Model;
using filmLibrary.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// РАЗРАБОТКА КАТАЛОГАЛИЗАТОРА ПРОДУКТОВ КИНОИНДУСТРИИ
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
            List<Film> popularFilms = FilmLibraryService.getFilmsByGenre(null, true);
            filmsList.ItemsSource = popularFilms;
        }
        private void filmList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Film film = (Film)filmsList.SelectedItem;
            InfoWindow infoWindow = new InfoWindow(film);
            
            infoWindow.WindowStartupLocation = (WindowStartupLocation)1;

            if (film != null)
            {
               infoWindow.Show();
            }
        }
        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if ("Popular".Equals(button.Content.ToString())) {
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByGenre(null, true);
                    filmsList.ItemsSource = filteredFilms;
                }
                else
                {
                    List<Film> filteredFilms = FilmLibraryService.getFilmsByGenre(button.Content.ToString(), false);
                    filmsList.ItemsSource = filteredFilms;
                }
            }
        }
        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if ("SORT ALL BY TITLE".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByTitle();
                    filmsList.ItemsSource = sortedFilms;
                }
                if ("SORT ALL BY COMPANY".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByCompany();
                    filmsList.ItemsSource = sortedFilms;
                }
                if ("SORT ALL BY YEAR".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByYear();
                    filmsList.ItemsSource = sortedFilms;
                }
                if ("SORT ALL BY DURATION".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByDuration();
                    filmsList.ItemsSource = sortedFilms;
                }
                if ("SORT ALL BY FORMAT".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByFormat();
                    filmsList.ItemsSource = sortedFilms;
                }
                if ("SORT ALL BY QUALITY".Equals(button.Content.ToString()))
                {
                    List<Film> sortedFilms = FilmLibraryService.sortFilmsByQuality();
                    filmsList.ItemsSource = sortedFilms;
                }
            }
        }
        private void allFimsButton_Click(object sender, RoutedEventArgs e)
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            filmsList.ItemsSource = allFilms;
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(this);
            searchWindow.WindowStartupLocation = (WindowStartupLocation)1;

            searchWindow.Show();
        }
        private void openAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow(null);
            addEditWindow.WindowStartupLocation = (WindowStartupLocation)1;

            addEditWindow.Show();
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
                filmsList.ItemsSource = FilmLibraryService.searchByTyping(searchTextBox.Text);
        }
        public void setItemSource(List<Film> filmsToShowBySearch)
        {
            filmsList.ItemsSource = filmsToShowBySearch;
        }
    }
}
