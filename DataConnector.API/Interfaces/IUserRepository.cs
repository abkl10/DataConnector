// ClicDataConnector.Core/Interfaces/IUserRepository.cs
using DataConnector.Core.Entities;

namespace DataConnector.Core.Interfaces;

public interface IUserRepository
{
    Task AddUsersAsync(IEnumerable<User> users);
    Task<IEnumerable<User>> GetAllUsersAsync();
}