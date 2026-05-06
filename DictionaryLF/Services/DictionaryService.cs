using DictionaryLF.Models;
using System.Text.Json;

namespace DictionaryLF.Services
{
    public class DictionaryService
    {
        private readonly HttpClient _httpClient;
        public DictionaryService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<DictionaryResponse> GetWordAsync(string word)
        {
            var url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
            
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<DictionaryResponse>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return data?.FirstOrDefault();
        }
    }
}
