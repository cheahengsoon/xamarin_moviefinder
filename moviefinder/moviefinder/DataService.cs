using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace moviefinder
{
    public class DataService
    {
        private HttpClient client;
        private static string baseApiUrl = "http://www.omdbapi.com/";

        public DataService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Movie> GetMovieByTitleAsync(string Title)
        {
            Movie movie = new Movie();
            Title = Title.ToString().Replace(" ", "+");
            string uri = baseApiUrl + "?t=" + Title + "&y=&plot=short&r=json";
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<Movie>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return movie;

        }
    }
}
