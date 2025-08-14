using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DataConnector.Core.DTOs;
using DataConnector.Core.Entities;
using DataConnector.Core.Interfaces;

namespace ClicDataConnector.API.Controllers;

[ApiController]
[Route("api/connectors/users")]
public class UsersConnectorController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUserRepository _userRepository;

    public UsersConnectorController(IHttpClientFactory httpClientFactory, IUserRepository userRepository)
    {
        _httpClientFactory = httpClientFactory;
        _userRepository = userRepository;
    }

    [HttpPost("pull")]
    public async Task<IActionResult> PullUsersAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, "Erreur lors de l'appel à JSONPlaceholder");

        var json = await response.Content.ReadAsStringAsync();

        var externalUsers = JsonSerializer.Deserialize<List<JsonUserDto>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (externalUsers == null || externalUsers.Count == 0)
            return BadRequest("Aucun utilisateur reçu depuis l’API externe.");

        var mappedUsers = externalUsers.Select(x => new User
        {
            Id = x.Id,
            Name = x.Name,
            Username = x.Username,
            Email = x.Email,
            City = x.Address.City
        });

        await _userRepository.AddUsersAsync(mappedUsers);

        return Ok(new
        {
            message = $"{mappedUsers.Count()} utilisateurs importés avec succès.",
            source = "https://jsonplaceholder.typicode.com/users"
        });
    }
}