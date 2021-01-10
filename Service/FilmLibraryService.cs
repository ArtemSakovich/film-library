using filmLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace filmLibrary.Service
{
    class FilmLibraryService
    {
        public class StringComparer : IComparer<string>
        {
            public int Compare(string v, string f)
            {
                return v.IndexOf(f) != -1 ? 0 : -1;
            }
        }
        private static List<Film> films { get; set; }
        static FilmLibraryService()
        {
            films = parseFilmsFromCatalog();
        }
        public static List<Film> getAllFilms()
        {
            return films;
        }
        private static List<Film> parseFilmsFromCatalog()
        {
            return FileCatalogService.getFilms();
        }
        public static List<Film> getFilmsByGenre(string genre, bool isPopularOnly)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                if (isPopularOnly)
                {
                    if (film.IsPopular)
                    {
                        resultCollection.Add(film);
                    }
                }
                else
                {
                    if (film.Genre.Equals(genre))
                    {
                        resultCollection.Add(film);
                    }
                }
            }
            return resultCollection;
        }

        internal static bool helpToValidate(TextBox currentTextBox, ComboBox currentComboBox)
        {
            if (currentTextBox != null)
            {
                if (currentTextBox.Name.Equals("titleTextBox") || currentTextBox.Name.Equals("companyTextBox") || currentTextBox.Name.Equals("yearTextBox") || currentTextBox.Name.Equals("durationInMinutesTextBox") || currentTextBox.Name.Equals("formatTextBox") || currentTextBox.Name.Equals("qualityTextBox"))
                {
                    if ((!currentTextBox.Text.Equals(String.Empty)) && isValidField(currentTextBox.Text, currentTextBox))
                    {
                        currentTextBox.BorderBrush = System.Windows.Media.Brushes.LightGray;
                        return true;
                    }
                    else
                    {
                        currentTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                        return false;
                    }
                }
            }
            if (currentComboBox.Name.Equals("genreComboBox") || currentComboBox.Name.Equals("isPopularComboBox"))
            {

                if (currentComboBox.Name.Equals("genreComboBox") && currentComboBox.Text.Equals(String.Empty))
                {
                    MessageBox.Show("Please select genre");
                    return false;
                }
                else if (currentComboBox.Name.Equals("isPopularComboBox") && currentComboBox.Text.Equals(String.Empty))
                {
                    MessageBox.Show("Please select popularity of the film");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        internal static List<Film> getFilmsByTitle(string[] userWords)
        {
            List<Film> resultCollection = new List<Film>(); 

            foreach (var film in films)
            {
                string[] filmWords = film.Title.ToLower().Split(' ');
                foreach (var userWord in userWords)
                {
                    foreach (var filmWord in filmWords)
                    {
                        if (filmWord.Equals(userWord))
                        {
                            resultCollection.Add(film);
                        }
                    }
                }
            }
            return resultCollection;
        }
        internal static List<Film> getFilmsByCompany(string[] userWords)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                string[] filmWords = film.Company.ToLower().Split(' ');
                foreach (var userWord in userWords)
                {
                    foreach (var filmWord in filmWords)
                    {
                        if (filmWord.Equals(userWord))
                        {
                            resultCollection.Add(film);
                        }
                    }
                }
            }
            return resultCollection;
        }
        internal static List<Film> getFilmsByFormat(string[] userWords)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                string[] filmWords = film.Format.ToLower().Split(' ');
                foreach (var userWord in userWords)
                {
                    foreach (var filmWord in filmWords)
                    {
                        if (filmWord.Equals(userWord))
                        {
                            resultCollection.Add(film);
                        }
                    }
                }
            }
            return resultCollection;
        }
        internal static List<Film> getFilmsByYear(int year)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                if (film.Year.Equals(year))
                {
                    resultCollection.Add(film);
                }
            }
            return resultCollection;
        }

        internal static List<Film> sortFilmsByTitle()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<string> titles = new List<string>();

            foreach (var film in allFilms)
            {
                titles.Add(film.Title);
            }
            titles.Sort();

            List<string> distinct = titles.Distinct().ToList();
            List<Film> sortedByTitle = new List<Film>();

            foreach (var title in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (title == film.Title)
                    {
                        sortedByTitle.Add(film);
                    }
                }
            }
            return sortedByTitle;
        }

        internal static List<Film> searchByTyping(string textToSearch)
        {
            List<Film> allFilms = getAllFilms();
            List<Film> resultList = new List<Film>();
            foreach (var film in allFilms)
            {
                if (film.Title.ToLower().Contains(textToSearch.ToLower()))
                {
                    resultList.Add(film);
                }
            }
            return resultList;
        }
        internal static List<Film> sortFilmsByFormat()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<string> formats = new List<string>();

            foreach (var film in allFilms)
            {
                formats.Add(film.Format);
            }
            formats.Sort();

            List<string> distinct = formats.Distinct().ToList();
            List<Film> sortedByFormat = new List<Film>();

            foreach (var format in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (format == film.Format)
                    {
                        sortedByFormat.Add(film);
                    }
                }
            }
            return sortedByFormat;
        }

        internal static List<Film> sortFilmsByQuality()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<int> qualities = new List<int>();

            foreach (var film in allFilms)
            {
                qualities.Add(film.Quality);
            }
            qualities.Sort();

            List<int> distinct = qualities.Distinct().ToList();
            List<Film> sortedByQuality = new List<Film>();

            foreach (var quality in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (quality == film.Quality)
                    {
                        sortedByQuality.Add(film);
                    }
                }
            }
            return sortedByQuality;
        }

        internal static List<Film> sortFilmsByDuration()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<int> durations = new List<int>();

            foreach (var film in allFilms)
            {
                durations.Add(film.DurationInMinutes);
            }
            durations.Sort();

            List<int> distinct = durations.Distinct().ToList();
            List<Film> sortedByDuration = new List<Film>();

            foreach (var duration in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (duration == film.DurationInMinutes)
                    {
                        sortedByDuration.Add(film);
                    }
                }
            }
            return sortedByDuration;
        }

        internal static List<Film> sortFilmsByYear()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<int> years = new List<int>();

            foreach (var film in allFilms)
            {
                years.Add(film.Year);
            }
            years.Sort();

            List<int> distinct = years.Distinct().ToList();
            List<Film> sortedByYear = new List<Film>();

            foreach (var year in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (year == film.Year)
                    {
                        sortedByYear.Add(film);
                    }
                }
            }
            return sortedByYear;
        }

        internal static List<Film> sortFilmsByCompany()
        {
            List<Film> allFilms = FilmLibraryService.getAllFilms();
            List<string> companies = new List<string>();

            foreach (var film in allFilms)
            {
                companies.Add(film.Company);
            }
            companies.Sort();

            List<string> distinct = companies.Distinct().ToList();
            List<Film> sortedByCompany = new List<Film>();

            foreach (var company in distinct)
            {
                foreach (var film in allFilms)
                {
                    if (company == film.Company)
                    {
                        sortedByCompany.Add(film);
                    }
                }
            }
            return sortedByCompany;
        }

        internal static List<Film> getFilmsByDuration(int duration)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                if (film.DurationInMinutes.Equals(duration))
                {
                    resultCollection.Add(film);
                }
            }
            return resultCollection;
        }
        internal static List<Film> getFilmsByQuality(int quality)
        {
            List<Film> resultCollection = new List<Film>();

            foreach (var film in films)
            {
                if (film.Quality.Equals(quality))
                {
                    resultCollection.Add(film);
                }
            }
            return resultCollection;
        }
        internal static bool isValidField(string fieldText, TextBox textBox)
        {
            int helpToParseNumber;
            if (textBox.Name.Equals("titleTextBox"))
            {
                return textBox.Text.ToString().Length <= 50;
            }
            if (textBox.Name.Equals("companyTextBox"))
            {
                return textBox.Text.ToString().Length <= 50;
            }
            if (textBox.Name.Equals("yearTextBox"))
            {
                bool isNumber = int.TryParse(fieldText, out helpToParseNumber);
                if (isNumber)
                {
                    return helpToParseNumber >= 1895 && helpToParseNumber <= 2020;
                }
            }
            if (textBox.Name.Equals("durationInMinutesTextBox"))
            {
                bool isNumber = int.TryParse(fieldText, out helpToParseNumber);
                if (isNumber)
                {
                    return helpToParseNumber > 0 && helpToParseNumber <= 600;
                }
            }
            if (textBox.Name.Equals("formatTextBox"))
            {
                return textBox.Text.ToString().Length <= 15;
            }
            if (textBox.Name.Equals("qualityTextBox"))
            {
                bool isNumber = int.TryParse(fieldText, out helpToParseNumber);
                if (isNumber)
                {
                    return helpToParseNumber >= 144 && helpToParseNumber <= 4320;
                }
            }
            return false;
        }

        internal static void deleteFilm(Film filmToDelete)
        {
            films.Remove(filmToDelete);
            FileCatalogService.saveFilms(films);
        }

        internal static void addNewFilm(Film newFilm)
        {
            films.Add(newFilm);
            FileCatalogService.saveFilms(films);
        }
        internal static void editFilm(Film filmToEdit, string title, string company, int year, string genre, int duration, string format, int quality, bool isPopular, string imagePath, string thrailerPath)
        {
            filmToEdit.Title = title;
            filmToEdit.Company = company;
            filmToEdit.Year = year;
            filmToEdit.Genre = genre;
            filmToEdit.DurationInMinutes = duration;
            filmToEdit.Format = format;
            filmToEdit.Quality = quality;
            filmToEdit.IsPopular = isPopular;
            filmToEdit.ImagePath = imagePath;
            filmToEdit.ThrailerPath = thrailerPath;

            FileCatalogService.saveFilms(films);
        }

    }
}
