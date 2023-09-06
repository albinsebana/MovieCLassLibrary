namespace MovieCLassLibrary.Model
{
        [Serializable]
        public class Movie
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public int Year { get; set; }
            public string Director { get; set; }

            public Movie(int movieId, string movieName, int year, string director)
            {
                MovieId = movieId;
                MovieName = movieName;
                Year = year;
                Director = director;
            }
        }
 }