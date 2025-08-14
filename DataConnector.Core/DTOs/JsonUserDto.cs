//DataConnector.Core/DTOs/JsonUserDto.cs
namespace DataConnector.Core.DTOs;

public class JsonUserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public AddressDto Address { get; set; } = new();
}

public class AddressDto
{
    public string City { get; set; } = string.Empty;
}