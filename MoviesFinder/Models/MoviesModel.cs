using Microsoft.AspNetCore.Http;

namespace MoviesFinder.Models
{
    public class MoviesModel
    {
        public string? RequestId { get; set; }

        public string? Title {  get; set; }
        public string? Year { get; set; }
        public  string? Genres { get; set; } 
        public string? Poster { get; set; }
        public  string? Actors { get; set; } 
        public string? Language { get; set; }
        public string? Plot {  get; set; }
        public string? Response { get; set; }

        public string? Error { get; set; }
    }
}
