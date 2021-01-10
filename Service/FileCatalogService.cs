using filmLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace filmLibrary.Service
{
    class FileCatalogService
    {
        public static List<Film> getFilms()
        {
            List<Film> allFilms = new List<Film>();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Film>));

            using (FileStream fs = new FileStream(System.IO.Path.Combine(Environment.CurrentDirectory,"filmCatalog.xml"), FileMode.Open))
            {
                allFilms = (List<Film>)formatter.Deserialize(fs);

            }
            return allFilms;
        }

        public static void saveFilms(List<Film> films)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Film>));

            using (FileStream fs = new FileStream(System.IO.Path.Combine(Environment.CurrentDirectory, "filmCatalog.xml"), FileMode.Create))
            { 
                formatter.Serialize(fs, films);
            }
        }
    }
}


