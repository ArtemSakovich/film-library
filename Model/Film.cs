using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmLibrary.Model
{
    public class Film
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public string Format { get; set; }
        public int Quality { get; set; } 
        public bool IsPopular { get; set; }
        public string ImagePath { get; set; }
        public string ThrailerPath { get; set; }
        public Film()
        {

        }
        public Film(string title, string company, int year, string genre, int durationInMinutes, string format, int quality, bool isPopular, string imagePath, string thrailerPath)
        {
            this.Title = title;
            this.Company = company;
            this.Year = year;
            this.Genre = genre;
            this.DurationInMinutes = durationInMinutes;
            this.Format = format;
            this.Quality = quality;
            this.IsPopular = isPopular;
            this.ImagePath = imagePath;
            this.ThrailerPath = thrailerPath;
        }
    }
}
