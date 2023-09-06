using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCLassLibrary.Model
{
    public class MovieManager
    {
        private List<Movie> movies;
        private MovieSerialization movieSerialization;
        private string filePath;

        public MovieManager(string filePath)
        {
            this.filePath = filePath;
            this.movieSerialization = new MovieSerialization();
            this.movies = movieSerialization.DeserializeMovies(filePath);
        }
        public MovieManager(List<Movie> movies)
        {
            this.movies = movies;
        }

        public void UploadMovie(int movieId, string movieName, int year, string director)
        {
            movies.Add(new Movie(movieId, movieName, year, director));
            movieSerialization.SerializeMovies(movies, filePath);
        }

        public string DisplayMovies()
        {
            string movieDetails = "";

            foreach (var movie in movies)
            {
                movieDetails += $"Title: {movie.MovieName}\n";
                movieDetails += $"Director: {movie.Director}\n";
                movieDetails += $"Release Year: {movie.Year}\n";
                movieDetails += "\n";
            }

            return movieDetails;
        }



        public void DeleteMovie(int index)
        {
            if (index <= movies.Count - 1)
            {
                movies.RemoveAt(index);
            }
            else
            {
                throw new MovieException("This index position is Empty");
            }
        }

        public List<Movie> SearchByYear(int year)
        {

            List<Movie> result = movies.Where(movie => movie.Year == year).ToList();
            return result;
        }
    }
}

