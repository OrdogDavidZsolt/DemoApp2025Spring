using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services;

public interface IPeopleService
{
    Task<List<Person>> GetPeopleAsync();
    
    Task<Person> GetPersonAsync(string id);
    
    Task AddPersonAsync(Person person);
    
    Task UpdatePersonAsync(string id, Person person);
    
    Task DeletePersonAsync(string id);
}