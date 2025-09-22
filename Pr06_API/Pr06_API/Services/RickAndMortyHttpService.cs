using Pr06_API.Models;

namespace Pr06_API.Services;

public class RickAndMortyHttpService : IRickAndMortyHttpService
{
    private readonly HttpClient _httpClient;
    
    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Character>($"character/{id}");
    }
    
    public RickAndMortyHttpService (HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}