using Pr06_API.Models;

namespace Pr06_API.Services;

public interface IRickAndMortyHttpService
{
    Task<Character?> GetCharacterByIdAsync(int id);
}