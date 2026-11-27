using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace AIVideoCreator.WPF.Services
{
    internal class VideoApiClient : IVideoService
    {

        private readonly HttpClient _httpClient;

        public VideoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateVideo(string title)
        {
            var response = await _httpClient.PostAsJsonAsync(

                    "api/videos",
                    new { Title = title }
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }
    }
}
