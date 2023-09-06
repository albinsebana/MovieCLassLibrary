using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieCLassLibrary.Model
{
    public class MovieSerialization
    {
        public void SerializeMovies(List<Movie> movies, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, movies);
                }
                Console.WriteLine("Movie data has been successfully serialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while serializing movie data: {ex.Message}");
            }
        }

        public List<Movie> DeserializeMovies(string filePath)
        {
            List<Movie> movies = new List<Movie>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        movies = (List<Movie>)formatter.Deserialize(fs);
                    }
                    Console.WriteLine("Movie data has been successfully deserialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deserializing movie data: {ex.Message}");
            }

            return movies;
        }
    }
}