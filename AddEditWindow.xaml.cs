using filmLibrary.Model;
using filmLibrary.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public partial class AddEditWindow : Window
    {
        string imagePath, thrailerPath;
        public AddEditWindow(Film selectedFilm)
        {
            InitializeComponent();

            this.DataContext = selectedFilm;

            if (selectedFilm != null)
            {
                if (selectedFilm.IsPopular)
                {
                    isPopularComboBox.Text = "Yes";
                }
                else
                {
                    isPopularComboBox.Text = "No";
                }

                imagePath = selectedFilm.ImagePath;
                thrailerPath = selectedFilm.ThrailerPath;
            }
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FilmLibraryService.helpToValidate(titleTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(companyTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(yearTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(null, genreComboBox))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(durationInMinutesTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(formatTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(qualityTextBox, null))
            {
                return;
            }
            if (!FilmLibraryService.helpToValidate(null, isPopularComboBox))
            {
                return;
            }
            if (imagePath == null)
            {
                selectImageButton.Background = System.Windows.Media.Brushes.Red;
                return;
            }
            else
            {
                selectImageButton.Background = System.Windows.Media.Brushes.DarkSlateBlue;
            }
            if (thrailerPath == null)
            {
                selectThrailerButton.Background = System.Windows.Media.Brushes.Red;
                return;
            }
            else
            {
                selectThrailerButton.Background = System.Windows.Media.Brushes.DarkSlateBlue;
            }

            string title = titleTextBox.Text;
            string company = companyTextBox.Text;
            int year = int.Parse(yearTextBox.Text);
            string genre = genreComboBox.Text;
            int duration = int.Parse(durationInMinutesTextBox.Text);
            string format = formatTextBox.Text;
            int quality = int.Parse(qualityTextBox.Text);
            bool isPopular = false;

            if (isPopularComboBox.Text.Equals("Yes"))
            {
                isPopular = true;
            }
            else
            {
                isPopular = false;
            }
            Film helper = (Film)DataContext;
            if (helper != null)
            {
                FilmLibraryService.editFilm((Film)DataContext, title, company, year, genre, duration, format, quality, isPopular, imagePath, thrailerPath);
                Close();
            }
            else
            {
                Film newFilm = new Film(title, company, year, genre, duration, format, quality, isPopular, imagePath, thrailerPath);
                FilmLibraryService.addNewFilm(newFilm);
                Close();
            }
        }
        private void addImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JPG; *.PNG; *.BMP)| *.JPG; *.PNG; *.BMP *.*";
            openFileDialog.ShowDialog();
            imagePath = openFileDialog.FileName;
        }
        private void addThrailerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files(*.MP4; *.MOV; *.AVI)| *.MP4; *.MOV; *.AVI  *.*";
            openFileDialog.ShowDialog();
            thrailerPath = openFileDialog.FileName;
        }
    }
}