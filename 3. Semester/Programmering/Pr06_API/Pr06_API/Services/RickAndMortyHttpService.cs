using Pr06_API.Models;

namespace Pr06_API.Services;

public class RickAndMortyHttpService : IRickAndMortyHttpService
{
    private readonly HttpClient _httpClient;
    
    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Character>($"character/{id}");
    }
    
    public async Task<List<Character>> GetAllCharactersAsync()
    {
        var all = new List<Character>();
        var nextUrl = "character";

        while (!string.IsNullOrEmpty(nextUrl))
        {
            var resp = await _httpClient.GetFromJsonAsync<CharacterListResponse>(nextUrl);
            if (resp is null) break;

            all.AddRange(resp.Results);
            if (nextUrl is not null && nextUrl.StartsWith("https://rickandmortyapi.com/api/"))
            {
                nextUrl = nextUrl.Replace("https://rickandmortyapi.com/api/", "");
            }
        }

        return all;
    }
    
    public RickAndMortyHttpService (HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}