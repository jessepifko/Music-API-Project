using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music_API_Project.Models
{
    public class SearchResultsDAL
    {
        private readonly string _apiKey;

        public SearchResultsDAL(string apiKey)
        {
            this._apiKey = apiKey;
        }

        public HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deezerdevs-deezer.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "deezerdevs-deezer.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);
            return client;
        }

        public async Task<string> GetRawJSON(string input)
        {
            var client = GetClient();
            var response = await client.GetAsync($"{input}");
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<SearchResults> GetSearchResults(string queryString)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/search?q=" + queryString);
            SearchResults sr = await response.Content.ReadAsAsync<SearchResults>();
            return sr;
        }

        
        public async Task<Artist> GetArtist(string artId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/artist/" + artId);
            Artist artist = await response.Content.ReadAsAsync<Artist>();
            return artist;
        }

        public async Task<TrackList> GetTrackList(string artId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/artist/" + artId + $"/top?limit=25");
            TrackList trackList = await response.Content.ReadAsAsync<TrackList>();
            return trackList;
        }

        public async Task<Music_API_Project.Models.AlbumModel.Album> GetAlbum(int albumID)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/album/" + albumID);
            Music_API_Project.Models.AlbumModel.Album ab = await response.Content.ReadAsAsync<Music_API_Project.Models.AlbumModel.Album>();
            return ab;
        }
    }
}
