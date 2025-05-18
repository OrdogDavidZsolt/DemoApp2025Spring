using System.Net.Http.Json;
using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services;

public class PeopleService : IPeopleService
{
    private readonly HttpClient _httpClient;

    public PeopleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Person>>("people");
    }

    public async Task<Person> GetPersonAsync(string id)
    {
        return await _httpClient.GetFromJsonAsync<Person>($"people/{id}");
    }

    public async Task AddPersonAsync(Person person)
    {
        await _httpClient.PostAsJsonAsync("people", person);
    }

    public async Task UpdatePersonAsync(string id, Person person)
    {
        await _httpClient.PutAsJsonAsync($"people/{id}", person);
    }

    public async Task DeletePersonAsync(string id)
    {
        await _httpClient.DeleteAsync($"people/{id}");
    }
}