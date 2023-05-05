using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job);
    Task<List<UserDto>> GetUsers(int page);
    Task<UserResponse> UpdateUserPut(int id, string name, string job);
    Task<UserResponse> UpdateUserPatch(int id, string name, string job);
    Task<bool> DeleteUser(int id);
}