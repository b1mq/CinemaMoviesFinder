using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using MoviesFinder.Models;

namespace MoviesFinder.Services
{
    public class MovieService :IMovieService
    {
        private const string Api = "https://www.omdbapi.com/?i=tt3896198&apikey=5c15d396";
        private readonly HttpClient _httpClient;
        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<MoviesModel> GetMoviesAsync(string movie)
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var url = $"{Api}&t={Uri.EscapeDataString(movie)}";
                var response = await _httpClient.GetFromJsonAsync<MoviesModel>(url, options);
                return response ?? new MoviesModel { Response = "False", Error = "Фильм не найден." };
            }
            catch (HttpRequestException)
            {
                return new MoviesModel { Response = "False", Error = "Request Error" };
            }
            catch (Exception)
            {
                return new MoviesModel { Response = "False", Error = "404 Error" };
            }
        }
    }
}